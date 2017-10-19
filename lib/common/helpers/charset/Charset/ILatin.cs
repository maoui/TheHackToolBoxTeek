using ASCII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public interface ILatin
    {
        List<string> LatinAlphaLowercase(string charsetName);
        List<string> LatinAlphaUppercase(string charsetName);
        List<string> LatinAlpha(string charsetName);


    }
}
