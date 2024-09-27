
namespace Fall2020_CSC403_Project
{
    partial class FrmBossLevel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBossLevel));
            this.picElevator = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.tmrUpdateInGameTime = new System.Windows.Forms.Timer(this.components);
            this.tmrPlayerMove = new System.Windows.Forms.Timer(this.components);
            this.picBossKoolAid = new System.Windows.Forms.PictureBox();
            this.lblInGameTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picElevator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBossKoolAid)).BeginInit();
            this.SuspendLayout();
            // 
            // picElevator
            // 
            this.picElevator.Image = ((System.Drawing.Image)(resources.GetObject("picElevator.Image")));
            this.picElevator.Location = new System.Drawing.Point(63, 232);
            this.picElevator.Name = "picElevator";
            this.picElevator.Size = new System.Drawing.Size(137, 158);
            this.picElevator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picElevator.TabIndex = 25;
            this.picElevator.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayer.Location = new System.Drawing.Point(207, 275);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(81, 115);
            this.picPlayer.TabIndex = 26;
            this.picPlayer.TabStop = false;
            // 
            // tmrUpdateInGameTime
            // 
            this.tmrUpdateInGameTime.Enabled = true;
            // 
            // tmrPlayerMove
            // 
            this.tmrPlayerMove.Enabled = true;
            this.tmrPlayerMove.Interval = 10;
            this.tmrPlayerMove.Tick += new System.EventHandler(this.tmrPlayerMove_Tick);
            // 
            // picBossKoolAid
            // 
            this.picBossKoolAid.BackColor = System.Drawing.Color.Transparent;
            this.picBossKoolAid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBossKoolAid.Image = ((System.Drawing.Image)(resources.GetObject("picBossKoolAid.Image")));
            this.picBossKoolAid.Location = new System.Drawing.Point(681, 227);
            this.picBossKoolAid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picBossKoolAid.Name = "picBossKoolAid";
            this.picBossKoolAid.Size = new System.Drawing.Size(117, 163);
            this.picBossKoolAid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBossKoolAid.TabIndex = 27;
            this.picBossKoolAid.TabStop = false;
            this.picBossKoolAid.Click += new System.EventHandler(this.picBossKoolAid_Click);
            // 
            // lblInGameTime
            // 
            this.lblInGameTime.AutoSize = true;
            this.lblInGameTime.Location = new System.Drawing.Point(21, 13);
            this.lblInGameTime.Name = "lblInGameTime";
            this.lblInGameTime.Size = new System.Drawing.Size(51, 20);
            this.lblInGameTime.TabIndex = 28;
            this.lblInGameTime.Text = "label1";
            // 
            // FrmBossLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.BossLevel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1198, 504);
            this.Controls.Add(this.lblInGameTime);
            this.Controls.Add(this.picBossKoolAid);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.picElevator);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1220, 560);
            this.MinimumSize = new System.Drawing.Size(1220, 560);
            this.Name = "FrmBossLevel";
            this.Text = "BossLevel";
            this.Load += new System.EventHandler(this.FrmLevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picElevator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBossKoolAid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picElevator;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.Timer tmrUpdateInGameTime;
        private System.Windows.Forms.Timer tmrPlayerMove;
        private System.Windows.Forms.PictureBox picBossKoolAid;
        private System.Windows.Forms.Label lblInGameTime;
    }
}