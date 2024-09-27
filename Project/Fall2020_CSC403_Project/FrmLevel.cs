using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Fall2020_CSC403_Project.Properties;
using System.Media;
using System.Xml.Linq;

namespace Fall2020_CSC403_Project
{
    public partial class FrmLevel : Form
    {
        private Player player;
        private bool hasItems = false;
        private Enemy elevator;
        private Enemy office_desk;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Enemy techlead;
        public bool FIGHT;
        public bool FIGHTED;
        List<Enemy> enemyList;
        private Character[] walls;
        private Character secretDesk;
        const int PADDING = 4;
        const int NUM_WALLS = 11;
        public PictureBox _pictechlead;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        private FrmSnake frmSnake;
        FrmDialogue enemy_frmDialogue;
        private bool stapleFlag = false;

        public FrmLevel()
        {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {


            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));

            elevator = new Enemy(CreatePosition(picElevator), CreateCollider(picElevator, PADDING));
            office_desk = new Enemy(CreatePosition(picOfficeDesk), CreateCollider(picOfficeDesk, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));
            techlead = new Enemy(CreatePosition(picTechlead), CreateCollider(picTechlead, PADDING));
            enemyList = new List<Enemy> { enemyCheeto, techlead, bossKoolaid };
            secretDesk = new Character(CreatePosition(picWall3), CreateCollider(picWall3, PADDING));
            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            office_desk.Img = picOfficeDesk.BackgroundImage;
            enemyCheeto.Img = picEnemyCheeto.BackgroundImage;
            techlead.Img = picTechlead.BackgroundImage;
            techlead.Color = Color.Bisque;
            enemyCheeto.Color = Color.FromArgb(255, 245, 161);

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;

            SoundPlayer level_music = new SoundPlayer(Resources.floor1);
            level_music.PlayLooping();
        }
        private void Talk(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            enemy_frmDialogue = FrmDialogue.GetInstance(enemy, enemyList);
            Console.WriteLine(enemy_frmDialogue);
            enemy_frmDialogue.Show();
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private Collider CreateCollider(PictureBox pic, int padding)
        {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        private void FrmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (HitAChar(player, elevator))
            {
                if (enemy_frmDialogue != null)
                {
                    hasItems = enemy_frmDialogue.waterCoolerGiven;
                    enemy_frmDialogue.Close();
                }
                Form level2 = new FrmBossLevel(hasItems);
                this.Hide();
                level2.Show();
            }
            player.ResetMoveSpeed();
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
          
            // move player
            player.Move();

            // check collision with walls
            if (HitAWall(player))
            {
                player.MoveBack();
            }

            // check collision with enemies
            if (HitAChar(player, office_desk))
            {
                PlayMiniGame(office_desk);
            }
            else if (HitAChar(player, enemyCheeto))
            {
                Talk(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid))
            {
                Fight(bossKoolaid);
                wasdFalse();
            }
            if (HitAChar(player, secretDesk))
            {
                stapleCollected();
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
            if (techlead.Health < 0)
            {
                picTechlead.Dispose();
                picTechlead.Visible = false;
                return;
            }
           
            if (!FIGHT)
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

                
                techlead.ResetMoveSpeed();
                techlead.MoveBack();
                FIGHT = true;
                Fight(techlead);
            }
            picTechlead.Location = new Point((int)techlead.Position.x, (int)techlead.Position.y);
        }

        private bool HitAWall(Character c)
        {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++)
            {
                if (c.Collider.Intersects(walls[w].Collider))
                {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy)
        {
            if (enemy.Color == Color.Bisque && FIGHT)
                enemy.MoveBack();

            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy, _pictechlead, hasItems);
            frmBattle.Show();

        }

        private void PlayMiniGame(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmSnake = new FrmSnake();
            frmSnake.Show();
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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

        private void stapleCollected()
        {
            if (!stapleFlag)
            {
                wasdFalse();
                player.ResetMoveSpeed();
                stapleFlag = true;
                string message = "A stapler has been collected!!";
                string caption = "Alert";
                var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                player.addToInventory(1);
            }
         }

        public void GameOver()
        {
            tmrUpdateInGameTime.Stop();
        }


        private void lblInGameTime_Click(object sender, EventArgs e)
        {

        }

        private void picWall1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void OnFormClosed(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picWall10_Click(object sender, EventArgs e)
        {

        }
    }
}
