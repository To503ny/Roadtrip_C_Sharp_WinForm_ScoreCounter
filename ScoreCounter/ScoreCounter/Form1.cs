using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCounter
{
    public partial class Form1 : Form
    {
        //reference to objects
        GameManager gameManager;
        Player newPlayer;
        
        //CONST
        const int LBL_WIDTH = 500;
        const int LBL_HEIGHT = 100;
        const int FIRST_X = 20;
        const int FIRST_Y = 20;
        const int ADD_BTN_Y_OFFSET = 10;
        const int OFFSET = 210;
        const int LBL_OFFSET_X = 100;
        const int LBL_OFFSET_Y = 60;
        const int BTN_ADD_SUB_WIDTH = 50;
        const int BTN_ADD_SUB_HEIGHT = 50;
        const int BTN_ADD_SUB_OFFSET = 75;
        const int BTN_GAME_OVER_WIDTH = 125;
        const int BTN_GAME_OVER_HEIGHT = 50;

        //Variables
        int i, player1Score, player2Score, player3Score, player4Score, player5Score, player6Score, winnerScore;
        int numWinners = 0;
        string numPlayers, winner;


        //locations
        Point tbLocation = new Point(215, 250);
        Point btnLocation = new Point(185, 300);
        Point userControlLoc = new Point(FIRST_X, FIRST_Y);

        //Labels
        Label lblCaption = new Label();
        Label lblCaption2 = new Label();

        Label lblPlayer1Name = new Label();
        Label lblPlayer2Name = new Label();
        Label lblPlayer3Name = new Label();
        Label lblPlayer4Name = new Label();
        Label lblPlayer5Name = new Label();
        Label lblPlayer6Name = new Label();

        Label lblPlayer1Points = new Label();
        Label lblPlayer2Points = new Label();
        Label lblPlayer3Points = new Label();
        Label lblPlayer4Points = new Label();
        Label lblPlayer5Points = new Label();
        Label lblPlayer6Points = new Label();

        //Buttons
        Button btnSetUsers = new Button();
        Button btnAddPlayer = new Button();
        Button btnStartGame = new Button();

        Button btnPlayer1AddPoint = new Button();
        Button btnPlayer2AddPoint = new Button();
        Button btnPlayer3AddPoint = new Button();
        Button btnPlayer4AddPoint = new Button();
        Button btnPlayer5AddPoint = new Button();
        Button btnPlayer6AddPoint = new Button();

        Button btnPlayer1SubPoint = new Button();
        Button btnPlayer2SubPoint = new Button();
        Button btnPlayer3SubPoint = new Button();
        Button btnPlayer4SubPoint = new Button();
        Button btnPlayer5SubPoint = new Button();
        Button btnPlayer6SubPoint = new Button();

        Button btnGameOver = new Button();

        //TextBoxes
        TextBox tbNumPlayers = new TextBox();
        TextBox tbPlayerName = new TextBox();


        public Form1()
        {
            InitializeComponent();

            gameManager = new GameManager();
            newPlayer = new Player();

            i = 1;
            numPlayers = "0";
            winnerScore = 0;

            SetUpGame();
        }

        //Methods
        private void SetUpGame()
        {
            //lblCaption
            lblCaption.Name = "lblCaption";
            lblCaption.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            lblCaption.Location = new Point(65,50);
            lblCaption.Text = "Please enter the number of users!" + "\n" + "*Must be between 1 - 6 players";
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font(lblCaption.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(lblCaption);

            //lblNumPlayers
            lblCaption2.Name = "lblNumPlayers";
            
            lblCaption2.Location = new Point(240, 150);
            lblCaption2.Text = "0";
            lblCaption2.AutoSize = true;
            lblCaption2.Font = new Font(lblCaption2.Font.FontFamily, 50, FontStyle.Bold);
            this.Controls.Add(lblCaption2);

            //tbNumPlayers
            tbNumPlayers.Name = "tbNumPlayers";
            tbNumPlayers.Location = tbLocation;
            this.tbNumPlayers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbNumPlayers_KeyPress);
            this.tbNumPlayers.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbNumPlayers_KeyUp);
            this.tbNumPlayers.KeyPress += new KeyPressEventHandler(OnKeyDownHandler);

            Controls.Add(tbNumPlayers);

            //button
            btnSetUsers.Name = "btnSetUsers";
            btnSetUsers.Location = btnLocation;
            btnSetUsers.Width = 150;
            btnSetUsers.Height = 100;
            btnSetUsers.Text = "Set";
            btnSetUsers.BackColor = Color.SlateGray;
            btnSetUsers.ForeColor = Color.GhostWhite;
            btnSetUsers.Font = new Font(btnSetUsers.Font.FontFamily, 10, FontStyle.Bold);
            btnSetUsers.Click += new EventHandler(SetNumPlayers);
            
            this.Controls.Add(btnSetUsers);

        }

        private void ShowAddPlayerControls()
        {
            //set lblCaption
            lblCaption.Text = "Please enter a name";
            lblCaption.Location = new Point(125, 50);
            //set lblCaption2
            lblCaption2.Text = "";
            lblCaption2.Location = new Point(100, 170);
            lblCaption2.Font = new Font(lblCaption2.Font.FontFamily, 15, FontStyle.Bold);
            //btnAddPlayer
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Location = btnLocation;
            btnAddPlayer.Width = 150;
            btnAddPlayer.Height = 100;
            btnAddPlayer.Text = "Add";
            btnAddPlayer.BackColor = Color.SlateGray;
            btnAddPlayer.ForeColor = Color.GhostWhite;
            btnAddPlayer.Font = new Font(btnAddPlayer.Font.FontFamily, 10, FontStyle.Bold);
            btnAddPlayer.Click += new EventHandler(BtnAddPlayer_Click);
            //btnAddPlayer.MouseUp += new MouseEventHandler(BtnAddPlayer_MouseUp);

            //btnStartGame
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Location = btnLocation;
            btnStartGame.Width = 150;
            btnStartGame.Height = 100;
            btnStartGame.Text = "Start";
            btnStartGame.BackColor = Color.SlateGray;
            btnStartGame.ForeColor = Color.GhostWhite;
            btnStartGame.Font = new Font(btnStartGame.Font.FontFamily, 10, FontStyle.Bold);
            btnStartGame.Click += new EventHandler(BtnStartGame_Click);

            Controls.Add(btnAddPlayer);

            //tbPlayerName
            tbPlayerName.Name = "tbPlayerName";
            tbPlayerName.Location = tbLocation;
            Controls.Add(tbPlayerName);
            tbPlayerName.Focus();
            tbPlayerName.KeyPress += new KeyPressEventHandler(OnKeyDownHandler);
        }//end ShowAddPlayerControls

        private void SetUpGameScreen()
        {
            RemoveAddPlayerControls();
            //Set up users controls
            //if 1 player
            if(int.Parse(numPlayers) == 1)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 1 player

            //if 2 Players
            if(int.Parse(numPlayers) == 2)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                Controls.Add(btnPlayer1SubPoint);

                //player 2
                lblPlayer2Name.Name = "lblPlayer2Name";
                lblPlayer2Name.Location = new Point(lblPlayer1Name.Location.X, lblPlayer1Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Name.ForeColor = Color.SlateGray;
                lblPlayer2Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Name.Text = newPlayer.namesArray[1];
                lblPlayer2Name.AutoSize = true;
                Controls.Add(lblPlayer2Name);

                lblPlayer2Points.Name = "lblPlayer2Points";
                lblPlayer2Points.Location = new Point(lblPlayer1Points.Location.X, lblPlayer1Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Points.ForeColor = Color.SlateGray;
                lblPlayer2Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Points.Text = "0";
                lblPlayer2Points.AutoSize = true;
                Controls.Add(lblPlayer2Points);

                btnPlayer2AddPoint.Name = "btnPlayer2AddPoint";
                btnPlayer2AddPoint.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2AddPoint.BackColor = Color.SlateGray;
                btnPlayer2AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer2AddPoint.Text = "+";
                btnPlayer2AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2AddPoint_Click);
                Controls.Add(btnPlayer2AddPoint);

                btnPlayer2SubPoint.Name = "btnPlayer2SubPoint";
                btnPlayer2SubPoint.Location = new Point(btnPlayer1SubPoint.Location.X, btnPlayer1SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2SubPoint.BackColor = Color.SlateGray;
                btnPlayer2SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer2SubPoint.Text = "-";
                btnPlayer2SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2SubPoint_Click);
                Controls.Add(btnPlayer2SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer2AddPoint.Location.X, btnPlayer2AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 2 players

            //if 3 players
            if (int.Parse(numPlayers) == 3)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                //player 2
                lblPlayer2Name.Name = "lblPlayer2Name";
                lblPlayer2Name.Location = new Point(lblPlayer1Name.Location.X, lblPlayer1Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Name.ForeColor = Color.SlateGray;
                lblPlayer2Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Name.Text = newPlayer.namesArray[1];
                lblPlayer2Name.AutoSize = true;
                Controls.Add(lblPlayer2Name);

                lblPlayer2Points.Name = "lblPlayer2Points";
                lblPlayer2Points.Location = new Point(lblPlayer1Points.Location.X, lblPlayer1Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Points.ForeColor = Color.SlateGray;
                lblPlayer2Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Points.Text = "0";
                lblPlayer2Points.AutoSize = true;
                Controls.Add(lblPlayer2Points);

                btnPlayer2AddPoint.Name = "btnPlayer2AddPoint";
                btnPlayer2AddPoint.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2AddPoint.BackColor = Color.SlateGray;
                btnPlayer2AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer2AddPoint.Text = "+";
                btnPlayer2AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2AddPoint_Click);
                Controls.Add(btnPlayer2AddPoint);

                btnPlayer2SubPoint.Name = "btnPlayer2SubPoint";
                btnPlayer2SubPoint.Location = new Point(btnPlayer1SubPoint.Location.X, btnPlayer1SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2SubPoint.BackColor = Color.SlateGray;
                btnPlayer2SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer2SubPoint.Text = "-";
                btnPlayer2SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2SubPoint.Click += new EventHandler(BtnPlayer2SubPoint_Click);
                Controls.Add(btnPlayer2SubPoint);

                //player 3
                lblPlayer3Name.Name = "lblPlayer3Name";
                lblPlayer3Name.Location = new Point(lblPlayer2Name.Location.X, lblPlayer2Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Name.ForeColor = Color.SlateGray;
                lblPlayer3Name.Font = new Font(lblPlayer3Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Name.Text = newPlayer.namesArray[2];
                lblPlayer3Name.AutoSize = true;
                Controls.Add(lblPlayer3Name);

                lblPlayer3Points.Name = "lblPlayer3Points";
                lblPlayer3Points.Location = new Point(lblPlayer2Points.Location.X, lblPlayer2Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Points.ForeColor = Color.SlateGray;
                lblPlayer3Points.Font = new Font(lblPlayer3Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Points.Text = "0";
                lblPlayer3Points.AutoSize = true;
                Controls.Add(lblPlayer3Points);

                btnPlayer3AddPoint.Name = "btnPlayer3AddPoint";
                btnPlayer3AddPoint.Location = new Point(btnPlayer2AddPoint.Location.X, btnPlayer2AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3AddPoint.BackColor = Color.SlateGray;
                btnPlayer3AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer3AddPoint.Text = "+";
                btnPlayer3AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3AddPoint.Click += new EventHandler(BtnPlayer3AddPoint_Click);
                Controls.Add(btnPlayer3AddPoint);

                btnPlayer3SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer3SubPoint.Location = new Point(btnPlayer2SubPoint.Location.X, btnPlayer2SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3SubPoint.BackColor = Color.SlateGray;
                btnPlayer3SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer3SubPoint.Text = "-";
                btnPlayer3SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3SubPoint.Click += new EventHandler(BtnPlayer3SubPoint_Click);
                Controls.Add(btnPlayer3SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer3AddPoint.Location.X, btnPlayer3AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 3 players

            //if 4 players
            if(int.Parse(numPlayers) == 4)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                //player 2
                lblPlayer2Name.Name = "lblPlayer2Name";
                lblPlayer2Name.Location = new Point(lblPlayer1Name.Location.X, lblPlayer1Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Name.ForeColor = Color.SlateGray;
                lblPlayer2Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Name.Text = newPlayer.namesArray[1];
                lblPlayer2Name.AutoSize = true;
                Controls.Add(lblPlayer2Name);

                lblPlayer2Points.Name = "lblPlayer2Points";
                lblPlayer2Points.Location = new Point(lblPlayer1Points.Location.X, lblPlayer1Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Points.ForeColor = Color.SlateGray;
                lblPlayer2Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Points.Text = "0";
                lblPlayer2Points.AutoSize = true;
                Controls.Add(lblPlayer2Points);

                btnPlayer2AddPoint.Name = "btnPlayer2AddPoint";
                btnPlayer2AddPoint.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2AddPoint.BackColor = Color.SlateGray;
                btnPlayer2AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer2AddPoint.Text = "+";
                btnPlayer2AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2AddPoint_Click);
                Controls.Add(btnPlayer2AddPoint);

                btnPlayer2SubPoint.Name = "btnPlayer2SubPoint";
                btnPlayer2SubPoint.Location = new Point(btnPlayer1SubPoint.Location.X, btnPlayer1SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2SubPoint.BackColor = Color.SlateGray;
                btnPlayer2SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer2SubPoint.Text = "-";
                btnPlayer2SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2SubPoint.Click += new EventHandler(BtnPlayer2SubPoint_Click);
                Controls.Add(btnPlayer2SubPoint);

                //player 3
                lblPlayer3Name.Name = "lblPlayer3Name";
                lblPlayer3Name.Location = new Point(lblPlayer2Name.Location.X, lblPlayer2Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Name.ForeColor = Color.SlateGray;
                lblPlayer3Name.Font = new Font(lblPlayer3Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Name.Text = newPlayer.namesArray[2];
                lblPlayer3Name.AutoSize = true;
                Controls.Add(lblPlayer3Name);

                lblPlayer3Points.Name = "lblPlayer3Points";
                lblPlayer3Points.Location = new Point(lblPlayer2Points.Location.X, lblPlayer2Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Points.ForeColor = Color.SlateGray;
                lblPlayer3Points.Font = new Font(lblPlayer3Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Points.Text = "0";
                lblPlayer3Points.AutoSize = true;
                Controls.Add(lblPlayer3Points);

                btnPlayer3AddPoint.Name = "btnPlayer3AddPoint";
                btnPlayer3AddPoint.Location = new Point(btnPlayer2AddPoint.Location.X, btnPlayer2AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3AddPoint.BackColor = Color.SlateGray;
                btnPlayer3AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer3AddPoint.Text = "+";
                btnPlayer3AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3AddPoint.Click += new EventHandler(BtnPlayer3AddPoint_Click);
                Controls.Add(btnPlayer3AddPoint);

                btnPlayer3SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer3SubPoint.Location = new Point(btnPlayer2SubPoint.Location.X, btnPlayer2SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3SubPoint.BackColor = Color.SlateGray;
                btnPlayer3SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer3SubPoint.Text = "-";
                btnPlayer3SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3SubPoint.Click += new EventHandler(BtnPlayer3SubPoint_Click);
                Controls.Add(btnPlayer3SubPoint);

                //player 4
                lblPlayer4Name.Name = "lblPlayer4Name";
                lblPlayer4Name.Location = new Point(lblPlayer3Name.Location.X, lblPlayer3Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Name.ForeColor = Color.SlateGray;
                lblPlayer4Name.Font = new Font(lblPlayer4Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Name.Text = newPlayer.namesArray[3];
                lblPlayer4Name.AutoSize = true;
                Controls.Add(lblPlayer4Name);

                lblPlayer4Points.Name = "lblPlayer4Points";
                lblPlayer4Points.Location = new Point(lblPlayer3Points.Location.X, lblPlayer3Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Points.ForeColor = Color.SlateGray;
                lblPlayer4Points.Font = new Font(lblPlayer4Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Points.Text = "0";
                lblPlayer4Points.AutoSize = true;
                Controls.Add(lblPlayer4Points);

                btnPlayer4AddPoint.Name = "btnPlayer4AddPoint";
                btnPlayer4AddPoint.Location = new Point(btnPlayer3AddPoint.Location.X, btnPlayer3AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4AddPoint.BackColor = Color.SlateGray;
                btnPlayer4AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer4AddPoint.Text = "+";
                btnPlayer4AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4AddPoint.Click += new EventHandler(BtnPlayer4AddPoint_Click);
                Controls.Add(btnPlayer4AddPoint);

                btnPlayer4SubPoint.Name = "btnPlayer4SubPoint";
                btnPlayer4SubPoint.Location = new Point(btnPlayer3SubPoint.Location.X, btnPlayer3SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4SubPoint.BackColor = Color.SlateGray;
                btnPlayer4SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer4SubPoint.Text = "-";
                btnPlayer4SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4SubPoint.Click += new EventHandler(BtnPlayer4SubPoint_Click);
                Controls.Add(btnPlayer4SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer4AddPoint.Location.X, btnPlayer4AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 4 players
            if (int.Parse(numPlayers) == 5)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                //player 2
                lblPlayer2Name.Name = "lblPlayer2Name";
                lblPlayer2Name.Location = new Point(lblPlayer1Name.Location.X, lblPlayer1Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Name.ForeColor = Color.SlateGray;
                lblPlayer2Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Name.Text = newPlayer.namesArray[1];
                lblPlayer2Name.AutoSize = true;
                Controls.Add(lblPlayer2Name);

                lblPlayer2Points.Name = "lblPlayer2Points";
                lblPlayer2Points.Location = new Point(lblPlayer1Points.Location.X, lblPlayer1Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Points.ForeColor = Color.SlateGray;
                lblPlayer2Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Points.Text = "0";
                lblPlayer2Points.AutoSize = true;
                Controls.Add(lblPlayer2Points);

                btnPlayer2AddPoint.Name = "btnPlayer2AddPoint";
                btnPlayer2AddPoint.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2AddPoint.BackColor = Color.SlateGray;
                btnPlayer2AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer2AddPoint.Text = "+";
                btnPlayer2AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2AddPoint_Click);
                Controls.Add(btnPlayer2AddPoint);

                btnPlayer2SubPoint.Name = "btnPlayer2SubPoint";
                btnPlayer2SubPoint.Location = new Point(btnPlayer1SubPoint.Location.X, btnPlayer1SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2SubPoint.BackColor = Color.SlateGray;
                btnPlayer2SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer2SubPoint.Text = "-";
                btnPlayer2SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2SubPoint.Click += new EventHandler(BtnPlayer2SubPoint_Click);
                Controls.Add(btnPlayer2SubPoint);

                //player 3
                lblPlayer3Name.Name = "lblPlayer3Name";
                lblPlayer3Name.Location = new Point(lblPlayer2Name.Location.X, lblPlayer2Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Name.ForeColor = Color.SlateGray;
                lblPlayer3Name.Font = new Font(lblPlayer3Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Name.Text = newPlayer.namesArray[2];
                lblPlayer3Name.AutoSize = true;
                Controls.Add(lblPlayer3Name);

                lblPlayer3Points.Name = "lblPlayer3Points";
                lblPlayer3Points.Location = new Point(lblPlayer2Points.Location.X, lblPlayer2Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Points.ForeColor = Color.SlateGray;
                lblPlayer3Points.Font = new Font(lblPlayer3Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Points.Text = "0";
                lblPlayer3Points.AutoSize = true;
                Controls.Add(lblPlayer3Points);

                btnPlayer3AddPoint.Name = "btnPlayer3AddPoint";
                btnPlayer3AddPoint.Location = new Point(btnPlayer2AddPoint.Location.X, btnPlayer2AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3AddPoint.BackColor = Color.SlateGray;
                btnPlayer3AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer3AddPoint.Text = "+";
                btnPlayer3AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3AddPoint.Click += new EventHandler(BtnPlayer3AddPoint_Click);
                Controls.Add(btnPlayer3AddPoint);

                btnPlayer3SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer3SubPoint.Location = new Point(btnPlayer2SubPoint.Location.X, btnPlayer2SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3SubPoint.BackColor = Color.SlateGray;
                btnPlayer3SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer3SubPoint.Text = "-";
                btnPlayer3SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3SubPoint.Click += new EventHandler(BtnPlayer3SubPoint_Click);
                Controls.Add(btnPlayer3SubPoint);

                //player 4
                lblPlayer4Name.Name = "lblPlayer4Name";
                lblPlayer4Name.Location = new Point(lblPlayer3Name.Location.X, lblPlayer3Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Name.ForeColor = Color.SlateGray;
                lblPlayer4Name.Font = new Font(lblPlayer4Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Name.Text = newPlayer.namesArray[3];
                lblPlayer4Name.AutoSize = true;
                Controls.Add(lblPlayer4Name);

                lblPlayer4Points.Name = "lblPlayer4Points";
                lblPlayer4Points.Location = new Point(lblPlayer3Points.Location.X, lblPlayer3Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Points.ForeColor = Color.SlateGray;
                lblPlayer4Points.Font = new Font(lblPlayer4Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Points.Text = "0";
                lblPlayer4Points.AutoSize = true;
                Controls.Add(lblPlayer4Points);

                btnPlayer4AddPoint.Name = "btnPlayer4AddPoint";
                btnPlayer4AddPoint.Location = new Point(btnPlayer3AddPoint.Location.X, btnPlayer3AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4AddPoint.BackColor = Color.SlateGray;
                btnPlayer4AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer4AddPoint.Text = "+";
                btnPlayer4AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4AddPoint.Click += new EventHandler(BtnPlayer4AddPoint_Click);
                Controls.Add(btnPlayer4AddPoint);

                btnPlayer4SubPoint.Name = "btnPlayer4SubPoint";
                btnPlayer4SubPoint.Location = new Point(btnPlayer3SubPoint.Location.X, btnPlayer3SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4SubPoint.BackColor = Color.SlateGray;
                btnPlayer4SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer4SubPoint.Text = "-";
                btnPlayer4SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4SubPoint.Click += new EventHandler(BtnPlayer4SubPoint_Click);
                Controls.Add(btnPlayer4SubPoint);

                //player 5
                lblPlayer5Name.Name = "lblPlayer5Name";
                lblPlayer5Name.Location = new Point(lblPlayer4Name.Location.X, lblPlayer4Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer5Name.ForeColor = Color.SlateGray;
                lblPlayer5Name.Font = new Font(lblPlayer5Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer5Name.Text = newPlayer.namesArray[4];
                lblPlayer5Name.AutoSize = true;
                Controls.Add(lblPlayer5Name);

                lblPlayer5Points.Name = "lblPlayer5Points";
                lblPlayer5Points.Location = new Point(lblPlayer4Points.Location.X, lblPlayer4Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer5Points.ForeColor = Color.SlateGray;
                lblPlayer5Points.Font = new Font(lblPlayer5Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer5Points.Text = "0";
                lblPlayer5Points.AutoSize = true;
                Controls.Add(lblPlayer5Points);

                btnPlayer5AddPoint.Name = "btnPlayer5AddPoint";
                btnPlayer5AddPoint.Location = new Point(btnPlayer4AddPoint.Location.X, btnPlayer4AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer5AddPoint.BackColor = Color.SlateGray;
                btnPlayer5AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer5AddPoint.Text = "+";
                btnPlayer5AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer5AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer5AddPoint.Click += new EventHandler(BtnPlayer5AddPoint_Click);
                Controls.Add(btnPlayer5AddPoint);

                btnPlayer5SubPoint.Name = "btnPlayer5SubPoint";
                btnPlayer5SubPoint.Location = new Point(btnPlayer4SubPoint.Location.X, btnPlayer4SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer5SubPoint.BackColor = Color.SlateGray;
                btnPlayer5SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer5SubPoint.Text = "-";
                btnPlayer5SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer5SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer5SubPoint.Click += new EventHandler(BtnPlayer5SubPoint_Click);
                Controls.Add(btnPlayer5SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer5AddPoint.Location.X, btnPlayer5AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 5 players
            //if 6 players
            if (int.Parse(numPlayers) == 6)
            {
                //player 1
                lblPlayer1Name.Name = "lblPlayer1Name";
                lblPlayer1Name.Location = userControlLoc;
                lblPlayer1Name.ForeColor = Color.SlateGray;
                lblPlayer1Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Name.Text = newPlayer.namesArray[0];
                lblPlayer1Name.AutoSize = true;
                Controls.Add(lblPlayer1Name);

                lblPlayer1Points.Name = "lblPlayer1Points";
                lblPlayer1Points.Location = new Point(userControlLoc.X + OFFSET, userControlLoc.Y);
                lblPlayer1Points.ForeColor = Color.SlateGray;
                lblPlayer1Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer1Points.Text = "0";
                lblPlayer1Points.AutoSize = true;
                Controls.Add(lblPlayer1Points);

                btnPlayer1AddPoint.Name = "btnPlayer1AddPoint";
                btnPlayer1AddPoint.Location = new Point(lblPlayer1Points.Location.X + LBL_OFFSET_X, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1AddPoint.BackColor = Color.SlateGray;
                btnPlayer1AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer1AddPoint.Text = "+";
                btnPlayer1AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1AddPoint.Click += new EventHandler(BtnPlayer1AddPoint_Click);
                Controls.Add(btnPlayer1AddPoint);

                btnPlayer1SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer1SubPoint.Location = new Point(btnPlayer1AddPoint.Location.X + BTN_ADD_SUB_OFFSET, lblPlayer1Points.Location.Y - ADD_BTN_Y_OFFSET);
                btnPlayer1SubPoint.BackColor = Color.SlateGray;
                btnPlayer1SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer1SubPoint.Text = "-";
                btnPlayer1SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer1SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer1SubPoint.Click += new EventHandler(BtnPlayer1SubPoint_Click);
                Controls.Add(btnPlayer1SubPoint);

                //player 2
                lblPlayer2Name.Name = "lblPlayer2Name";
                lblPlayer2Name.Location = new Point(lblPlayer1Name.Location.X, lblPlayer1Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Name.ForeColor = Color.SlateGray;
                lblPlayer2Name.Font = new Font(lblPlayer1Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Name.Text = newPlayer.namesArray[1];
                lblPlayer2Name.AutoSize = true;
                Controls.Add(lblPlayer2Name);

                lblPlayer2Points.Name = "lblPlayer2Points";
                lblPlayer2Points.Location = new Point(lblPlayer1Points.Location.X, lblPlayer1Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer2Points.ForeColor = Color.SlateGray;
                lblPlayer2Points.Font = new Font(lblPlayer1Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer2Points.Text = "0";
                lblPlayer2Points.AutoSize = true;
                Controls.Add(lblPlayer2Points);

                btnPlayer2AddPoint.Name = "btnPlayer2AddPoint";
                btnPlayer2AddPoint.Location = new Point(btnPlayer1AddPoint.Location.X, btnPlayer1AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2AddPoint.BackColor = Color.SlateGray;
                btnPlayer2AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer2AddPoint.Text = "+";
                btnPlayer2AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2AddPoint.Click += new EventHandler(BtnPlayer2AddPoint_Click);
                Controls.Add(btnPlayer2AddPoint);

                btnPlayer2SubPoint.Name = "btnPlayer2SubPoint";
                btnPlayer2SubPoint.Location = new Point(btnPlayer1SubPoint.Location.X, btnPlayer1SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer2SubPoint.BackColor = Color.SlateGray;
                btnPlayer2SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer2SubPoint.Text = "-";
                btnPlayer2SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer2SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer2SubPoint.Click += new EventHandler(BtnPlayer2SubPoint_Click);
                Controls.Add(btnPlayer2SubPoint);

                //player 3
                lblPlayer3Name.Name = "lblPlayer3Name";
                lblPlayer3Name.Location = new Point(lblPlayer2Name.Location.X, lblPlayer2Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Name.ForeColor = Color.SlateGray;
                lblPlayer3Name.Font = new Font(lblPlayer3Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Name.Text = newPlayer.namesArray[2];
                lblPlayer3Name.AutoSize = true;
                Controls.Add(lblPlayer3Name);

                lblPlayer3Points.Name = "lblPlayer3Points";
                lblPlayer3Points.Location = new Point(lblPlayer2Points.Location.X, lblPlayer2Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer3Points.ForeColor = Color.SlateGray;
                lblPlayer3Points.Font = new Font(lblPlayer3Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer3Points.Text = "0";
                lblPlayer3Points.AutoSize = true;
                Controls.Add(lblPlayer3Points);

                btnPlayer3AddPoint.Name = "btnPlayer3AddPoint";
                btnPlayer3AddPoint.Location = new Point(btnPlayer2AddPoint.Location.X, btnPlayer2AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3AddPoint.BackColor = Color.SlateGray;
                btnPlayer3AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer3AddPoint.Text = "+";
                btnPlayer3AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3AddPoint.Click += new EventHandler(BtnPlayer3AddPoint_Click);
                Controls.Add(btnPlayer3AddPoint);

                btnPlayer3SubPoint.Name = "btnPlayer1SubPoint";
                btnPlayer3SubPoint.Location = new Point(btnPlayer2SubPoint.Location.X, btnPlayer2SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer3SubPoint.BackColor = Color.SlateGray;
                btnPlayer3SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer3SubPoint.Text = "-";
                btnPlayer3SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer3SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer3SubPoint.Click += new EventHandler(BtnPlayer3SubPoint_Click);
                Controls.Add(btnPlayer3SubPoint);

                //player 4
                lblPlayer4Name.Name = "lblPlayer4Name";
                lblPlayer4Name.Location = new Point(lblPlayer3Name.Location.X, lblPlayer3Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Name.ForeColor = Color.SlateGray;
                lblPlayer4Name.Font = new Font(lblPlayer4Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Name.Text = newPlayer.namesArray[3];
                lblPlayer4Name.AutoSize = true;
                Controls.Add(lblPlayer4Name);

                lblPlayer4Points.Name = "lblPlayer4Points";
                lblPlayer4Points.Location = new Point(lblPlayer3Points.Location.X, lblPlayer3Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer4Points.ForeColor = Color.SlateGray;
                lblPlayer4Points.Font = new Font(lblPlayer4Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer4Points.Text = "0";
                lblPlayer4Points.AutoSize = true;
                Controls.Add(lblPlayer4Points);

                btnPlayer4AddPoint.Name = "btnPlayer4AddPoint";
                btnPlayer4AddPoint.Location = new Point(btnPlayer3AddPoint.Location.X, btnPlayer3AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4AddPoint.BackColor = Color.SlateGray;
                btnPlayer4AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer4AddPoint.Text = "+";
                btnPlayer4AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4AddPoint.Click += new EventHandler(BtnPlayer4AddPoint_Click);
                Controls.Add(btnPlayer4AddPoint);

                btnPlayer4SubPoint.Name = "btnPlayer4SubPoint";
                btnPlayer4SubPoint.Location = new Point(btnPlayer3SubPoint.Location.X, btnPlayer3SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer4SubPoint.BackColor = Color.SlateGray;
                btnPlayer4SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer4SubPoint.Text = "-";
                btnPlayer4SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer4SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer4SubPoint.Click += new EventHandler(BtnPlayer4SubPoint_Click);
                Controls.Add(btnPlayer4SubPoint);

                //player 5
                lblPlayer5Name.Name = "lblPlayer5Name";
                lblPlayer5Name.Location = new Point(lblPlayer4Name.Location.X, lblPlayer4Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer5Name.ForeColor = Color.SlateGray;
                lblPlayer5Name.Font = new Font(lblPlayer5Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer5Name.Text = newPlayer.namesArray[4];
                lblPlayer5Name.AutoSize = true;
                Controls.Add(lblPlayer5Name);

                lblPlayer5Points.Name = "lblPlayer5Points";
                lblPlayer5Points.Location = new Point(lblPlayer4Points.Location.X, lblPlayer4Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer5Points.ForeColor = Color.SlateGray;
                lblPlayer5Points.Font = new Font(lblPlayer5Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer5Points.Text = "0";
                lblPlayer5Points.AutoSize = true;
                Controls.Add(lblPlayer5Points);

                btnPlayer5AddPoint.Name = "btnPlayer5AddPoint";
                btnPlayer5AddPoint.Location = new Point(btnPlayer4AddPoint.Location.X, btnPlayer4AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer5AddPoint.BackColor = Color.SlateGray;
                btnPlayer5AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer5AddPoint.Text = "+";
                btnPlayer5AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer5AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer5AddPoint.Click += new EventHandler(BtnPlayer5AddPoint_Click);
                Controls.Add(btnPlayer5AddPoint);

                btnPlayer5SubPoint.Name = "btnPlayer5SubPoint";
                btnPlayer5SubPoint.Location = new Point(btnPlayer4SubPoint.Location.X, btnPlayer4SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer5SubPoint.BackColor = Color.SlateGray;
                btnPlayer5SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer5SubPoint.Text = "-";
                btnPlayer5SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer5SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer5SubPoint.Click += new EventHandler(BtnPlayer5SubPoint_Click);
                Controls.Add(btnPlayer5SubPoint);

                //player 6
                lblPlayer6Name.Name = "lblPlayer6Name";
                lblPlayer6Name.Location = new Point(lblPlayer5Name.Location.X, lblPlayer5Name.Location.Y + LBL_OFFSET_Y);
                lblPlayer6Name.ForeColor = Color.SlateGray;
                lblPlayer6Name.Font = new Font(lblPlayer6Name.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer6Name.Text = newPlayer.namesArray[5];
                lblPlayer6Name.AutoSize = true;
                Controls.Add(lblPlayer6Name);

                lblPlayer6Points.Name = "lblPlayer6Points";
                lblPlayer6Points.Location = new Point(lblPlayer5Points.Location.X, lblPlayer5Points.Location.Y + LBL_OFFSET_Y);
                lblPlayer6Points.ForeColor = Color.SlateGray;
                lblPlayer6Points.Font = new Font(lblPlayer6Points.Font.FontFamily, 20, FontStyle.Bold);
                lblPlayer6Points.Text = "0";
                lblPlayer6Points.AutoSize = true;
                Controls.Add(lblPlayer6Points);

                btnPlayer6AddPoint.Name = "btnPlayer6AddPoint";
                btnPlayer6AddPoint.Location = new Point(btnPlayer5AddPoint.Location.X, btnPlayer5AddPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer6AddPoint.BackColor = Color.SlateGray;
                btnPlayer6AddPoint.ForeColor = Color.GhostWhite;
                btnPlayer6AddPoint.Text = "+";
                btnPlayer6AddPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer6AddPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer6AddPoint.Click += new EventHandler(BtnPlayer6AddPoint_Click);
                Controls.Add(btnPlayer6AddPoint);

                btnPlayer6SubPoint.Name = "btnPlayer6SubPoint";
                btnPlayer6SubPoint.Location = new Point(btnPlayer5SubPoint.Location.X, btnPlayer5SubPoint.Location.Y + LBL_OFFSET_Y);
                btnPlayer6SubPoint.BackColor = Color.SlateGray;
                btnPlayer6SubPoint.ForeColor = Color.GhostWhite;
                btnPlayer6SubPoint.Text = "-";
                btnPlayer6SubPoint.Width = BTN_ADD_SUB_WIDTH;
                btnPlayer6SubPoint.Height = BTN_ADD_SUB_HEIGHT;
                btnPlayer6SubPoint.Click += new EventHandler(BtnPlayer6SubPoint_Click);
                Controls.Add(btnPlayer6SubPoint);

                btnGameOver.Name = "btnGameOver";
                btnGameOver.Location = new Point(btnPlayer6AddPoint.Location.X, btnPlayer6AddPoint.Location.Y + LBL_OFFSET_Y);
                btnGameOver.Text = "Game Over?";
                btnGameOver.BackColor = Color.SlateGray;
                btnGameOver.ForeColor = Color.GhostWhite;
                btnGameOver.Width = BTN_GAME_OVER_WIDTH;
                btnGameOver.Height = BTN_GAME_OVER_HEIGHT;
                btnGameOver.Click += new EventHandler(BtnGameOver_Click);
                Controls.Add(btnGameOver);
            }//end if 6 players

        }//end StartGame

        private void RemoveNumPlayerControls()
        {
            Controls.Remove(btnSetUsers);
            Controls.Remove(tbNumPlayers);
        }
        private void RemoveAddPlayerControls()
        {
            Controls.Remove(btnStartGame);
            Controls.Remove(lblCaption2);
            Controls.Remove(lblCaption);
        }

        private void ShowStartBtn()
        {
            Controls.Remove(btnAddPlayer);
            Controls.Add(btnStartGame);
            btnStartGame.Focus();
        }

        private void RemovePlayerControls()
        {
            Controls.Remove(lblPlayer1Name);
            Controls.Remove(lblPlayer1Points);
            Controls.Remove(btnPlayer1AddPoint);
            Controls.Remove(btnPlayer1SubPoint);

            Controls.Remove(lblPlayer2Name);
            Controls.Remove(lblPlayer2Points);
            Controls.Remove(btnPlayer2AddPoint);
            Controls.Remove(btnPlayer2SubPoint);

            Controls.Remove(lblPlayer3Name);
            Controls.Remove(lblPlayer3Points);
            Controls.Remove(btnPlayer3AddPoint);
            Controls.Remove(btnPlayer3SubPoint);

            Controls.Remove(lblPlayer4Name);
            Controls.Remove(lblPlayer4Points);
            Controls.Remove(btnPlayer4AddPoint);
            Controls.Remove(btnPlayer4SubPoint);

            Controls.Remove(lblPlayer5Name);
            Controls.Remove(lblPlayer5Points);
            Controls.Remove(btnPlayer5AddPoint);
            Controls.Remove(btnPlayer5SubPoint);

            Controls.Remove(lblPlayer6Name);
            Controls.Remove(lblPlayer6Points);
            Controls.Remove(btnPlayer6AddPoint);
            Controls.Remove(btnPlayer6SubPoint);
        }//end removePlayerControls

        private void DisplayWinner()
        {
            RemovePlayerControls();
            Controls.Add(lblCaption);

                if (int.Parse(numPlayers) == 1)
                {
                    winnerScore = gameManager.FindWinner(player1Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text;
                    }

                }
                if (int.Parse(numPlayers) == 2)
                {
                    winnerScore = gameManager.FindWinner(player1Score, player2Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text + " ";
                    }
                    if (winnerScore == player2Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer2Name.Text + " ";
                        btnGameOver.Location = new Point(200, 200);
                    }
                }
                if (int.Parse(numPlayers) == 3)
                {
                    winnerScore = gameManager.FindWinner(player1Score, player2Score, player3Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text + " ";
                    }
                    if (winnerScore == player2Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer2Name.Text + " ";
                    }
                    if (winnerScore == player3Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer3Name.Text + " ";
                    }
                }
                if (int.Parse(numPlayers) == 4)
                {
                    winnerScore = gameManager.FindWinner(player1Score, player2Score, player3Score, player4Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text + " ";
                    }
                    if (winnerScore == player2Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer2Name.Text + " ";
                    }
                    if (winnerScore == player3Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer3Name.Text + " " +"\n";
                    }
                    if (winnerScore == player4Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer4Name.Text + " ";
                    }
                }
                if (int.Parse(numPlayers) == 5)
                {
                    winnerScore = gameManager.FindWinner(player1Score, player2Score, player3Score, player4Score, player5Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text + " ";
                    }
                    if (winnerScore == player2Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer2Name.Text + " ";
                    }
                    if (winnerScore == player3Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer3Name.Text + " " + "\n";
                    }
                    if (winnerScore == player4Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer4Name.Text + " ";
                    }
                    if (winnerScore == player5Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer5Name.Text + " ";
                    }
                }
                if (int.Parse(numPlayers) == 6)
                {
                    winnerScore = gameManager.FindWinner(player1Score, player2Score, player3Score, player4Score, player5Score, player6Score);
                    if (winnerScore == player1Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer1Name.Text + " ";
                    }
                    if (winnerScore == player2Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer2Name.Text + " ";
                    }
                    if (winnerScore == player3Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer3Name.Text + " " +"\n";
                    }
                    if (winnerScore == player4Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer4Name.Text + " ";
                    }
                    if (winnerScore == player5Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer5Name.Text + " ";
                    }
                    if (winnerScore == player6Score)
                    {
                    numWinners += 1;
                    winner += lblPlayer6Name.Text + " ";
                    }//end if winnner player 6
                }//end if 6 players

            if (numWinners > 1)
            {
                lblCaption.TextAlign = ContentAlignment.MiddleCenter;
                lblCaption.Dock = DockStyle.Fill;
                lblCaption.AutoSize = false;
                lblCaption.Text = winner + "\n" + " Win!";//Display the winners
            }
            else
            {
                lblCaption.TextAlign = ContentAlignment.MiddleCenter;
                lblCaption.Dock = DockStyle.Fill;
                lblCaption.AutoSize = false;
                lblCaption.Text = winner + "\n" + " Wins!";//Display the winners
            }
            btnGameOver.Location = new Point(200, 200);
        }//end display winner

        //EventHandlers

        //btnSetUsers
        public void SetNumPlayers(object sender, EventArgs e)
        {
                if (lblCaption2.Text == "1" || lblCaption2.Text == "2" || lblCaption2.Text == "3" || lblCaption2.Text == "4" || lblCaption2.Text == "5" || lblCaption2.Text == "6")
                {
                    if (int.Parse(lblCaption2.Text) > 0 & int.Parse(lblCaption2.Text) <= 6)
                    {
                        numPlayers = lblCaption2.Text;
                        newPlayer.SetNumPlayers(int.Parse(lblCaption2.Text));
                        RemoveNumPlayerControls();
                        ShowAddPlayerControls();
                    }//end if
                }//end if
                else
                {
                    lblCaption.Text = "Only numbers allowed " + "and \n" + "1 to 6 players";
                    tbNumPlayers.Focus();
                }   
        }

        //tbNumPlayers
        private void TbNumPlayers_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblCaption2.Text = e.KeyChar.ToString();
            btnSetUsers.Focus();
        }
        private void TbNumPlayers_KeyUp(object sender, KeyEventArgs e)
        {
            tbNumPlayers.Text = "";
        }
        //tbPlayerName
        private void OnKeyDownHandler(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                    if (i <= int.Parse(numPlayers))
                    {
                        if (i == int.Parse(numPlayers))
                        {
                            Controls.Remove(tbPlayerName);
                            ShowStartBtn();
                        }

                        newPlayer.AddPlayerToArray(tbPlayerName.Text.ToUpper());
                        tbPlayerName.Focus();
                        tbPlayerName.SelectAll();
                        lblCaption2.Text = tbPlayerName.Text.ToUpper() + " has been added";
                        i++;
                    }//end if i< numPlayers
       
            }//end if e.KeyChar == 13

        }//onKeyDownHandler


        //btnAddPlayer
        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            if (i <= int.Parse(numPlayers))
            {
                if(i == int.Parse(numPlayers))
                {
                    Controls.Remove(tbPlayerName);
                    ShowStartBtn();
                }

                newPlayer.AddPlayerToArray(tbPlayerName.Text.ToUpper());
                tbPlayerName.Focus();
                tbPlayerName.SelectAll();
                lblCaption2.Text = tbPlayerName.Text.ToUpper() + " has been added";
                i++;
            }
        }
        //btnStartGame
        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            SetUpGameScreen();
        }

        //BtnPlayer1AddPoint_Click
        private void BtnPlayer1AddPoint_Click(object sender, EventArgs e)
        {
            player1Score += 1;
            lblPlayer1Points.Text = player1Score.ToString();

        }
        //BtnPlayer2AddPoint_Click
        private void BtnPlayer2AddPoint_Click(object sender, EventArgs e)
        {
            player2Score += 1;
            lblPlayer2Points.Text = player2Score.ToString();
        }
        //BtnPlayer3AddPoint_Click
        private void BtnPlayer3AddPoint_Click(object sender, EventArgs e)
        {
            player3Score += 1;
            lblPlayer3Points.Text = player3Score.ToString();
        }
        //BtnPlayer4AddPoint_Click
        private void BtnPlayer4AddPoint_Click(object sender, EventArgs e)
        {
            player4Score += 1;
            lblPlayer4Points.Text = player4Score.ToString();
        }
        //BtnPlayer5AddPoint_Click
        private void BtnPlayer5AddPoint_Click(object sender, EventArgs e)
        {
            player5Score += 1;
            lblPlayer5Points.Text = player5Score.ToString();
        }
        //BtnPlayer6AddPoint_Click
        private void BtnPlayer6AddPoint_Click(object sender, EventArgs e)
        {
            player6Score += 1;
            lblPlayer6Points.Text = player6Score.ToString();
        }

        //BtnPlayer1SubPoint_Click
        private void BtnPlayer1SubPoint_Click(object sender, EventArgs e)
        {
            if (player1Score > 0)
            {
                player1Score -= 1;
                lblPlayer1Points.Text = player1Score.ToString();
            }
        }//end BtnPlayer1SubPoint_Click
        //BtnPlayer2SubPoint_Click
        private void BtnPlayer2SubPoint_Click(object sender, EventArgs e)
        {
            if (player2Score > 0)
            {
                player2Score -= 1;
                lblPlayer2Points.Text = player2Score.ToString();
            }
        }//end BtnPlayer2SubPoint_Click
        //BtnPlayer3SubPoint_Click
        private void BtnPlayer3SubPoint_Click(object sender, EventArgs e)
        {
            if (player3Score > 0)
            {
                player3Score -= 1;
                lblPlayer3Points.Text = player3Score.ToString();
            }
        }//end BtnPlayer3SubPoint_Click
        //BtnPlayer4SubPoint_Click
        private void BtnPlayer4SubPoint_Click(object sender, EventArgs e)
        {
            if (player4Score > 0)
            {
                player4Score -= 1;
                lblPlayer4Points.Text = player4Score.ToString();
            }
        }//end BtnPlayer4SubPoint_Click
        //BtnPlayer5SubPoint_Click
        private void BtnPlayer5SubPoint_Click(object sender, EventArgs e)
        {
            if (player5Score > 0)
            {
                player5Score -= 1;
                lblPlayer5Points.Text = player5Score.ToString();
            }
        }//end BtnPlayer5SubPoint_Click
        //BtnPlayer6SubPoint_Click
        private void BtnPlayer6SubPoint_Click(object sender, EventArgs e)
        {
            if (player6Score > 0)
            {
                player6Score -= 1;
                lblPlayer6Points.Text = player6Score.ToString();
            }
        }//end BtnPlayer1SubPoint_Click

        //btnGameOver Handler
        private void BtnGameOver_Click(object sender, EventArgs e)
        {
            DisplayWinner();
            Controls.Remove(btnGameOver);
        }//end btnGameOver_Click
    }//end form1 class
}//end namespace
