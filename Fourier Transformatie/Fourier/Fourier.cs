using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Fourier_Transformatie.Fourier {
	public static class Fourier {

        /// <summary>
        /// Voer een voorwaards Fourier analyse uit
        /// </summary>
        /// <param name="greyArray"></param>
        /// <returns>Object met: [0] Fourier resultset, [1] Bitmap Modulus plot, [2] Bitmap Argument plot</returns>
        public static Object[] forwardFFT(int[,] greyArray, bool shift, int scale1, int scale2) {
            // Ons return object
            Object[] ret = new Object[3];

            // Maak een container object aan voor de complexe getallen
            // Nu hebben we nog reële getallen maar na da Fourier analyse 
            // Bekomen we imaginaire getallen
            ComplexGetal[,] complexeArray = new ComplexGetal[greyArray.GetLength(0), greyArray.GetLength(1)];

            // Vul de complexe array op
            for (int i = 0; i < greyArray.GetLength(0); i++) {
                for (int j = 0; j < greyArray.GetLength(1); j++) {
                    complexeArray[i, j] = new ComplexGetal(greyArray[i, j], 0);
                }
            }

            // Voer de Fourier analyse uit
            complexeArray = FFT2D(complexeArray, FourierDirection.Forward);
            ret[0] = complexeArray;

            // Moeten de plot grafieken genormaliseerd worden?
            if (shift) complexeArray = shiftFFTResult(complexeArray);

            // Maak een plot a.d.h.v. de modulus (Magnitude)
            ret[1] = plotMod(complexeArray, scale1);

            // Maak een plot a.d.h.v. het argument (Phase)
            ret[2] = plotArg(complexeArray, scale2);

            // Geef de waarden terug
            return ret;
        }

        /// <summary>
        /// Maak van een Fourier resultset opnieuw een afbeelding
        /// </summary>
        /// <param name="fourier">De Fourier set</param>
        /// <returns>De geproduceerde grijs-waarden afbeelding</returns>
        public static Bitmap backwardFFT(ComplexGetal[,] fourier) {
            float[,] greyscale = new float[fourier.GetLength(0),fourier.GetLength(1)];

            fourier = FFT2D(fourier, FourierDirection.Backward);

            for (int i = 0; i < fourier.GetLength(0); i++) {
                for (int j = 0; j < fourier.GetLength(1); j++) {
                    greyscale[i, j] = fourier[i, j].Modulus;
                }
            }

            return createImage(greyscale, 1);
        }

        #region Fourier2D

        /// <summary>
        /// Voert een 2 dimensionale Fourier analyse uit op een afbeelding
        /// </summary>
        /// <param name="invoer">De complexe waarden van de afbeelding</param>
        /// <param name="dir">FourierDirection.Forward or FourierDirection.Backward</param>
        /// <returns>Fourier resultset</returns>
        private static ComplexGetal[,] FFT2D(ComplexGetal[,] invoer, FourierDirection dir) {
            float[] reëel = new float[invoer.GetLength(1)];
            float[] imaginair = new float[invoer.GetLength(1)];
            ComplexGetal[,] resultaat = invoer;

            //rijen
            for (int i = 0; i < invoer.GetLength(0); i++) {
                // Plaats de waarden in een 1 dimensionale array
                for (int j = 0; j < invoer.GetLength(1); j++) {
                    reëel[j] = invoer[i, j].Reëel;
                    imaginair[j] = invoer[i, j].Imaginair;
                }

                // Voer een 1 dimensionale fourier analyse uit op de huidige rij
                FFT1D(dir, reëel, imaginair);

                // Plaats de waarden in het resultaat object
                for (int j = 0; j < resultaat.GetLength(1); j++) {
                    resultaat[i, j].Reëel = reëel[j];
                    resultaat[i, j].Imaginair = imaginair[j];
                }
            }

            //kolommen - gebruik nu het resultaat object, anders gaan de berekeningen van de rijen verloren
            for (int i = 0; i < resultaat.GetLength(1); i++) {
                // Plaats de waarden in een 1 dimensionale array
                for (int j = 0; j < resultaat.GetLength(0); j++) {
                    reëel[j] = resultaat[j, i].Reëel;
                    imaginair[j] = resultaat[j, i].Imaginair;
                }

                // Voer een 1 dimensionale fourier analyse uit op de huidige kolom
                FFT1D(dir, reëel, imaginair);

                // Plaats de waarden in het resultaat object
                for (int j = 0; j < resultaat.GetLength(0); j++) {
                    resultaat[j, i].Reëel = reëel[j];
                    resultaat[j, i].Imaginair = imaginair[j];
                }
            }

            return resultaat;
        }

        /// <summary>
        /// Maak een amplitude plot aan de hand van de modulus van de imaginaire getallen
        /// </summary>
        /// <param name="array">Fourier resultset</param>
        /// <param name="scale">Herschaling van de amplitude plot</param>
        /// <returns>Bitmap</returns>
        private static Bitmap plotMod(ComplexGetal[,] array, int scale) {
            float[,] modulusPlot = new float[array.GetLength(0),array.GetLength(1)];
            float max = 0;

            // Plaats de Modulus van ieder complex getal in een multidimensionale float array
            // De Modulus wordt berekend door de ComplexGetal klasse.
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    modulusPlot[i, j] = (float)Math.Log(1 + array[i, j].Modulus);

                    // Bepaal de hoogste waarde
                    if (modulusPlot[i, j] > max) max = modulusPlot[i, j];
                }                
            }

            // Herschaal alle waarden met als referentie de hoogste waarde (100%)
            for (int i = 0; i < modulusPlot.GetLength(0); i++) {
                for (int j = 0; j < modulusPlot.GetLength(1); j++) {
                    modulusPlot[i, j] /= max;
                }
            }

            return createImage(modulusPlot, scale);
        }

        /// <summary>
        /// Maak een fase plot aan de hand van het Imaginair argument
        /// </summary>
        /// <param name="array">Fourier resultset</param>
        /// <param name="scale">Herschaling van de fase plot</param>
        /// <returns>Bitmap</returns>
        private static Bitmap plotArg(ComplexGetal[,] array, int scale) {
            float[,] argumentPlot = new float[array.GetLength(0), array.GetLength(1)];
            float max = 0;

            // Plaats het argument van ieder complex getal in een multidimensionale float array
            // Het argument wordt berekend door de ComplexGetal klasse.
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    argumentPlot[i, j] = (float)Math.Log(1 + Math.Abs(array[i, j].Argument));

                    // Bepaal de hoogste waarde
                    if (argumentPlot[i, j] > max) max = argumentPlot[i, j];
                }
            }

            // Herschaal alle waarden met als referentie de hoogste waarde (100%)
            for (int i = 0; i < argumentPlot.GetLength(0); i++) {
                for (int j = 0; j < argumentPlot.GetLength(1); j++) {
                    argumentPlot[i, j] = argumentPlot[i, j] / max;
                }
            }

            return createImage(argumentPlot, scale);
        }

        /// <summary>
        /// Hersorteer de meegegeven Fourier resultatenset van een indeling met de oorsprong in 0,0
        /// O -   -  --->
        /// |1,1 1,2 ..
        /// |2,1 2,2 ..
        /// |..  .. 
        /// V
        /// 
        /// Naar een met de oorsprong in het midden
        /// 
        ///             ^
        ///  1,-2  1,-1 |  1,1  1,2
        ///   -     -   O   -    -   --->
        /// -1,-2 -1,-1 | -1,1 -1,2
        ///             V
        /// 
        /// Referentie https://www.youtube.com/watch?v=X53SrMnu91A
        /// </summary>
        /// <param name="result">Te herindelen set</param>
        /// <returns>aangepaste set</returns>
        private static ComplexGetal[,] shiftFFTResult(ComplexGetal[,] result) {
            int a = result.GetLength(0);
            int b = result.GetLength(1);
            ComplexGetal[,] shiftResult = new ComplexGetal[a, b];

            for (int i = 0; i < (a / 2); i++) {
                for (int j = 0; j < (b / 2); j++) {
                    shiftResult[i + (a / 2), j + (b / 2)] = result[i, j];
                    shiftResult[i + (a / 2), j] = result[i, j + (b / 2)];
                    shiftResult[i, j + (b / 2)] = result[i + (a / 2), j];
                    shiftResult[i, j] = result[i + (a / 2), j + (b / 2)];
                }
            }

            return shiftResult;
        }

        /// <summary>
        /// Maak van een Fourier resultaten set een begrijpbare afbeelding
        /// </summary>
        /// <param name="source">De set waarvan een afbeelding gemaakt dient te worden</param>
        /// <param name="rescale">Herschalings niveau van de te genereren afbeelding</param>
        /// <returns>Een Bitmap die de resultatenset voorsteld</returns>
        private unsafe static Bitmap createImage(float[,] source, int rescale) {
            Bitmap img = new Bitmap(source.GetLength(1), source.GetLength(1));
            BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(img.PixelFormat) / 8; //Het aantals bytes per pixel (bits per pixel / 8)
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0; //De pointer naar de geheugenlocatie waar de eerste pixel van de afbeelding zich bevindt.

            for (int y = 0; y < HeightInPixels; y++) {
                //Bepaal de schrijflijn
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp) {
                    currentLine[x] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 1] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 2] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 3] = (byte)255;
                }
            }

            //Plaats de bewerkte BitmapData terug in de afbeelding
            img.UnlockBits(bitmapData);
            return img;
        }

        #endregion Fourier2D

        #region Fourier1D

        /// <summary>
		/// This function computes an in-place complex-to-complex FFT
		///    x and y are the real and imaginary arrays of 2^m points.
		///    Both arrays must have equal size and must be a power of 2. 
		///    dir = 1 gives forward transform
		///    dir = -1 gives reverse transform
		///    Formula: forward
		///             N-1
		///              ---
		///            1 \         - j k 2 pi n / N
		///    X(K) = --- > x(n) e                  = Forward transform
		///            N /                            n=0..N-1
		///              ---
		///             n=0
		///    Formula: reverse
		///             N-1
		///             ---
		///             \          j k 2 pi n / N
		///    X(n) =    > x(k) e                  = Inverse transform
		///             /                             k=0..N-1
		///             ---
		///             k=0
		/// The result is found in the arrays x and y. 
		/// </summary>
		/// <param name="dir">FourierDirection.Forward or FourierDirection.Backward</param>
		/// <param name="x">real values</param>
		/// <param name="y">imaginary values</param>
		private static void FFT1D(FourierDirection dir, float[] x, float[] y)
		{
			long nn, i, i1, j, k, i2, l, l1, l2;
			float c1, c2, tx, ty, t1, t2, u1, u2, z;

			if (x.Length != y.Length)
				throw new FormatException("Real values and imaginary values arrays lengths do not match");

			int m = (int)Math.Log(x.Length, 2);
			if (m != Math.Log(x.Length, 2))
				throw new FormatException("Data arrays lenght is no power of two");

			/* Calculate the number of points */
			nn = 1;
			for (i = 0; i < m; i++)
				nn *= 2;
			/* Do the bit reversal */
			i2 = nn >> 1;
			j = 0;
			for (i = 0; i < nn - 1; i++)
			{
				if (i < j)
				{
					tx = x[i];
					ty = y[i];
					x[i] = x[j];
					y[i] = y[j];
					x[j] = tx;
					y[j] = ty;
				}
				k = i2;
				while (k <= j)
				{
					j -= k;
					k >>= 1;
				}
				j += k;
			}
			/* Compute the FFT */
			c1 = -1f;
			c2 = 0f;
			l2 = 1;
			for (l = 0; l < m; l++)
			{
				l1 = l2;
				l2 <<= 1;
				u1 = 1;
				u2 = 0;
				for (j = 0; j < l1; j++)
				{
					for (i = j; i < nn; i += l2)
					{
						i1 = i + l1;
						t1 = u1 * x[i1] - u2 * y[i1];
						t2 = u1 * y[i1] + u2 * x[i1];
						x[i1] = x[i] - t1;
						y[i1] = y[i] - t2;
						x[i] += t1;
						y[i] += t2;
					}
					z = u1 * c1 - u2 * c2;
					u2 = u1 * c2 + u2 * c1;
					u1 = z;
				}
				c2 = (float)Math.Sqrt((1f - c1) / 2f);
				if (dir == FourierDirection.Forward)
					c2 = -c2;
				c1 = (float)Math.Sqrt((1f + c1) / 2f);
			}
			/* Scaling for forward transform */
			if (dir == FourierDirection.Forward)
			{
				for (i = 0; i < nn; i++)
				{
					x[i] /= nn;
					y[i] /= nn;

				}
			}
        }
        #endregion Fourier1D
    }

	#region FourierDirection
	/// <summary>
	/// <p>The direction of the fourier transform.</p>
	/// </summary>
	public enum FourierDirection : int
	{
		/// <summary>
		/// Forward direction.  Usually in reference to moving from temporal
		/// representation to frequency representation
		/// </summary>
		Forward = 1,
		/// <summary>
		/// Backward direction. Usually in reference to moving from frequency
		/// representation to temporal representation
		/// </summary>
		Backward = -1,
	}
	#endregion FourierDirection

}
