using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PuppyBox.Shuffle;

namespace PuppyBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Box> boxs = new List<Box>();
        List<Point> listPositionBox = new List<Point>();

        Dictionary<int, int> DictionaryPositionToBoxIndex = new Dictionary<int, int>();
        int TopPosition =50;
        int NormalTopPosition = 200;
        int BottopPosition = 350;

        private void RefreshUI()
        {
            this.pictureBox1.Refresh();

            if (game != null)
            {
                this.lblStage.Text = "Stage: " + game.Stage.ToString();
                this.lblSpeed.Text = "Speed: " + game.SpeedLevel.ToString();
                this.lblScore.Text = "Score: " + game.Score.ToString();

                
            } else
            {
                this.lblStage.Text = "Stage: 1";
                this.lblSpeed.Text = "Speed: 1";
                this.lblScore.Text = "Score: 0";

            }



        }

        Game game=null;

      
        Boolean IsAcceptInput = true;
        private void CheckIfPlayerNeedtoEnterNameIncaseofHighScore()
        {
            if (game.GameState == Game.GameStateEnum.End)
            {
                int NewRank = ScoreHelper.CalculateNewRankFromScore(game.Score);
                if (NewRank <= 10)
                {
                    FormScore f = new FormScore();
                    f.PlayerCurrentScore = game.Score;
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();
                    return;
                }

                MessageBox.Show("Your score is " + game.Score.ToString());
            }
        }
        private void Box_Click(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            // MessageBox.Show("Test Click");
            if(!IsAcceptInput )
            {
                return;
            }
            if (!IsCurrentTimeCloseToTheTimePictureBoxMouseDown)
            {
                return;
            }
            if(game.GameState != Game.GameStateEnum.WaitForUserToOpenBox &&
                game.GameState != Game.GameStateEnum.WaitForUserToClosBox)
            {
                return;
            }

            BlockInput();
            try
            {
                Box box = (Box)sender;
                if (game.GameState == Game.GameStateEnum.WaitForUserToOpenBox)
                {
                    if (box.IsDog)
                    {
                        game.GuessCorrect();

                    }
                    else
                    {
                        game.GuessWrong();
                    }
                    OpenBox(box.BoxIndex);
                    OpenAllExcept(box.BoxIndex);

                    //  box.IsReveal = !box.IsReveal;
                    
                    this.RefreshUI();
                    CheckIfPlayerNeedtoEnterNameIncaseofHighScore();
                   
                }
                else if (game.GameState == Game.GameStateEnum.WaitForUserToClosBox)
                {

                    ClosAll();
                    ShuffleBox();
                    this.RefreshUI();

                }
            }
            finally
            {
                UnBlockInput();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            boxs.ForEach(x => x.Draw(e.Graphics));
        }
        private void DoShuffleBox(Shuffle shu)
        {
            DoShuffleBox(shu.Direction, shu.FromIndex, shu.ToIndex, shu.SpeedLevel);
        }
        private void ShuffleBoxPosition(int From,int To)
        {
            int IndexFrom = DictionaryPositionToBoxIndex[From];
            int IndexTo = DictionaryPositionToBoxIndex[To];
            DictionaryPositionToBoxIndex[From] = IndexTo;
            DictionaryPositionToBoxIndex[To] = IndexFrom;
        }
        private void DoShuffleBox(DirectionEnum Direction, int From,int To, int SpeedLevel)
        {
            Box boxFrom = null;
            Box boxTo = null;
            int IndexFrom = DictionaryPositionToBoxIndex[From];
            int IndexTo = DictionaryPositionToBoxIndex[To];


            boxFrom = boxs[IndexFrom];
            boxTo = boxs[IndexTo];
            
            if (Direction == DirectionEnum.ClockWise)
            {
                while (boxFrom.Top > TopPosition)
                {
                    boxFrom.Top -= SpeedLevel;
                    boxTo.Top += SpeedLevel;
                    pictureBox1.Refresh();

                }
                while (boxFrom.Left < listPositionBox [To].X)
                {
                    boxFrom.Left += SpeedLevel;
                    boxTo.Left -= SpeedLevel;
                    pictureBox1.Refresh();
                }
                while (boxFrom.Top < NormalTopPosition)
                {
                    boxFrom.Top += SpeedLevel;
                    boxTo.Top -= SpeedLevel;
                    pictureBox1.Refresh();

                }
            } else
            {
                while (boxFrom.Top < BottopPosition )
                {
                    boxFrom.Top += SpeedLevel;
                    boxTo.Top -= SpeedLevel;
                    pictureBox1.Refresh();

                }
                while (boxFrom.Left < listPositionBox[To].X)
                {
                    boxFrom.Left += SpeedLevel;
                    boxTo.Left -= SpeedLevel;
                    pictureBox1.Refresh();
                }
                while (boxTo.Top < NormalTopPosition)
                {
                    boxTo.Top += SpeedLevel;
                    boxFrom.Top -= SpeedLevel;
                    pictureBox1.Refresh();

                }
            }

            ShuffleBoxPosition(From, To);

        }
        private int MiliSecondAnimationWaitEachFrame=100;
        private int MiliSecondWaitBeforeOpen = 800;
        private int MiliSecondWaitBeforeClose = 600;
        private int MiliSecondWaitBeoforeFirstTimeShuffle = 500;
        private void OpenBox(int BoxIndex)
        {
            var values = Enum.GetValues(typeof(Box.BoxStateEnum));
            foreach(Box.BoxStateEnum state in values)
            {
                boxs[BoxIndex].BoxState = state;
                RefreshUI();
                Wait(MiliSecondAnimationWaitEachFrame);

            }
        
        }
        private void OpenAllExcept(int ExceptBoxIndex)
        {
            var values = Enum.GetValues(typeof(Box.BoxStateEnum));
            foreach (Box.BoxStateEnum state in values)
            {
                foreach (Box box in boxs)
                {
                    if(box.BoxIndex == ExceptBoxIndex)
                    {
                        continue;
                    }
                    box.BoxState = state;

                }
                RefreshUI();
                Wait(MiliSecondAnimationWaitEachFrame);
            }
        }
        private void OpenAll()
        {

            var values = Enum.GetValues(typeof(Box.BoxStateEnum));
            foreach (Box.BoxStateEnum state in values)
            {
                foreach (Box box in boxs)
                {
                    box.BoxState = state;

                }
                RefreshUI();
                Wait(MiliSecondAnimationWaitEachFrame);
            }
        }
        private void ClosAll()
        {
            var values = Enum.GetValues(typeof(Box.BoxStateEnum));

                for (int i = values.Length-1; i >= 0; i--)
                {
                    foreach (Box box in boxs)
                    {
                        box.BoxState =(Box.BoxStateEnum) values.GetValue (i);

                    }

                    RefreshUI();
                    Wait(MiliSecondAnimationWaitEachFrame);
                }
            

        }
     
        private void ShuffleBox()
        {
           // pictureBox1.Enabled = false;
            game.GameState = Game.GameStateEnum.Shuffling;
            game.listShuffle.ForEach(x => DoShuffleBox(x));
            game.GameState = Game.GameStateEnum.WaitForUserToOpenBox;
          //  pictureBox1.Enabled = true;

        }
        private void BlockInput()
        {
            IsAcceptInput = false;
            pictureBox1.MouseDown -= pictureBox1_MouseDown;
        }
        private void UnBlockInput()
        {
            IsAcceptInput = true;
            Timer TimerReleaseBlocking = new Timer();
            TimerReleaseBlocking.Interval = 10;
            TimerReleaseBlocking.Enabled = true;
            TimerReleaseBlocking.Tick += TimerReleaseBlocking_Tick;
        }
        private void TimerReleaseBlocking_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            ((Timer)sender).Enabled = false;
            pictureBox1.MouseDown -= pictureBox1_MouseDown;
            pictureBox1.MouseDown += pictureBox1_MouseDown;

        }
        private void InitialGame()
        {
            BlockInput();
            int BoxWidth = 180;
            int BoxHeight = 180;
            int SpaceBetweenBox = 150;

            boxs.Add(new Box());
            boxs.Add(new Box());
            boxs.Add(new Box());


            boxs.ForEach(x => {
                x.Width = BoxWidth;
                x.Height = BoxHeight;
                x.Click += Box_Click;
                x.BoxState = Box.BoxStateEnum.Close;
            });


            listPositionBox.Add(new Point(SpaceBetweenBox, NormalTopPosition));
            listPositionBox.Add(new Point(SpaceBetweenBox * 2 + BoxWidth, NormalTopPosition));
            listPositionBox.Add(new Point(SpaceBetweenBox * 3 + BoxWidth * 2, NormalTopPosition));
            boxs[0].IsDog = true;
            DictionaryPositionToBoxIndex = new Dictionary<int, int>();
            int i;
            for (i = 0; i < boxs.Count; i++)
            {
                boxs[i].Top = listPositionBox[i].Y;
                boxs[i].Left = listPositionBox[i].X;
                boxs[i].BoxIndex = i;
                DictionaryPositionToBoxIndex.Add(i, i);
            }


            pictureBox1.Height = 580;
            pictureBox1.Refresh();

            for (i = 0; i < boxs.Count; i++)
            {
                boxs[i].BoxState = Box.BoxStateEnum.Close;

            }
           // this.Height = pictureBox1.Top + pictureBox1.Height+ 45;
            this.Width = pictureBox1.Width + pictureBox1.Left + 5;
            this.Height = lblInfo.Top + lblInfo.Height + 35;

        }
        private void Wait(int Millisecond)
        {
           System.Threading.Thread.Sleep (Millisecond);
        }
        private void NewGame()
        {
            // RefreshUI();
            BlockInput();
            IsAcceptInput = false;


            game = new Game();
            RefreshUI();
            OpenAll();
            Wait(MiliSecondWaitBeforeClose );
            ClosAll();


            Wait(MiliSecondWaitBeoforeFirstTimeShuffle);
            ShuffleBox();
            UnBlockInput();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialDic();
            InitialGame();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private Boolean IsCurrentTimeCloseToTheTimePictureBoxMouseDown
        {
            get
            {
                if(TimePictureBoxMouseDown.AddMilliseconds (300) > DateTime.Now)
                {
                    return true;
                }

                return false;
            }
        }
        private DateTime _TimePictureBoxMouseDown;
        private DateTime TimePictureBoxMouseDown
        {
            get
            {
                return _TimePictureBoxMouseDown;
            }
        }
        private void SetTimePictureBoxMouseDown()
        {
            _TimePictureBoxMouseDown = DateTime.Now;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!IsAcceptInput )
            {
                return;
            }

            foreach (Box box in boxs)
            {
                if(box.Rectangle.Contains (new Point(e.X, e.Y)))
                {
                    SetTimePictureBoxMouseDown();
                    box.RaiseClickEvent();
                    return;
                }
            }
        }
        private void ShowDic()
        {
            StringBuilder strB = new StringBuilder();
            foreach (int key in DictionaryPositionToBoxIndex.Keys)
            {
                strB.Append(key).Append(":").Append(DictionaryPositionToBoxIndex[key])
                    .Append(Environment.NewLine);
            }
        }
        private void InitialDic()
        {
            DictionaryPositionToBoxIndex = new Dictionary<int, int>();
            DictionaryPositionToBoxIndex.Add(0, 0);
            DictionaryPositionToBoxIndex.Add(1, 1);
            DictionaryPositionToBoxIndex.Add(2, 2);
            ShowDic();
        }
     

      

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormScore f = new FormScore();
            f.PlayerCurrentScore = -1;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();

        }
    }
}
