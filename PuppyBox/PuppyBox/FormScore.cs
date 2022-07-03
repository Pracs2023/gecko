using PuppyBox.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuppyBox
{
    public partial class FormScore : Form
    {
        public FormScore()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CopyPropertyFromLabelTemplate(params Label[] arrlabel)
        {
            foreach (Label label in arrlabel)
            {
                label.Font = this.lblTemplate.Font;
              //  label.ForeColor = this.lblTemplate.ForeColor;
                label.Dock = this.lblTemplate.Dock;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            for(i=1;i<=10;i++)
            {
                Label lblRank = new Label();
                Label lblName = new Label();
                Label lblScore = new Label();
                CopyPropertyFromLabelTemplate(lblRank, lblName, lblScore);
                lblRank.TextAlign = ContentAlignment.MiddleRight;
                lblScore.TextAlign = ContentAlignment.MiddleRight;
                lblRank.Visible = true;
                lblName.Visible = true;
                lblScore.Visible = true;
                lblRank.Text = "R" + i.ToString();
                lblName.Text = "N" + i.ToString();
                lblScore.Text = "S" + i.ToString();

                this.tableLayoutPanel1.Controls.Add(lblRank);
                this.tableLayoutPanel1.Controls.Add(lblName);
                this.tableLayoutPanel1.Controls.Add(lblScore);

            }
          

            // this.tableLayoutPanel1.GetCellPosition ()
        }
        
        private void InitialTable()
        {
            int i;
            for (i = 1; i <= 10; i++)
            {
                Label lblRank = new Label();
                Label lblName = new Label();
                Label lblScore = new Label();
                CopyPropertyFromLabelTemplate(lblRank, lblName, lblScore);
                lblRank.TextAlign = ContentAlignment.MiddleRight;
                lblScore.TextAlign = ContentAlignment.MiddleRight;
                lblRank.Visible = true;
                lblName.Visible = true;
                lblScore.Visible = true;


                this.tableLayoutPanel1.Controls.Add(lblRank);
                this.tableLayoutPanel1.Controls.Add(lblScore);
                this.tableLayoutPanel1.Controls.Add(lblName);


            }

        }
        private void RenderScore()
        {
            int i = 0;
            
            for (i = 0; i < ScoreHelper.scoreInfos.listScoreInfo.Count; i++)
            {
                this.tableLayoutPanel1.GetControlFromPosition(0, i + 1).Text = ScoreHelper.scoreInfos.listScoreInfo[i].Rank.ToString();
                this.tableLayoutPanel1.GetControlFromPosition(1, i + 1).Text = ScoreHelper.scoreInfos.listScoreInfo[i].Score.ToString();
                this.tableLayoutPanel1.GetControlFromPosition(2, i + 1).Text = ScoreHelper.scoreInfos.listScoreInfo[i].Name.ToString();
            }
        }
        public int PlayerCurrentScore { get; set; }
        private void ShowNewRank()
        {
            this.pnlEnterScore.Top = 5;
            this.pnlEnterScore.Left = 5;
            this.pnlShowScore.Visible = false ;
            this.pnlEnterScore.Visible =true;
            this.Height = this.pnlEnterScore.Height + this.pnlEnterScore.Top + 30;
            this.Width = this.pnlEnterScore.Width + this.pnlEnterScore.Left + 20;
            this.txtNewScoreName.Text  = ScoreHelper.scoreInfos.PreviousName;

        }
        private void ShowHallofFrame()
        {
            this.pnlShowScore.Top = 5;
            this.pnlShowScore.Left = 5;
            this.pnlShowScore.Visible = true;
            this.pnlEnterScore.Visible = false;
            this.Height = this.pnlShowScore.Height + this.pnlShowScore.Top + 30;
            this.Width = this.pnlShowScore.Width + this.pnlShowScore.Left  + 20;

            InitialTable();
            RenderScore();

        }
        private void FormScore_Load(object sender, EventArgs e)
        {
           
           // this.PlayerCurrentScore = 600;
            if(this.PlayerCurrentScore > -1)
            {
                if (ScoreHelper.CalculateNewRankFromScore(this.PlayerCurrentScore) > -1)
                {
                    ShowNewRank();
                    return;
                }
            }

            ShowHallofFrame();

            /*
            this.PlayerCurrentScore = 600;

            int PlayerNewRank = 0;

            if (PlayerCurrentScore > -1)
            {
                int i;
                //for(i=scoreInfos.listScoreInfo.Count -1;i>=0;i--)
                for(i=0;i<scoreInfos.listScoreInfo.Count ;i++)
                {
                    if(scoreInfos.listScoreInfo [i].Score < PlayerCurrentScore)
                    {
                        PlayerNewRank = scoreInfos.listScoreInfo[i].Rank;
                        break;
                    }
                }
              
            }
            this.txtNewScoreName.Text = PlayerNewRank.ToString();
            */

            /*
            scoreInfos.listScoreInfo = new List<ScoreInfo>();
            int PlayerNewRank = 0;
            if(PlayerCurrentScore > -1)
            {
                foreach (ScoreInfo sInfo in scoreInfos.listScoreInfo)
                {
                    if(sInfo.Score < PlayerCurrentScore )
                    {
                        PlayerNewRank = sInfo.Rank;
                    }
                }
            }

            
            string[] arrName =
            {
                "John",
                "Katie",
                "Alex",
                "Ryu",
                "Koichi",
                "Somsri",
                "Micheal",
                "Hangtua",
                "Che Nyein",
                "Gogo"
            };

            int[] arrScore =
            {
                1000,
                900,
                800,
                700,
                600,
                500,
                400,
                300,
                200,
                100
            };
            int i;
            scoreInfos.listScoreInfo = new List<ScoreInfo>();
            for(i=0;i<arrScore.Length;i++)
            {
                scoreInfos.listScoreInfo.Add(new ScoreInfo((i + 1), arrName[i], arrScore[i]));
            }
            scoreInfos.PreviousName = "Anonymous";
            SerializeUtility.SerializeScoreInfos(scoreInfos, FileUtility.ScoreFilePath);
            */


        }

        private void btnNewRank_Click(object sender, EventArgs e)
        {
            ScoreHelper.InsertNewRank(this.txtNewScoreName.Text, this.PlayerCurrentScore);
            ScoreHelper.scoreInfos.PreviousName = this.txtNewScoreName.Text;
            ScoreHelper.Save();

            this.Close();
        }
    }
}
