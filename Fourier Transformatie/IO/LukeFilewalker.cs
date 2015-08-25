using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Fourier_Transformatie.IO {
    /// <summary>
    /// Deze klasse bevat methoden om een afbeelding te lezen en te schrijven
    /// </summary>
    static class LukeFilewalker {

        /// <summary>
        /// Lees een afbeelding in van een bepaalde locatie
        /// </summary>
        /// <param name="location">De afbeeldingslocatie</param>
        /// <returns>De opgehaalde afbeelding</returns>
        static public Bitmap readFromLocation(string location) {
            using (FileStream fr = new FileStream(location, FileMode.Open, FileAccess.Read)) {
                return (Bitmap)Bitmap.FromStream(fr);
            }
        }

        /// <summary>
        /// Schrijf een afbeelding weg naar een bepaalde locatie
        /// </summary>
        /// <param name="location">De gewenste afbeeldingslocatie</param>
        /// <param name="b">De afbeelding</param>
        /// <param name="f">Het gewenste afbeeldingstype</param>
        static public void writeToLocation(string location, Bitmap b, System.Drawing.Imaging.ImageFormat f) {
            using (FileStream fw = new FileStream(location, FileMode.Create, FileAccess.Write)) {
                b.Save(fw, f);
            }
        }

        static public void dumpValues(string location) {

        }
    }
}
