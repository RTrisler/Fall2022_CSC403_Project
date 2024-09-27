using Fall2020_CSC403_Project.code;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmDialogue : Form
    {
        public static FrmDialogue player_instance = null;
        public static FrmDialogue enemy_instance = null;
        private Enemy enemy;
        private Player player;
        private int lineTracker;
        private string[] interactionDialogue = new string[] { };
        private static List<Enemy> formEnemyList = null;
        public bool waterCoolerFlag = false;
        public bool waterCoolerGiven = false;
        public FrmDialogue()
        {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup()
        {
            // Update for this enemy
            pictureBox1.Image = enemy.Img;
            pictureBox1.Refresh();
            lineTracker = 0;
            System.Diagnostics.Debug.WriteLine(lineTracker);
            interactionDialogue = LoadDialogue(enemy);
            if (enemy == formEnemyList[0])
                waterCoolerFlag = true;
            System.Diagnostics.Debug.WriteLine(interactionDialogue[lineTracker]);
            dialogueTextBox.Text = interactionDialogue[lineTracker];
            picEnemy.Visible = true;

            // Observer pattern
            //enemy.AttackEvent += PlayerDamage;
            //player.AttackEvent += EnemyDamage;

            // Show health
            //UpdateHealthBars();
        }

        public static FrmDialogue GetInstance(Enemy enemy, List<Enemy> enemyList)
        {
            Console.WriteLine(enemy.Img.Width);
            formEnemyList = enemyList;

            if (player_instance != null && player_instance.IsDisposed)
            {
                player_instance = null;
            }
            if (player_instance == null)
            {
                player_instance = new FrmDialogue();
                player_instance.enemy = enemy;
                player_instance.Setup();
            }
            return player_instance;
        }

        public static void FrmDialogue_Load()
        {
        }

        public static string[] LoadDialogue(Enemy enemy)
        {
            Console.WriteLine(enemy.Img.Width);
            string[] dialogueset;
            // poison packet man
            if (enemy == formEnemyList[0])
            {
                dialogueset = new string[]
                { "Mr. Peanut: *In thought* Thank god a water cooler, I sure am parched.",
                  "Water Cooler: Hi. How are you?",
                  "Mr. Peanut: I'm fine, how are you?",
                  "Water Cooler: Good. Did you happen to catch the big game last night?",
                  "Mr. Peanut: Yes, I did. It was a football game, with kicks, and also with throws of the ball.",
                  "Water Cooler: Astute observation. I like the observation, and I also like football. We enjoy football, yes?",
                  "Mr. Peanut: Yes, we do. Here is a stapler and a tall drink of water. Glug glug. You'll need a lot of that stuff. "};


                return dialogueset;
            }
            // cheeto ma'am
            else if (enemy == formEnemyList[1])
            {
                dialogueset = new string[]
                { "Mr. Peanut: What are you doing here?",
                  "Cheeto bruther: I work and scrum here."};
                return dialogueset;
            }
            //bossKoolaid
            else if (enemy == formEnemyList[2])
            {
                dialogueset = new string[]
                { "Mr. Peanut: What are you doing here?",
                  "Boss Bruther: I work and scrum here."};
                return dialogueset;
            }
            return null;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            lineTracker++;
            if (lineTracker != interactionDialogue.Length)
            {
                dialogueTextBox.Text = interactionDialogue[lineTracker];
            }
            else
            {
                if (!waterCoolerGiven)
                {
                    if (waterCoolerFlag)
                        player.addToInventory(0);
                    waterCoolerFlag = false;
                    waterCoolerGiven = true;
                }
                Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
