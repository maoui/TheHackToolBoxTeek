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
    class Syllable : Pattern
    {
        public List<string> ListSyllableLowerCase_fr(string charsetName)
        {
            if (charsetName == "lsyllable")
            {
                //syllable
                CharsetSelecting = SyllableFr;
            }
            else if (charsetName == "lsyllable-space")
            {
                //lsyllable-space
                CharsetSelecting = SyllableFr.Concat(Space).ToList();
            }
            else if (charsetName == "lsyllable-numeric")
            {
                // lsyllable-numeric
                CharsetSelecting = SyllableFr.Concat(Numeric).ToList();
            }
            else if (charsetName == "lsyllable-numeric-space")
            {
                // lsyllable-numeric-space
                CharsetSelecting = SyllableFr.Concat(Numeric).Concat(Space).ToList();
           }
            else if (charsetName == "lsyllable-numeric-symbol14")
            {
                //lsyllable - numeric - symbol14
                CharsetSelecting = SyllableFr.Concat(Numeric).Concat(Symbols14).ToList();
            }
            else if (charsetName == "lsyllable-numeric-symbol14-space")
            {
                // lsyllable-numeric-symbol14-space
               CharsetSelecting = SyllableFr.Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
            }
            else if (charsetName == "lsyllable-numeric-all")
            {
                //lsyllable-numeric-all
                CharsetSelecting = SyllableFr.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
            }
            else if (charsetName == "lsyllable-numeric-all-space")
            {
                //lsyllable-numeric-all-space
                CharsetSelecting = SyllableFr.Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
            }
            
            return CharsetSelecting;
        }

        public List<string> ListSyllableUpperCase_fr(string charsetName)
        {
            if (charsetName == "usyllable")
            {
                //usyllable
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper());
            }
            else if (charsetName == "usyllable-space")
            {
                //usyllable-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Space).ToList();
            }
            else if (charsetName == "usyllable-numeric")
            {
                //usyllable-numeric
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).ToList();
            }
            else if (charsetName == "usyllable-numeric-space")
            {
                //usyllable-numeric-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).Concat(Space).ToList();
            }
            else if (charsetName == "usyllable-numeric-symbol14")
            {
                //usyllable-numeric-symbol14
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).Concat(Symbols14).ToList();
            }
            else if (charsetName == "usyllable-numeric-symbol14-space")
            {
                //usyllable_numeric-symbol14-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
            }
            else if (charsetName == "usyllable-numeric-all")
            {
                //usyllable-numeric-all
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
            }
            else if (charsetName == "usyllable-numeric-all-space")
            {
                //usyllable-numeric-all-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
            }
            
            return CharsetSelecting;
        }

        public List<string> ListMixsyllable_fr(string charsetName)
        {
            if (charsetName == "mixsyllable")
            {
                //mixsyllable
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).ToList();
            }
            else if (charsetName == "mixsyllable-space")
            {
                //mixsyllable-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Space).ToList();
            }
            else if (charsetName == "mixsyllable-numeric")
            {
                //mixsyllable-numeric
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).ToList();
            }
            else if (charsetName == "mixsyllable-numeric-space")
            {
                //mixsyllable-numeric-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).Concat(Space).ToList();
            }
            else if (charsetName == "mixsyllable-numeric-symbol14")
            {
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).Concat(Symbols14).ToList();
            }
            else if (charsetName == "mixsyllable-numeric-symbol14-space")
            {
                // mixsyllable-numeric-symbol14-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
            }
            else if (charsetName == "mixsyllable-numeric-all")
            {
                //mixsyllable-numeric-all
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
            }
            else if (charsetName == "mixsyllable-numeric-all-space")
            {
                //mixsyllable-numeric-all-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
            }
            
            return CharsetSelecting;
        }
    }
}
