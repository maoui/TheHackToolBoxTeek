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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Charset
{
    class Special : Pattern
    {                

        public List<string> ListHexa(string charsetName)
        {
            if (charsetName == "hex-lower")
            {
                //hex-lower
                CharsetSelecting = Numeric.Concat(HexLower).ToList();                
            }
            else if (charsetName == "hex-upper")
            {
                //hex-upper 
                CharsetSelecting = Numeric.Concat(HexUpper).ToList();
            }
            
            return CharsetSelecting;
        }

        public List<string> ListNumeric(string charsetName)
        {
            if (charsetName == "numeric")
            {
                //numeric
                CharsetSelecting = Numeric;
            }
            else if (charsetName == "numeric-space")
            {
                //numeric-space
                CharsetSelecting = Numeric.Concat(Space).ToList();
            }
            
            return CharsetSelecting;
        }

        public List<string> ListSymbols(string charsetName)
        {
            if (charsetName == "symbols14")
            {
                //symbols14  
                CharsetSelecting = Symbols14;                
            }
            else if (charsetName == "symbols14-space")
            {
                //symbols14-space
                CharsetSelecting = Symbols14.Concat(Space).ToList();                
            }
            else if (charsetName == "symbols-all")
            {
                //symbols-all
                CharsetSelecting = Symbols14.Concat(SymbolsAll).ToList();                
            }
            else if (charsetName == "symbols-all-space")
            {
                //symbols-all-space
                CharsetSelecting = Symbols14.Concat(SymbolsAll).Concat(Space).ToList();
            }           

            return CharsetSelecting;
        }
    }
}
