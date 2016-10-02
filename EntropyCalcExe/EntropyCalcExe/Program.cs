using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*
 * Entropy Calculator rough draft
 * Coded by Teeknofil from the YouTube channel salmoneus
 * should only be used with PE files 
 */

namespace EntropyCalcExe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = args[0];
                Console.Write("Sal's Entropy Calculator\n\n\n");
                byte[] b = File.ReadAllBytes(s);
                double a = entropyA(b, b.Length);
                double _B = entropyB(b, b.Length);
                double t = (a * _B);
                shift(ref t, _B);
                Console.Write("\tTotal File Length : {0} Bytes \n\tEntropy Level : {1}\n\tPacked: {2}\n\tTr.Dropper : {3}", b.Length, t, pack(t), dropper(t));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static string pack(double t)
        {
            string s = "Not Packed";

            s = t >= 6.5 ? s = "Could be packed !" : s;
            s = t >= 6.8 ? s = "Most likely packed !" : s;
            s = t >= 7.175 ? s = "Packed and/or encrypted !" : s;
            s = t >= 7.3 ? s = "99.9 % Sure of encryption and/or packing !" : s;

            return s;
        }

        static string dropper(double t)
        {
            string s = "Nope !";
            s = t >= 7.5 ? s = "Yes" : s;
            return s;
        }

        static void shift(ref double t, double b)
        {
            t = t <= 5 ? (t + 2) : t;
            t = (t >= 5) & (t <= 5.5) ? (t + (.33 * b)) : t;
            t = t >= 5 ? (t + (.13 * b)) : t;
            t = t >= 5.5 ? (t + (.15 * b)) : t;
            t = t >= 6 ? (t + (.19 * b)) : t;
            t = t >= 6.5 ? (t + (.20 * b)) : t;
            t = t >= 7 ? (t + (.205 * b)) : t;
            t = t >= 7.5 ? (t + (.22 * b)) : t;
            t = t >= 8 ? t = 7.99 : t;
        }

        static double entropyA(byte[] b, int l)
        {
            int e = 0;
            byte[] b2 = new byte[256];
            for (int j = 0; j < l; j++)            
                b2[b[j]]++;            

            for (int j2 = 0; j2 < 256; j2++)            
                if(b2[j2] > 1)
                   e -= m(b2[j2], b2[j2]);

            e /= l >> 5; 
            e += m(l, 32);

            if (e > 255)
                e = 255;
            return e;
        }

        static double entropyB(byte [] b , int l)
        {
            int[] b_c = new int[256];
            for (int i = 0; i < l; i++)
                b_c[b[i]]++;
            double h = 0.0;
             
            for (int i = 0; i < 256; i++)
            {
                double p_i = (double)b_c[i] / l;
                if (p_i > 0.0)
                    h -= p_i * ((double)Math.Log(p_i) / (double)Math.Log((double)l));
            }

            return h;
        }


        static int m (int x,  int y)
        {
            int r = 0, f = 0, n = 0;

            while (x >= 2)
            {
                f = ((f >> 1) | ((x & 1) << 31));
                r++; n++; x >>= 1;
            }

            if (n == 0)
            {
                if (++n > 16)
                {
                    n = 16;
                }

                f = ((f >> 1 | 8) >> (32 - n));
                r *= y;

                while( y > 1)
                {
                    f *= f; f >>= n; y >>= 1;
                    if ((f >> ( --n - 1)) >= 2)
                    {
                        r += y; f >>= 1;
                    }
                }
            }

            return r;
        }
    }


}
