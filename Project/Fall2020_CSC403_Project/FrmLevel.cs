using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Fall2020_CSC403_Project 
{
    public partial class FrmLevel : Form
    {
        private Player player;

        private Enemy office_desk;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Enemy techlead;
        private Character[] walls;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        private FrmSnake frmSnake;

        public FrmLevel() {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e) {
            const int PADDING = 4;
            const int NUM_WALLS = 2;

            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            office_desk = new Enemy(CreatePosition(picOfficeDesk), CreateCollider(picOfficeDesk, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));
            techlead = new Enemy(CreatePosition(picTechlead), CreateCollider(picTechlead, PADDING));

            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            office_desk.Img = picOfficeDesk.BackgroundImage;
            enemyCheeto.Img = picEnemyCheeto.BackgroundImage;
            techlead.Img = picTechlead.BackgroundImage;
        }
    private void Talk(Enemy enemy)
    {
      player.ResetMoveSpeed();
      player.MoveBack();
      enemy_frmDialogue = FrmDialogue.GetInstance(enemy, enemyList);
      Console.WriteLine(enemy_frmDialogue);
      enemy_frmDialogue.Show();
    }

    private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Left:
          player.GoLeft();
          break;
            bossKoolaid.Color = Color.Red;
            enemyCheeto.Color = Color.FromArgb(255, 245, 161);

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++) {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;


        }

        private Vector2 CreatePosition(PictureBox pic) {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private Collider CreateCollider(PictureBox pic, int padding) {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        private void FrmLevel_KeyUp(object sender, KeyEventArgs e) {
            player.ResetMoveSpeed();
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e) {
            // move player
            player.Move();

            // check collision with walls
            if (HitAWall(player)) {
                player.MoveBack();
            }

            // check collision with enemies
            if (HitAChar(player, office_desk)) {
                PlayMiniGame(office_desk);
            }
            else if (HitAChar(player, enemyCheeto)) {
                Fight(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid)) {
                Fight(bossKoolaid);
            }
            if (HitAChar(player, techlead))
            {
                GameOver();
            }

            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
        }

        private void TechLeadPatrol_Tick(object sender, EventArgs e)
        {
            techlead.Move();
            if (HitAChar(techlead, enemyCheeto))
            {
                techlead.GoRight();
            }
            if (HitAChar(techlead, office_desk))
            {
                techlead.GoLeft();
            }
            if (HitAChar(techlead, player))
            {
                GameOver();
            }
            picTechlead.Location = new Point((int)techlead.Position.x, (int)techlead.Position.y);
        }

        private bool HitAWall(Character c) {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++) {
                if (c.Collider.Intersects(walls[w].Collider)) {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAChar(Character you, Character other) {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy) {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            frmBattle.Show();

            if (enemy == bossKoolaid) {
                frmBattle.SetupForBossBattle();
            }
        }

        private void PlayMiniGame(Enemy enemy) {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmSnake = new FrmSnake();
            frmSnake.Show();
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.A:
                    player.GoLeft();
                    break;

                case Keys.D:
                    player.GoRight();
                    break;

                case Keys.W:
                    player.GoUp();
                    break;

                case Keys.S:
                    player.GoDown();
                    break;

                default:
                    player.ResetMoveSpeed();
                    break;
            }
        }

        public void GameOver()
        {
            tmrUpdateInGameTime.Stop();
        }


        private void lblInGameTime_Click(object sender, EventArgs e) {

        }

            private void picWall1_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox8_Click(object sender, EventArgs e)
            {

            }
  }
}
