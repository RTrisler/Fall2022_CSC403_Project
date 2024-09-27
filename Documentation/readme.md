



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
  Process:
  
- [ ] Feature 2
- [ ] Feature 3
    - [ ] Nested Feature
- [ ] Implement Item System : As a user, I'd like to have different types of weapons.
  - Creating Item Class
    -  Process: In order to have different weapons, I have to create an item class. I had to research online on how to create an item class for a game in C#. Once I found something that could work, I read the code and comments as well as the explanations. Then, I made changes to the code for it to work for this project.
  - Creating Weapon class
    - Process: Once I had made the item class, I was able to make the weapon class. By using what I had researched online I applied it to the project while making sure to keep to the changes I made in the item class.
  - Creating Item information
    - Process: Now that I had the weapon class I was able to create the weapon stats. By researching online again, I was able to find and change the code for the game. Then, I assigned values for the parameters of the weapon class. 
    
- [ ] Implement Healing Item: As a user, I'd like to find items that can heal myself
  - Creating Health item class
    - Process: By looking at the weapon class, I made changes so that this class would not have damage stats but health. I then added the item to the item informatin class so that it would be created.

See the [open issues](https://github.com/github_username/repo_name/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>






