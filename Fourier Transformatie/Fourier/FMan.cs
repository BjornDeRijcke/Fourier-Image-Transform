using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

// My references
using Fourier_Transformatie.IO;

namespace Fourier_Transformatie.Fourier {
    class FMan {
        private Bitmap original;
        private Bitmap modPlot;
        private Bitmap argPlot;
        private Bitmap revPlot;

        private int[,] greyPixelArray;
        private ComplexGetal[,] fourierResult;

        #region public

        /// <summary>
        /// Laadt een afbeelding in en herschaal ze naar afmetingen die een macht van 2 zijn.
        /// </summary>
        /// <param name="location">De locatie van de afbeelding</param>
        /// <returns>De afbeelding met afmetingen 512x512, om aan de gebruiker te tonen</returns>
        public Bitmap LoadImage(string location) {
            original = CutOut(LukeFilewalker.readFromLocation(location));
            generateGrayScaleArray();
            return resize(original, 512, 512);
        }

        /// <summary>
        /// Sla de bekomen afbeeldingen op
        /// </summary>
        /// <param name="location">De locatie waar de afbeeldingen komen</param>
        public void SaveImage(string location) {
            LukeFilewalker.writeToLocation(location + "\\org.png", original, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\mod.png", modPlot, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\arg.png", argPlot, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\rev.png", revPlot, ImageFormat.Png);
        }

        /// <summary>
        /// Maak een grijswaarden-afbeelding van het bronbestand
        /// </summary>
        /// <returns>De grijswaarden-afbeelding, herschaald naar 256x256 om aan de gebruiker te tonen</returns>
        public unsafe Bitmap CreateGreyscaleBitmap() {
            Bitmap b = new Bitmap(greyPixelArray.GetLength(1), greyPixelArray.GetLength(1));
            BitmapData bitmapData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(b.PixelFormat) / 8; //Het aantals bytes per pixel (bits per pixel / 8)
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0; //De pointer naar de geheugenlocatie waar de eerste pixel van de afbeelding zich bevindt.

            for (int y = 0; y < HeightInPixels; y++) {
                //Bepaal de schrijflijn
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp) {
                    currentLine[x] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 1] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 2] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 3] = (byte)255;
                }
            }

            //Plaats de bewerkte BitmapData terug in de afbeelding
            b.UnlockBits(bitmapData);
            return resize(b, 256, 256);
        }

        /// <summary>
        /// Voer de voorwaardse FFT uit op de grijswaarden-afbeelding
        /// </summary>
        /// <param name="scale1">De herschaling van de Amplitude plot</param>
        /// <param name="scale2">De herschaling van de Fase plot</param>
        /// <param name="shift">true, normaliseren; false, niet aanpassen</param>
        public void performFFT(int scale1, int scale2, bool shift) {
            Object[] returnVar = Fourier.forwardFFT(greyPixelArray, shift, scale1, scale2);

            fourierResult = (ComplexGetal[,])returnVar[0];
            modPlot = (Bitmap)returnVar[1];
            argPlot = (Bitmap)returnVar[2];
        }

        /// <summary>
        /// Geeft de Amplitude plot terug
        /// </summary>
        public Bitmap getModPlot() {
            return resize(modPlot, 256, 256);
        }

        /// <summary>
        /// Geeft de Fase plot terug
        /// </summary>
        public Bitmap getArgPlot() {
            return resize(argPlot, 256, 256);
        }

        /// <summary>
        /// Voert de achterwaardse FFT uit 
        /// </summary>
        /// <returns>De gegenereerde afbeelding, herschaald naar 256x256 om aan de gebruiker te tonen</returns>
        public Bitmap reverseFFT() {
            revPlot = Fourier.backwardFFT(fourierResult);
            return resize(revPlot, 256, 256);
        }

#endregion public

        #region private

        /// <summary>
        /// Maakt een pixel array van de grijswaarden-afbeelding
        /// </summary>
        private unsafe void generateGrayScaleArray() {
            greyPixelArray = new int[original.Height, original.Width];

            BitmapData bitmapData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(original.PixelFormat) / 8; //Het aantals bytes per pixel (bits per pixel / 8)
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0; //De pointer naar de geheugenlocatie waar de eerste pixel van de afbeelding zich bevindt.

            for (int y = 0; y < HeightInPixels; y++) {
                //Bepaal de schrijflijn
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp) {
                    greyPixelArray[y, x / bpp] = (currentLine[x] + currentLine[x + 1] + currentLine[x + 2]) / 3;
                }
            }

            //Plaats de bewerkte BitmapData terug in de afbeelding
            original.UnlockBits(bitmapData);
        }

        /// <summary>
        /// Cuts out a pixel range of the given Bitmap that has dimensions which are a power of 2.
        /// </summary>
        /// <param name="b">The input Bitmap</param>
        /// <returns>A piece out of the input Bitmap</returns>
        private Bitmap CutOut(Bitmap b) {
            int var = (b.Width > b.Height ? b.Height : b.Width);

            // Gebaseerd op http://graphics.stanford.edu/~seander/bithacks.html
            if ((var & (var - 1)) == 0) { // is var een macht van 2?

            }
            else { // Bereken de grootst mogelijke macht van 2 die kleiner is dan var
                var--;
                var |= var >> 1;
                var |= var >> 2;
                var |= var >> 4;
                var |= var >> 8;
                var |= var >> 16;
                var++;
                var /= 2;
            }

            return resize(b, var, var);
        }

        /// <summary>
        /// Deze methode zal een afbeelding schalen met zo weinig mogelijk kwaliteitsverlies
        /// </summary>
        /// <param name="image">De originele afbeelding</param>
        /// <param name="w">De gewenste breedte</param>
        /// <param name="h">De gewenste hoogte</param>
        /// <returns>De aangepeste afbeelding</returns>
        private Bitmap resize(Bitmap image, int w, int h) {
            var destRect = new Rectangle(0, 0, w, h);
            var destImage = new Bitmap(w, h);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion private

    }
}
