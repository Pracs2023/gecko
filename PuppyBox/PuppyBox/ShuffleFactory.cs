using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBox
{
    public class ShuffleFactory
    {
        public static  List<Shuffle> CreateShuffle(int NumberofShuffle, int SpeedLevel)
        {
            int i;
            List<Shuffle> listResult = new List<Shuffle>();
            for(i=0;i<NumberofShuffle;i++)
            {
                Shuffle shu = new Shuffle(SpeedLevel );
                listResult.Add(shu);
            }
            return listResult;
        }
    }
}
