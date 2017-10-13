using System.Collections.Generic;
using System.Linq;

namespace Charset
{
    class Mix : Pattern
    {
        public List<string> MixLetters(string charsetName)
        {
            
            if (charsetName == "mix")
            {
                // mixalpha-sv-mixalpha-mixcyrillic-mixsyllableFR
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).ToList().Concat(Cyrillic).Concat(Cyrillic.ConvertAll(item => item.ToUpper())).Concat(SyllableFr).Concat(SyllableFr.ConvertAll(item => item.ToUpper())).ToList();
                Validated = false;
            }
            else if (charsetName == "hex-letters-lower")
            {
                //hex-lower
                CharsetSelecting = HexLower.ToList();
                Validated = false;
            }
            else if (charsetName == "hex-letters-upper")
            {
                //hex-upper 
                CharsetSelecting = HexUpper.ToList();
                Validated = false;
            }
            else if (charsetName == "hexa-letters-mix")
            {
                //hex-upper 
                CharsetSelecting = HexLower.Concat(HexUpper).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha")
            {
                // lalpha
                CharsetSelecting = Lalpha.ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha")
            {
                //ualpha
                CharsetSelecting = Ualpha;
                Validated = false;
            }
            else if (charsetName == "mixalpha")
            {
                //mixalpha
                CharsetSelecting = Lalpha.Concat(Ualpha).ToList();
                Validated = false;
            }
            else if (charsetName == "sv-lalpha")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).ToList();
            }
            else if (charsetName == "sv-ualpha")
            {
                //ualpha-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).ToList();
            }
            else if (charsetName == "sv-mixalpha")
            {
                //mixalpha-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).ToList();

            }
            else if (charsetName == "lcyrillic")
            {
                //lcyrillic
                CharsetSelecting = Cyrillic.ToList();

            }
            else if (charsetName == "mixcyrillic")
            {
                //mixcyrillic
                CharsetSelecting = Cyrillic.Concat(Cyrillic.ConvertAll(item => item.ToUpper())).ToList();

            }
            else if (charsetName == "lsyllable")
            {
                //syllable
                CharsetSelecting = SyllableFr;
            }
            else if (charsetName == "usyllable")
            {
                //usyllable
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper());
            }
            else if (charsetName == "mixsyllable")
            {
                //mixsyllableFR
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).ToList();
            }

            return CharsetSelecting;
        }
    }
}
