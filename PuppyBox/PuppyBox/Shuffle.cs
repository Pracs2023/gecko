using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBox
{
    public class Shuffle
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public enum DirectionEnum
        {
            ClockWise,
            AntiClockWise
        }
        public Shuffle(int SpeedLevel)
        {
            FromIndex = -1;
            ToIndex = -1;
            while(FromIndex ==-1 || 
                ToIndex ==-1 ||
                FromIndex >= ToIndex )
            {
                FromIndex = GetRandomNumber(0, 3);
                ToIndex = GetRandomNumber(0, 3);

            }
            Direction = DirectionEnum.AntiClockWise;
            if(GetRandomNumber(1, 3)==1)
            {
                Direction = DirectionEnum.ClockWise;
            }
            this.SpeedLevel = SpeedLevel;
        }
        public int FromIndex { get; private set; }
        public int ToIndex { get; private set; }
        public DirectionEnum Direction { get;  set; } 
        public int SpeedLevel { get; private set; }

    }
}
