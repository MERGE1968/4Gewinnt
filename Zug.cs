using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win4Gewinnt
{
    public class Zug
    {
        public int Farbe { get; set; } = 0;
        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public int Gesamt { get; set; } = 0;

        public int DiagRechtsHoch { get; set; } = 0;

        public int Rechts { get; set; } = 0;

        public int DiagRechtsRunter { get; set; } = 0;

        public int Runter { get; set; } = 0;

        public int Links { get; set; } = 0;

        public int DiagLinksRunter { get; set; } = 0;

        public int DiagLinksHoch { get; set; } = 0;


        public string GetValueAsString()
        {
            string result;
            result = " Farbe               : " + ((Farbe > 0) ? "ROT" : "GELB") + Environment.NewLine +
                     " X/Y                 : " + X.ToString() + "/" + Y.ToString() + Environment.NewLine +
                     " DiagRechtsHoch      : " + DiagRechtsHoch.ToString() + Environment.NewLine +
                     " Rechts              : " + Rechts.ToString() + Environment.NewLine +
                     " DiagRechtsRunter    : " + DiagRechtsRunter.ToString() + Environment.NewLine +
                     " Runter              : " + Runter.ToString() + Environment.NewLine +
                     " DiagLinksRunter     : " + DiagLinksRunter.ToString() + Environment.NewLine +
                     " Links               : " + Links.ToString() + Environment.NewLine +
                     " DiagLinksHoch       : " + DiagLinksHoch.ToString() + Environment.NewLine +
                     " Gesamt (Waagerecht) : " + (Links + Rechts).ToString() + Environment.NewLine +
                    @" Gesamt (Diagonal-\) : " + (DiagLinksHoch + DiagRechtsRunter).ToString() + Environment.NewLine +
                    @" Gesamt (Diagonal-/) : " + (DiagLinksRunter + DiagRechtsHoch).ToString() + Environment.NewLine +
                     " Gesamt (Senkrecht)  : " + Runter.ToString() + Environment.NewLine +
                     " GESAMT              : " + Gesamt.ToString() + Environment.NewLine + Environment.NewLine;

            return result;
        }//END
    }
}
