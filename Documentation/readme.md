



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/github_username/repo_name">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">project_title</h3>

  <p align="center">
    project_description
    <br />
    <a href="https://github.com/github_username/repo_name"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/github_username/repo_name">View Demo</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project





<!-- GETTING STARTED -->
## Getting Started



<!-- USAGE EXAMPLES -->
## Usage




<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [ ] Implement Menu System
  - Start Menu
  Description: As a user, I'd like a start/pause menu to start/resume game or view the help menu
  Process: To implement the start menu, I started with adding a new form called FrmMenuScreen. 
<img width="610" alt="image" src="https://user-images.githubusercontent.com/80478785/198042244-2c00f35b-d557-4138-8933-37ec70ec4496.png">

The form was designed by tweaking the attributes in the properties menu. The size was changed, background image was added, title text, and two buttons. Each button calls a method upon click that creates a new form and displays it. The start game button is linked to the LoadGame function, and the help button is linked to the LoadHelpMenu function shown below. In the program.cs file I changed the project to display the start menu first upon running.

<pre><code>
 public partial class FrmMenuScreen : Form
    {
        public FrmMenuScreen()
        {
            InitializeComponent();
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Form gameWindow = new FrmLevel();
            gameWindow.Show();
        }

        private void LoadHelpMenu(object sender, EventArgs e)
        {
            Form helpWindow = new FrmHelpScreen();
            helpWindow.Show();
        }
    }
</code></pre>

  - Help Menu
  Description:
  As a user, I should be able to view a help menu that explains how to play the game
  Process:
  To get started a new form called FrmHelpScreen was created. The size was changed to match the start menu. Text was added that explains the objective of the game as     well as written controls. An image was added to show the player which controls to use. The form can be accessed through the start menu.
  
  <img width="609" alt="image" src="https://user-images.githubusercontent.com/80478785/198911119-f64fcdd9-aa66-4738-84b2-d0f7b2b7b8f2.png">

  
- [ ] New Mechanics
  - Implement new mechanics besides combat
  Description: As a user i would like other object interactions other than combat
  Process:
  To get started, the team brainstormed and decided on creating a snake mini game the player could interact with. After the level was designed, the mini game as         descied to be added into the level and appear when the player reaches the Tech Lead's office. To start making the game I created a new form called FrmSnake that       would serve as the canvas for the game. Next I designed the from to include a canvas for playing as well as a button for starting the game and a menu that displays     high scores. 
  <img width="594" alt="image" src="https://user-images.githubusercontent.com/80478785/198911819-a59ead8b-d33e-471f-a9af-40fe233c2a9e.png">
  
  To start developing the game I fist created a circle class that will serve as a basis to show the snake on the screen as well as implement the food the snake eats.
  The circl object simply holds x and y position coordinates.
  <pre><code> 
  namespace Fall2020_CSC403_Project
  {
    internal class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Circle()
        {
            X = 0;
            Y = 0;
        }
    }
  }
  </code></pre>
  
  Next I added in the logic to handle playing the game in the FrmSnake.cs file. The conctructor creates a new Snake list that holds the circle objects that make up the snake head and body, a new food circle object, and variables to handle the boundries and movement. The StartGame function restarts the game and is called on form initialization. The KeyIsDown and KeyIsUp functions determine the movement of the snake. If no key is pressed the snake continues to move in the current direction and when a key is pressed the KeyIsDown function determines which key is pressed and then changes the direction the snake is moving. The GameTimerEvent function controls the updation of the snake as it moves across the screen. The first loops grabs the head of the snake and updates the position coordinated based on the direction the snake is moving. The next loops tells all the body parts of the snake to update based on the circle before the current in the list. After the snake updation loops, logic is implements for eating food. If the snake runs into the food item the EatFood function is called which increases the score by one and adds another circle to the snake and then randomly places another food. After the logic for eating food is the logic for if the snake hits its own body. In this case the GameOver function is called which stops the game timer and updated the high scores if necessary.
  
 <pre><code>
 namespace Fall2020_CSC403_Project
{
    public partial class FrmSnake : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highscore;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;

        public FrmSnake()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // setting the directions 
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }

            // make sure all parts of snake move together
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                // head of snake
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        // if moving left subtract 1 from current x position
                        case "left":
                            Snake[i].X--;
                            break;
                        // if moving right add 1 to current x position  
                        case "right":
                            Snake[i].X++;
                            break;
                        // if moving up subtract 1 to current y poistion
                        case "up":
                            Snake[i].Y--;
                            break;
                        // if moving down increase current y position by 1
                        case "down":
                            Snake[i].Y++;
                            break;
                    }

                    // if the snake is at the edge of the screen make it appear on the other side
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }


                    // eatfood handling
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    // if the snake hits its own body game over
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                // now we are telling the body what to do
                else
                {
                    // follow what the previous part does
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            // clear canvas
            Canvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkCyan;
                }

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    )) ;
            
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    food.X * Settings.Width,
                    food.Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));


        }

        private void HighScores_Click(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            maxWidth = Canvas.Width / Settings.Width - 1;
            maxHeight = Canvas.Height / Settings.Height - 1;

            Snake.Clear();

            startButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            //adding the head to the snake list
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle {X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            GameTimer.Start();
        }

        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            // randomly place food
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

        }
        private void GameOver()
        {
            GameTimer.Stop();
            startButton.Enabled = true;

            if (score > highscore)
            {
                highscore = score;
                HighScores.Text = "High Scores: " + Environment.NewLine + "ScrumLordZucc: 11" + Environment.NewLine + "Player: " + highscore;
                HighScores.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
 
 </code></pre>
  
- [ ] Implement New Levels
    - [ ] Floor 1
    Description: As a user, I have different levels in the game with increasing difficulty
    Process: To get started with designing the first floor I first created several assets to use within the game. First I remade the walls image being used for the top wall and added in two new wall variations. I made sure to update these using the prewritten code so the collision boxes were still implemented. 
I also created a new cubicle art asset that is shown in the level. I added an office desk asset for the office where the player will play the mini game. Added a image to be used for the tech lead NPC.
<img width="537" alt="image" src="https://user-images.githubusercontent.com/80478785/198913371-9b5b11b5-9811-4b95-bfc7-7082ccc7b49f.png">
<img width="225" alt="image" src="https://user-images.githubusercontent.com/80478785/198913420-8efa6652-431a-4a71-8518-53688cf3bef9.png">
<img width="386" alt="image" src="https://user-images.githubusercontent.com/80478785/198913497-9120d5d1-14ac-4119-99fc-b11154744357.png">

After the assets were created I began to populate the level with the different assets. Final level design:

<img width="960" alt="image" src="https://user-images.githubusercontent.com/80478785/198913654-036ed56a-ddb9-4387-935d-3f995ec244ae.png">


See the [open issues](https://github.com/github_username/repo_name/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>






