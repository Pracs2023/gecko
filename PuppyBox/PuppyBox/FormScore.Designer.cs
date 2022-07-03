namespace PuppyBox
{
    partial class FormScore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.pnlEnterScore = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewScoreName = new System.Windows.Forms.TextBox();
            this.btnNewRank = new System.Windows.Forms.Button();
            this.lblNewScoreRank = new System.Windows.Forms.Label();
            this.pnlShowScore = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlEnterScore.SuspendLayout();
            this.pnlShowScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 356);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(305, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "  Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(78, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rank";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(648, 365);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTemplate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.Location = new System.Drawing.Point(0, 0);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(71, 30);
            this.lblTemplate.TabIndex = 34;
            this.lblTemplate.Text = "Name";
            this.lblTemplate.Visible = false;
            // 
            // pnlEnterScore
            // 
            this.pnlEnterScore.Controls.Add(this.label4);
            this.pnlEnterScore.Controls.Add(this.txtNewScoreName);
            this.pnlEnterScore.Controls.Add(this.btnNewRank);
            this.pnlEnterScore.Controls.Add(this.lblNewScoreRank);
            this.pnlEnterScore.Location = new System.Drawing.Point(5, 439);
            this.pnlEnterScore.Name = "pnlEnterScore";
            this.pnlEnterScore.Size = new System.Drawing.Size(433, 240);
            this.pnlEnterScore.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(111, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 30);
            this.label4.TabIndex = 35;
            this.label4.Text = "Congratulations!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewScoreName
            // 
            this.txtNewScoreName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewScoreName.Location = new System.Drawing.Point(25, 139);
            this.txtNewScoreName.Name = "txtNewScoreName";
            this.txtNewScoreName.Size = new System.Drawing.Size(392, 35);
            this.txtNewScoreName.TabIndex = 34;
            // 
            // btnNewRank
            // 
            this.btnNewRank.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRank.Location = new System.Drawing.Point(304, 180);
            this.btnNewRank.Name = "btnNewRank";
            this.btnNewRank.Size = new System.Drawing.Size(113, 43);
            this.btnNewRank.TabIndex = 33;
            this.btnNewRank.Text = "OK";
            this.btnNewRank.UseVisualStyleBackColor = true;
            this.btnNewRank.Click += new System.EventHandler(this.btnNewRank_Click);
            // 
            // lblNewScoreRank
            // 
            this.lblNewScoreRank.AutoSize = true;
            this.lblNewScoreRank.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewScoreRank.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNewScoreRank.Location = new System.Drawing.Point(20, 76);
            this.lblNewScoreRank.Name = "lblNewScoreRank";
            this.lblNewScoreRank.Size = new System.Drawing.Size(329, 60);
            this.lblNewScoreRank.TabIndex = 4;
            this.lblNewScoreRank.Text = "You have one of the best scores.\r\nPlease enter your name...";
            // 
            // pnlShowScore
            // 
            this.pnlShowScore.Controls.Add(this.tableLayoutPanel1);
            this.pnlShowScore.Controls.Add(this.btnClose);
            this.pnlShowScore.Location = new System.Drawing.Point(5, 5);
            this.pnlShowScore.Name = "pnlShowScore";
            this.pnlShowScore.Size = new System.Drawing.Size(774, 421);
            this.pnlShowScore.TabIndex = 36;
            // 
            // FormScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 736);
            this.Controls.Add(this.pnlShowScore);
            this.Controls.Add(this.pnlEnterScore);
            this.Controls.Add(this.lblTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Score";
            this.Load += new System.EventHandler(this.FormScore_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlEnterScore.ResumeLayout(false);
            this.pnlEnterScore.PerformLayout();
            this.pnlShowScore.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Panel pnlEnterScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewScoreName;
        private System.Windows.Forms.Button btnNewRank;
        private System.Windows.Forms.Label lblNewScoreRank;
        private System.Windows.Forms.Panel pnlShowScore;
    }
}