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
    class AlphaSv : Pattern
    {
        
        public List<string> Lalpha_svList(string charsetName)
        {

            if (charsetName == "sv-lalpha")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).ToList();               
            }
            else if (charsetName == "sv-lalpha-space")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Space).ToList();                
            }
            else if (charsetName == "sv-lalpha-numeric")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).ToList();                

            }
            else if (charsetName == "sv-lalpha-numeric-space")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).Concat(Space).ToList();
                
            }
            else if (charsetName == "sv-lalpha-numeric-symbol14")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).Concat(Symbols14).ToList();
                
            }
            else if (charsetName == "sv-lalpha-numeric-symbol14-space")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();
                
            }
            else if (charsetName == "sv-lalpha-numeric-all")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();
                
            }
            else if (charsetName == "sv-lalpha-numeric-all-space")
            {
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();                    
               
            }
            
            return CharsetSelecting;
        }

        public  List<string> Ualpha_svList(string charsetName)
        {

            if (charsetName == "sv-ualpha")
            {
                //ualpha-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).ToList();
            }
            else if (charsetName == "sv-ualpha-space")
            {
                //ualpha-space-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Space).ToList();
                
            }
            else if (charsetName == "sv-ualpha-numeric")
            {
                //ualpha-numeric-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).ToList();

            }
            else if (charsetName == "sv-ualpha-numeric-space")
            {
                //ualpha-numeric-space-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).Concat(Space).ToList();

            }
            else if (charsetName == "sv-ualpha-numeric-symbol14")
            {
                //ualpha-numeric-symbol14-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).ToList();

            }
            else if (charsetName == "sv-ualpha-numeric-symbol14-space")
            {
                //ualpha-numeric-symbol14-space-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();

            }
            else if (charsetName == "sv-ualpha-numeric-all")
            {
                //ualpha-numeric-all-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();

            }
            else if (charsetName == "sv-ualpha-numeric-all-space")
            {
                //ualpha-numeric-all-space-sv
                CharsetSelecting = Ualpha.Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();

            }
           
            return CharsetSelecting;
        }



        public List<string> MixAlpha_svList(string charsetName)
        {

            if (charsetName == "sv-mixalpha")
            {
                //mixalpha-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).ToList();

            }
            else if (charsetName == "sv-mixalpha-space")
            {
                //mixalpha-space-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Space).ToList();

            }
            else if (charsetName == "sv-mixalpha-numeric")
            {
                // mixalpha-numeric-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).ToList();
            }
            else if (charsetName == "sv-mixalpha-numeric-space")
            {
                //mixalpha-numeric-space_sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).Concat(Space).ToList();

            }
            else if (charsetName == "sv-mixalpha-numeric-symbol14")
            {
                //mixalpha-numeric-symbol14-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).ToList();

            }
            else if (charsetName == "sv-mixalpha-numeric-symbol14-space")
            {
                //mixalpha-numeric-symbol14-space-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(Space).ToList();

            }
            else if (charsetName == "sv-mixalpha-numeric-all")
            {
                //mixalpha-numeric-all-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).ToList();

            }
            else if (charsetName == "sv-mixalpha-numeric-all-space")
            {
                //mixalpha-numeric-all-space-sv
                CharsetSelecting = Lalpha.Concat(Lalpha_sv).Concat(Ualpha).Concat(UalphaSv).Concat(Numeric).Concat(Symbols14).Concat(SymbolsAll).Concat(Space).ToList();

            }
            
            return CharsetSelecting;

        }
    }
}
