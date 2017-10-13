//  Author:
//       Teeknofil <teeknofil.dev@gmail.com>
//
//  Copyright (c) 2015 Teeknofil
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Linq;

namespace Charset
{
    public class Alpha : Pattern
    {
        public List<string> Lalpha_List(string charsetName)
        {
            if (charsetName == "lalpha")
            {
                // lalpha
                CharsetSelecting = Lalpha.ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-space")
            {
                // lalpha_space
                CharsetSelecting = Lalpha.Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric")
            {
                // lalpha-numeric
                CharsetSelecting = Lalpha.Concat(Numeric).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric-space")
            {
                // lalpha-numeric-space
                CharsetSelecting = Lalpha.Concat(Numeric).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric-symbol14")
            {
                //lalpha-numeric-symbol14
                CharsetSelecting = Lalpha.Concat(Numeric).Concat(Symbols14).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric-symbol14-space")
            {
                // lalpha-numeric-symbol14-space
                CharsetSelecting = Lalpha.Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric-all")
            {
                // lalpha-numeric-all
                CharsetSelecting = Lalpha.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "lalpha-numeric-all-space")
            {
                // lalpha-numeric-all-space
                CharsetSelecting = Lalpha.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
                Validated = false;
            }            

            return CharsetSelecting;
        }



        public List<string> Ualpha_List(string charsetName)
        {
            if (charsetName == "ualpha")
            {
                //ualpha
                CharsetSelecting = Ualpha;
                Validated = false;
            }
            else if (charsetName == "ualpha-space")
            {
                //ualpha-space
                CharsetSelecting = Ualpha.Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric")
            {
                //ualpha-numeric
                CharsetSelecting = Ualpha.Concat(Numeric).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric-space")
            {
                //ualpha_numeric_space
                CharsetSelecting = Ualpha.Concat(Numeric).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric-symbol14")
            {
                // ualpha_numeric_symbol14
                CharsetSelecting = Ualpha.Concat(Numeric).Concat(Symbols14).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric-symbol14-space")
            {
                //ualpha_numeric-symbol14-space
                CharsetSelecting = Ualpha.Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric-all")
            {
                //ualpha-numeric-all
                CharsetSelecting = Ualpha.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "ualpha-numeric-all-space")
            {
                //ualpha-numeric-all-space
                CharsetSelecting = Ualpha.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
                Validated = false;
            }
            else
            {
                Validated = true;
            }

            return CharsetSelecting;
        }


        public List<string> MixAlphaList(string charsetName)
        {

            if (charsetName == "mixalpha")
            {
                //mixalpha
                CharsetSelecting = Lalpha.Concat(Ualpha).ToList();
                Validated = false;
            }
            else if (charsetName == "mixalpha-space")
            {
                //mixalpha-space
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Space).ToList();
                Validated = false;

            }
            else if (charsetName == "mixalpha-numeric")
            {
                //mixalpha-numeric
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).ToList();
                Validated = false;

            }
            else if (charsetName == "mixalpha-numeric-space")
            {
                //mixalpha-numeric-space
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).Concat(Space).ToList();
                Validated = false;

            }
            else if (charsetName == "mixalpha-numeric-symbol14")
            {
                //mixalpha-numeric-symbol14
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).Concat(Symbols14).ToList();
                Validated = false;

            }
            else if (charsetName == "mixalpha-numeric-symbol14-space")
            {
                //mixalpha-numeric-symbol14-space
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "mixalpha-numeric-all")
            {
                // mixalpha-numeric-all
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "mixalpha-numeric-all-space")
            {
                // mixalpha-numeric-all-space
                CharsetSelecting = Lalpha.Concat(Ualpha).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
                Validated = false;
            }
            else
            {
                Validated = true;
            }


            return CharsetSelecting;
        }
    }
}
