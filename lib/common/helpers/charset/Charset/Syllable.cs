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

namespace ASCII
{
    class Syllable : Pattern
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charsetName"></param>
        /// <returns></returns>
        
        public List<string> SyllableLowercaseFr(string charsetName)
        {
            if (charsetName == "lsyllable-fr")
            {
                //syllable
                CharsetSelecting = SyllableFr;
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-space")
            {
                //lsyllable-space
                CharsetSelecting = SyllableFr.Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric")
            {
                // lsyllable-numeric
                CharsetSelecting = SyllableFr.Concat(Digits).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric-space")
            {
                // lsyllable-numeric-space
                CharsetSelecting = SyllableFr.Concat(Digits).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric-symbol14")
            {
                //lsyllable - numeric - symbol14
                CharsetSelecting = SyllableFr.Concat(Digits).Concat(Symbols14).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric-symbol14-space")
            {
                // lsyllable-numeric-symbol14-space
               CharsetSelecting = SyllableFr.Concat(Digits).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric-all")
            {
                //lsyllable-numeric-all
                CharsetSelecting = SyllableFr.Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "lsyllable-fr-numeric-all-space")
            {
                //lsyllable-numeric-all-space
                CharsetSelecting = SyllableFr.Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
                Validated = false;
            }
            else
            {
                Validated = true;
            }

            return CharsetSelecting;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="charsetName"></param>
        /// <returns></returns>
         

        public List<string> SyllableUppercaseFr(string charsetName)
        {
            if (charsetName == "usyllable-fr")
            {
                //usyllable
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper());
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-space")
            {
                //usyllable-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric")
            {
                //usyllable-numeric
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric-space")
            {
                //usyllable-numeric-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric-symbol14")
            {
                //usyllable-numeric-symbol14
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).Concat(Symbols14).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric-symbol14-space")
            {
                //usyllable_numeric-symbol14-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric-all")
            {
                //usyllable-numeric-all
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "usyllable-fr-numeric-all-space")
            {
                //usyllable-numeric-all-space
                CharsetSelecting = SyllableFr.ConvertAll(item => item.ToUpper()).Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
                Validated = false;
            }
            else
            {
                Validated = true;
            }
            return CharsetSelecting;
        }

        public List<string> MixSyllableFr(string charsetName)
        {
            if (charsetName == "mixsyllable-fr")
            {
                //mixsyllable
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-space")
            {
                //mixsyllable-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric")
            {
                //mixsyllable-numeric
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric-space")
            {
                //mixsyllable-numeric-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric-symbol14")
            {
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).Concat(Symbols14).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric-symbol14-space")
            {
                // mixsyllable-numeric-symbol14-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).Concat(Symbols14).Concat(Space).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric-all")
            {
                //mixsyllable-numeric-all
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).ToList();
                Validated = false;
            }
            else if (charsetName == "mixsyllable-fr-numeric-all-space")
            {
                //mixsyllable-numeric-all-space
                CharsetSelecting = SyllableFr.Concat(SyllableFr.ConvertAll(item => item.ToUpper())).Concat(Digits).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();
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

