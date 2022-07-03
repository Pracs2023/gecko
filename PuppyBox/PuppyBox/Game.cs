using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBox
{
    public class Game
    {

        public enum GameStateEnum
        {
            Start,
            Shuffling,
            WaitForUserToOpenBox,
            WaitForUserToClosBox,
            End
        }
        public GameStateEnum GameState { get; set; }

        public int Score { get; private set; }
        public Game()
        {
            New();
        }
        private int MaxStage = 15;
        public void New()
        {
            ExplicitConstructor();
        }
        private void ExplicitConstructor()
        {
            Score = 0;
            Stage = 1;
            listShuffle = ShuffleFactory.CreateShuffle(2, Stage );
        }
        public void New(int pMaxStage)
        {
            MaxStage = pMaxStage;
            ExplicitConstructor();
        }
        public int Stage { get; private set; }

        public List<Shuffle> listShuffle = null;
        public void GuessCorrect()
        {
            UpdateScore();
            if(Stage >= MaxStage)
            {
                this.GameState = GameStateEnum.End;
                return;
            }
            
            IncreaseLevel();
            PrepareNextStage();
            
        }

        private void PrepareNextStage()
        {
            listShuffle = ShuffleFactory.CreateShuffle(NumberofShuffle, SpeedLevel);
            this.GameState = GameStateEnum.WaitForUserToClosBox;
        }
        public void GuessWrong()
        {
            if (Stage >= MaxStage)
            {
                this.GameState = GameStateEnum.End;
                return;
            }
            IncreaseLevel();
            PrepareNextStage();
        }
        private void IncreaseLevel()
        {
            Stage++;
        }
        public int SpeedLevel
        {
            get
            {
                if (Stage > 10)
                {
                    return 8;
                }
                if (Stage > 6)
                {
                    return 7;
                }
                return Stage;
            }
        }
        private int NumberofShuffle
        {
            get
            {
                int _NumberofShuffle = 3;
                if(Stage > 10)
                {
                    _NumberofShuffle = 7;
                }
                if (Stage > 7)
                {
                    _NumberofShuffle = 6;
                }
                else if (Stage > 5)
                {
                    _NumberofShuffle = 5;
                }
                else if (Stage > 3)
                {
                    _NumberofShuffle = 4;
                }
                return _NumberofShuffle;
            }
        }
        private void UpdateScore()
        {
            Score += Stage  * 10;
        }



    }
}
