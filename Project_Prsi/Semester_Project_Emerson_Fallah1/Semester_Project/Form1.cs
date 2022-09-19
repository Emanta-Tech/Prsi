using System;
using System.IO;
using System.Windows.Forms;

namespace Semester_Project
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			if(File.Exists(file))
			{
				using (StreamReader files = new StreamReader(file))
				{
					int counter = 0;
					string ln;

					while ((ln = files.ReadLine()) != null)
					{
						Constants.RobotNames.Add(ln);
						counter++;
					}
					files.Close();
					Console.WriteLine($"File has {counter} lines.");
				}
			}
		}


		private void EnterGameClick(object sender, EventArgs e)
		{

			PictureBox[] pictureBoxes = { // PictureBox that holds cards for player
				pictureBox2,
				pictureBox1,
				pictureBox3,
				pictureBox4,
				pictureBox5,
				pictureBox6,
				pictureBox7,
				pictureBox8,
				pictureBox9,
				pictureBox10,
				pictureBox11,
				pictureBox12
			};



			//PlayerName = 

			var NameFromFile = Constants.RobotNames[Rands.Next(0, Constants.RobotNames.Count)];

			//RobotName = ;
			

			Players play = new Players();
			play.PlayerName = PlayerNameTextBox.Text;
			play.RobotName = NameFromFile.ToString();

			PlyerNameLabel.Text = PlayerName;
			robotNameLabel.Text = RobotName;

			PlayerNameTextBox.Enabled = false;
			EnterGameButton.Enabled = false;

			Logics.StartGame();
			ShowCards();
			PictureBoxRight.Image = imageList1.Images[0]; // Image at that index

			MessageBox.Show("GAME BEGINS!!!  YOUR OPPONENT IS :" + robotNameLabel.Text);
			Logics.PlayerMoves(this);

		}


		private void ContinueButtonClick(object sender, EventArgs e)
		{

			LabelRadioButtons.Hide();
			RadioButtonCervena.Hide();
			RadioButtonZelena.Hide();
			RadioButtonKule.Hide();
			RadioButtonZaludy.Hide();
			ContinueButton.Hide();

			string changes = "Cervena";

			if (RadioButtonCervena.Checked) { changes = "Cervena"; }
			else if (RadioButtonZelena.Checked) { changes = "Zelena"; }
			else if (RadioButtonKule.Checked) { changes = "Kule"; }
			else if (RadioButtonZaludy.Checked) { changes = "Zaludy"; }

			ShowMoves(changes);
			MessageBox.Show("You Chose " + changes);
			DisableCards();

			if (Logics.PlayerOneCardPack.Length > 0) { Logics.RobotMoves(this); }
		}

		private void PictureBoxRightClick(object sender, EventArgs e)
		{
			if (TakeTwo > 0)
			{
				for (int i = 0; i < TakeTwo; i++)
				{
					Logics.PlayerOneCardPack = Logics.DrawCard(Logics.PlayerOneCardPack);
				}

				Display(Logics.PlayerOneCardPack);
				MessageBox.Show("YOU TOOK " + TakeTwo + " cards.");
				DisableCards();
				TakeTwo = 0;

				if (Logics.PlayerOneCardPack.Length > 0) { Logics.RobotMoves(this); }

			}
			else
			{
				Logics.PlayerOneCardPack = Logics.DrawCard(Logics.PlayerOneCardPack);

				Display(Logics.PlayerOneCardPack);
				DisableCards();

				if (Logics.PlayerOneCardPack.Length > 0) { Logics.RobotMoves(this); }
			}
		}

		private void CardClick(object sender, EventArgs e)
		{
			PictureBox clicking = (PictureBox)sender;
			bool changes = false;
			int takeTwo = this.TakeTwo;
			bool eso = this.Eso;

			if (clicking.Tag != null)
			{
				if (Logics.Moves(clicking.Tag.ToString(), ref takeTwo, ref eso, out changes))
				{

					if (changes)
					{
						Logics.PlayerOneCardPack = Logics.RemoveFromCardPack(clicking.Tag.ToString(), Logics.PlayerOneCardPack);
						this.Eso = eso;
						this.TakeTwo = takeTwo;
						WaitForInput();
					}
					else
					{
						Logics.PlayerOneCardPack = Logics.RemoveFromCardPack(clicking.Tag.ToString(), Logics.PlayerOneCardPack);
						ShowMoves(clicking.Tag.ToString());
						DisableCards();
						this.Eso = eso;
						this.TakeTwo = takeTwo;

						if (Logics.PlayerOneCardPack.Length > 0) { Logics.RobotMoves(this); }
					}
				}
			}
		}

		public void Display(string[] cardPack)
		{
			if (Eso)
			{

				Eso = false;
				MessageBox.Show("STOJIS!!! - " + RobotName + " HAS THE MOVE.");
				DisableCards();
				Logics.RobotMoves(this);

			}
			else if (Logics.PlayerOneCardPack.Length == 0)
			{

				TotalNumberOfCardsLabel.Text = "No. Of Cards: " + Logics.CardPack.Length.ToString();
				PlyerNumberOfCardsLabel.Text = Logics.PlayerOneCardPack.Length.ToString() + " cards";
				RobotNumberOfCardsLabel.Text = Logics.PlayerTwoCardPack.Length.ToString() + " cards";

				int index = imageList1.Images.IndexOfKey(Logics.holdingCard + ".png");
				PictureBoxLeft.Image = imageList1.Images[index];
				PictureBoxLeft.Tag = Logics.holdingCard;
				MessageBox.Show(PlayerName + "   W O N!!!");
				MessageBox.Show(" G A M E    E X I T I N G    A N D   C L O S I N G!!! ");
				HideCards();
				DisableCards();
				PlayerNameTextBox.Enabled = true;
				EnterGameButton.Enabled = true;

			}
			else if (Logics.PlayerTwoCardPack.Length == 0)
			{

				TotalNumberOfCardsLabel.Text = "No. Of Cards: " + Logics.CardPack.Length.ToString();
				PlyerNumberOfCardsLabel.Text = Logics.PlayerOneCardPack.Length.ToString() + " cards";
				RobotNumberOfCardsLabel.Text = Logics.PlayerTwoCardPack.Length.ToString() + " cards";

				int index = imageList1.Images.IndexOfKey(Logics.holdingCard + ".png");
				PictureBoxLeft.Image = imageList1.Images[index];
				PictureBoxLeft.Tag = Logics.holdingCard;
				MessageBox.Show(RobotName + "   W O N!!!");
				MessageBox.Show(" G A M E    E X I T I N G    A N D   C L O S I N G!!! ");
				HideCards();
				DisableCards();
				PlayerNameTextBox.Enabled = true;
				EnterGameButton.Enabled = true;

			}
			else
			{

				PictureBox[] cards = {
				pictureBox2,
				pictureBox1,
				pictureBox3,
				pictureBox4,
				pictureBox5,
				pictureBox6,
				pictureBox7,
				pictureBox8,
				pictureBox9,
				pictureBox10,
				pictureBox11,
				pictureBox12
			};

				foreach (PictureBox card in cards) { card.Image = null; card.Tag = null; }

				for (int i = 0; i < cardPack.Length; i++)
				{
					int eachCard = imageList1.Images.IndexOfKey(cardPack[i] + ".png");
					cards[i].Image = imageList1.Images[eachCard];
					cards[i].Tag = cardPack[i];
					cards[i].Enabled = true;
				}

				PictureBoxRight.Enabled = true;
				TotalNumberOfCardsLabel.Text = "No. Of Cards: " + Logics.CardPack.Length.ToString();
				PlyerNumberOfCardsLabel.Text = Logics.PlayerOneCardPack.Length.ToString() + " cards";
				RobotNumberOfCardsLabel.Text = Logics.PlayerTwoCardPack.Length.ToString() + " cards";

				int index = imageList1.Images.IndexOfKey(Logics.holdingCard + ".png");
				PictureBoxLeft.Image = imageList1.Images[index];
				PictureBoxLeft.Tag = Logics.holdingCard;

			}
		}

		public void ShowMoves(string card)
		{
			Logics.holdingCard = card;
			Display(Logics.PlayerOneCardPack);

		}

		public void HideCards()
		{
			pictureBox1.Hide();
			pictureBox2.Hide();
			pictureBox3.Hide();
			pictureBox4.Hide();
			pictureBox5.Hide();
			pictureBox6.Hide();
			pictureBox7.Hide();
			pictureBox8.Hide();
			pictureBox9.Hide();
			pictureBox10.Hide();
			pictureBox11.Hide();
			pictureBox12.Hide();
			PictureBoxLeft.Hide();
			PictureBoxRight.Hide();

			PlyerNameLabel.Hide();
			robotNameLabel.Hide();

			PlyerNumberOfCardsLabel.Hide();
			RobotNumberOfCardsLabel.Hide();
			TotalNumberOfCardsLabel.Hide();
		}

		public void ShowCards()
		{

			pictureBox1.Show();
			pictureBox2.Show();
			pictureBox3.Show();
			pictureBox4.Show();
			pictureBox5.Show();
			pictureBox6.Show();
			pictureBox7.Show();
			pictureBox8.Show();
			pictureBox9.Show();
			pictureBox10.Show();
			pictureBox11.Show();
			pictureBox12.Show();
			PictureBoxLeft.Show();
			PictureBoxRight.Show();

			PlyerNameLabel.Show();
			robotNameLabel.Show();

			PlyerNumberOfCardsLabel.Show();
			RobotNumberOfCardsLabel.Show();
			TotalNumberOfCardsLabel.Show();
		}

		public void DisableCards()
		{

			PictureBox[] pictureBoxes = {
				pictureBox1,
				pictureBox2,
				pictureBox3,
				pictureBox4,
				pictureBox5,
				pictureBox6,
				pictureBox7,
				pictureBox8,
				pictureBox9,
				pictureBox10,
				pictureBox11,
				pictureBox12
			};

			for (int i = 0; i < pictureBoxes.Length; i++) { pictureBoxes[i].Enabled = false; }

			PictureBoxRight.Enabled = false;
		}

		private void WaitForInput()
		{
			MessageBox.Show("YOU'VE PLAYED ZVRSEK, CHOOSE A COLOR");

			LabelRadioButtons.Show();
			RadioButtonCervena.Show();
			RadioButtonZelena.Show();
			RadioButtonKule.Show();
			RadioButtonZaludy.Show();
			ContinueButton.Show();

			DisableCards();
		}

		private void CardMouseEnter(object sender, EventArgs e)
		{
			// When I hover the Picture card
			PictureBox pictureBoxEnter = (PictureBox)sender;

			if (pictureBoxEnter.Tag != null)
			{
				switch (pictureBoxEnter.Name)
				{
					case "pictureBox1": { pictureBox1Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox2": { pictureBox2Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox3": { pictureBox3Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox4": { pictureBox4Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox5": { pictureBox5Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox6": { pictureBox6Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox7": { pictureBox7.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox8": { pictureBox8Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox9": { pictureBox9Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox10": { pictureBox10Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox11": { pictureBox11Label.Text = pictureBoxEnter.Tag.ToString(); break; }
					case "pictureBox12": { pictureBox12Label.Text = pictureBoxEnter.Tag.ToString(); break; }
				}
			}

		}

		private void CardMouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBoxLeave = (PictureBox)sender;

			switch (pictureBoxLeave.Name)
			{
				case "pictureBox1": { pictureBox1Label.Text = ""; break; }
				case "pictureBox2": { pictureBox2Label.Text = ""; break; }
				case "pictureBox3": { pictureBox3Label.Text = ""; break; }
				case "pictureBox4": { pictureBox4Label.Text = ""; break; }
				case "pictureBox5": { pictureBox5Label.Text = ""; break; }
				case "pictureBox6": { pictureBox6Label.Text = ""; break; }
				case "pictureBox7": { pictureBox7Label.Text = ""; break; }
				case "pictureBox8": { pictureBox8Label.Text = ""; break; }
				case "pictureBox9": { pictureBox9Label.Text = ""; break; }
				case "pictureBox10": { pictureBox10Label.Text = ""; break; }
				case "pictureBox11": { pictureBox11Label.Text = ""; break; }
				case "pictureBox12": { pictureBox12Label.Text = ""; break; }
			}
		}

		private void ButtonOneClick(object sender, EventArgs e)
		{
			RulesForm rules = new RulesForm();
			rules.Show();
		}

		private void PlayerNameTextBoxKeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter) { EnterGameClick(sender, e); }
		}


		public string PlayerName;
		public string RobotName;
		public int TakeTwo { get; set; } = 0;
		public bool Eso { get; set; } = false;

		string file = @"D:\School\Third_Year_Courses\C_SHARP\Semester Project\Semester_Project_Emerson_Fallah\soubor1.txt";

		Logic Logics;
		Random Rands;


		private void FormLoads(object sender, EventArgs e)
		{

			Logics = new Logic();
			Rands = new Random();

			LabelRadioButtons.Hide();
			RadioButtonCervena.Hide();
			RadioButtonZelena.Hide();
			RadioButtonKule.Hide();
			RadioButtonZaludy.Hide();
			ContinueButton.Hide();

			DisableCards();

		}
	}
}
