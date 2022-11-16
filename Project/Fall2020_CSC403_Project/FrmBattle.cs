﻿using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private Player player;
        SoundPlayer level_music;
        bool isClick = false;
        private List<object> inventory;

        public void getInventory()
        {
            inventory = player.getInventory();
            if (inventory.Contains(0))
            {
                button2.Visible = true;
                Application.DoEvents();
            }
            if (inventory.Contains(1))
            {
                button1.Visible = true;
                Application.DoEvents();
            }

        }
        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup()
        {
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            getInventory();

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
            picBossBattle.Visible = true;

            SoundPlayer bossalert = new SoundPlayer(Resources.boss_intro);
            bossalert.Play();

            tmrFinalBattle.Enabled = true;
        }

        public static FrmBattle GetInstance(Enemy enemy)
        {
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup();
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
            if (isClick == false)
            {
                level_music = new SoundPlayer(Resources.boss);
                level_music.PlayLooping();
            }
            player.OnAttack(-4);
            if (enemy.Health > 0)
            {
                isClick = true;
                enemy.OnAttack(-2);
            }

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                instance = null;
                level_music = new SoundPlayer(Resources.floor1);
                level_music.PlayLooping();
                Close();
                return;
            }
        }

        private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
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
    }
}
