using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fall2020_CSC403_Project.Properties;
using Fall2020_CSC403_Project.code;
using System.Media;


namespace Fall2020_CSC403_Project
{
    public partial class FrmBossLevel : Form
    {
        private bool hasItems = false;
        private Player player;
        private SoundPlayer level_music;
        private Enemy elevator;
        private Enemy bossKoolaid;

        List<Enemy> enemyList;

        const int PADDING = 4;
        private FrmBattle frmBattle;

        private DateTime timeBegin;


        public FrmBossLevel(bool hasItems)
        {
            this.hasItems = hasItems;
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {


            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));

            elevator = new Enemy(CreatePosition(picElevator), CreateCollider(picElevator, PADDING));
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            enemyList = new List<Enemy> { bossKoolaid, elevator };

            elevator.Img = picElevator.BackgroundImage;
            bossKoolaid.Img = picBossKoolAid.BackgroundImage;

            bossKoolaid.Color = Color.Red;

            Game.player = player;
            timeBegin = DateTime.Now;

            level_music = new SoundPlayer(Resources.boss_intro);
            level_music.PlayLooping();
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
                this.Hide();
                Form level1 = new FrmLevel();
                level1.Show();
            }
            player.ResetMoveSpeed();
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

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
            // move player
            player.Move();
            if (HitAChar(player, bossKoolaid))
            {
                Fight(bossKoolaid);
            }
            if (player.Health <= 0)
            {
                Hide();
                Dispose();
            }

            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        public void GameOver()
        {
            tmrUpdateInGameTime.Stop();
        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy, picBossKoolAid, hasItems);
            frmBattle.Show();

            if (enemy == bossKoolaid)
            {
                frmBattle.SetupForBossBattle();
                if (enemy.Health <= 0)
                {
                    Form YouWin = new FrmYouWin();
                    YouWin.Show();
                }
            }
        }

        private void picBossKoolAid_Click(object sender, EventArgs e)
        {

        }
    }
}
