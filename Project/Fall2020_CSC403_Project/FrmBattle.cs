using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public bool _hasItems;
        public static FrmBattle instance = null;
        private Enemy enemy;
        private Player player;
        SoundPlayer level_music;
        public PictureBox _characterimg;

        public void getInventory()
        {
            /*int inventoryL = Player.playlerInventory.getInventoryList().Count;
            if(inventoryL == 0)
            {
                instance.invetoryIcon.Visible = false;
            }*/
        }
        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup(PictureBox characterimg, bool hasItems)
        {
            if (enemy.Color != Color.Bisque)
            {
                _hasItems = hasItems;
                button1.Visible = hasItems;
                button2.Visible = hasItems;
                player.AlterHealth(-12);
            }

            

            _characterimg = characterimg;
            // update for this enemy
            picEnemy.BackgroundImage = characterimg.Image;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;


            if (player.getInventory().Count == 0)
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;

            // show health
            UpdateHealthBars();
        }

        public void SetupForBossBattle()
        {

            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = false;

            SoundPlayer bossalert = new SoundPlayer(Resources.boss);
            bossalert.PlayLooping();

            tmrFinalBattle.Enabled = true;
        }

        public static FrmBattle GetInstance(Enemy enemy, PictureBox characterimg, bool hasItems)
        {
            
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup(characterimg, hasItems);
            }
            return instance;
        }

        private void UpdateHealthBars()
        {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            player.OnAttack(-4);
            if (enemy.Health > 0 && enemy.Color != Color.Bisque)
            {
                enemy.OnAttack(-5);
            }
            if (enemy.Health > 0)
            {
                enemy.OnAttack(-3);
            }

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                _characterimg.Visible = false;
                instance = null;
                Close();
                return;
            }
        }

        private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
            if (enemy.Health < 0 && enemy.Color != Color.Bisque)
            {
                instance = null;
                this.Hide();
                FrmYouWin youwin = new FrmYouWin();
                youwin.Show();
            }
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
            if (player.Health <= 0)
            {
                GameOver();
                FrmGameOver gameover = new FrmGameOver();
                Hide();
                gameover.Show();

            }
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
            if (_hasItems)
            {
                button1.Visible = true;
                button2.Visible = true;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void healItem(object sender, EventArgs e)
        {
            player.AlterHealth(10);

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                _characterimg.Visible = false;

                instance = null;
                Close();
            }

            if (Control.ModifierKeys == Keys.Control)
            {
                ((Control)sender).Hide();
            }
        }

        private void StapleClicked(object sender, EventArgs e)
        {
            player.OnAttack(-8);
            if (enemy.Health > 0)
            {
                enemy.OnAttack(-2);
            }

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                instance = null;
                Close();
            }
        }

        private void HealButtonClicked(object sender, EventArgs e)
        {
            player.AlterHealth(10);

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                instance = null;
                Close();
            }

            ((Control)sender).Hide();
        }

        public void GameOver()
        {
            tmrFinalBattle.Stop();
        }
    }
}
