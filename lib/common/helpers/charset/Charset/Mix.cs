using System.Collections.Generic;
using System.Linq;

namespace ASCII
{
    class Mix : Pattern
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public List<string> MixListToTwo(List<string> list1, List<string> list2)
        {
            Validated = false;
            return CharsetSelecting = list1.Concat(list2).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        /// <returns></returns>
        public List<string> MixListToThree(List<string> list1, List<string> list2, List<string> list3)
        {
            Validated = false;
            return CharsetSelecting = list1.Concat(list2).Concat(list3).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        /// <param name="list4"></param>
        /// <returns></returns>

        public List<string> MixListToFour(List<string> list1, List<string> list2, List<string> list3, List<string> list4)
        {
            Validated = false;
            return CharsetSelecting = list1.Concat(list2).Concat(list3).Concat(list4).ToList();
        }
    }
}
