using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier_Transformatie.Fourier {
    public class ComplexGetal {
        private float reëel, imaginair;

        public ComplexGetal(float reëel, float imaginair) {
            this.reëel = reëel;
            this.imaginair = imaginair;
        }

        public float Reëel {
            get { return reëel; }
            set { reëel = value; }
        }

        public float Imaginair {
            get { return imaginair; }
            set { imaginair = value; }
        }

        public float Modulus {
            get {
                // http://nl.wikipedia.org/wiki/Complex_getal#Gerelateerde_waarden
                return (float)(Math.Sqrt(reëel * reëel + imaginair * imaginair));
            }
        }

        public float Argument {
            get {
                // http://nl.wikipedia.org/wiki/Argument_(complex_getal)
                // return ((float)Math.Atan(imaginair / reëel));
                return (float)Math.Atan2(imaginair, reëel);
            }
        }
    }
}
