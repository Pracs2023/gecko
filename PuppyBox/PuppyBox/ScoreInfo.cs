using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppyBox.Utility;
namespace PuppyBox
{
    [Serializable]
    public class ScoreInfo
    {
        public int Score { get; set; }
        public String Name { get; set; }
        public int Rank { get; set; }
        public ScoreInfo(int Rank, String Name, int Score)
        {
            this.Rank = Rank;
            this.Name = Name;
            this.Score = Score;

        }
    }

    [Serializable]
    public class ScoreInfos
    {
        public List<ScoreInfo> listScoreInfo = null;
        public string PreviousName = "";
    }

    public class ScoreHelper
    {
        private static ScoreInfos _scoreInfos = null;
        public static ScoreInfos scoreInfos
        {
            get
            {
                if(_scoreInfos ==null)
                {
                    _scoreInfos = LoadScoreInfo(FileUtility.ScoreFilePath);
                }
                return _scoreInfos;
            }
        }
        public static ScoreInfos LoadScoreInfo(String fileName)
        {
            if (!FileUtility.IsFileExist(fileName))
            {
                SerializeUtility.CreateNewScoreFile(fileName);
            }
            return (ScoreInfos ) SerializeUtility.DeserializeScore(fileName);
        }
        public static  int CalculateNewRankFromScore(int Score)
        {
            int PlayerNewRank = int.MaxValue;

            if (Score > -1)
            {
                int i;
                //for(i=scoreInfos.listScoreInfo.Count -1;i>=0;i--)
                for (i = 0; i < scoreInfos.listScoreInfo.Count; i++)
                {
                    if (scoreInfos.listScoreInfo[i].Score < Score)
                    {
                        PlayerNewRank = scoreInfos.listScoreInfo[i].Rank;
                        break;
                    }
                }

            }
            return PlayerNewRank;
        }
        public static void InsertNewRank(String Name, int Score)
        {
            
            scoreInfos.listScoreInfo.Add(new ScoreInfo(-1, Name, Score));
            List<ScoreInfo> SortedList = scoreInfos.listScoreInfo.OrderByDescending(o => o.Score).Take (10).ToList();
            int i;
            for(i=0;i<10;i++)
            {
                SortedList[i].Rank = (i + 1);
            }

            scoreInfos.listScoreInfo = SortedList;

            //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
        }
        public static void Save()
        {
            SerializeUtility.SerializeScoreInfos(_scoreInfos, FileUtility.ScoreFilePath);
        }

    }

}
