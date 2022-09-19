using System;
using System.Linq;
using System.Windows.Forms;

namespace Semester_Project
{
	class Logic
	{

		/// <summary>
		/// Start of the Game
		/// </summary>
		public void StartGame()
		{
			Generate();
			SharingCard();
		}

		/// <summary>
		/// Populates the deck (Card Pack)
		/// </summary>
		/// <returns> The populated deck (String) </returns>
		private string[] Generate()
		{
			int index = 0;
			CardPack = new string[32]; // Total number of cards in deck

			for (int i = 0; i < Constants.CardColors.Length; i++)
			{
				for (int j = 0; j < Constants.CardValues.Length; j++)
				{
					CardPack[index] = Constants.CardColors[i] + " " + Constants.CardValues[j];
					index++;
				}
			}
			Reshuffle(CardPack);
			return CardPack;
		}

		/// <summary>
		/// This method shares the
		/// amount of cards to each Player. 
		/// 
		/// Each player has four cards at hand.  
		/// </summary>
		private void SharingCard()
		{
			PlayerOneCardPack = new string[4];
			PlayerTwoCardPack = new string[4];

			Array.Clear(PlayerOneCardPack, 0, PlayerOneCardPack.Length - 1);
			Array.Clear(PlayerOneCardPack, 0, PlayerTwoCardPack.Length - 1);

			for (int i = 0; i < 4; i++)
			{
				PlayerOneCardPack[i] = CardPack[Rand.Next(0, CardPack.Length)];
				CardPack = RemoveFromCardPack(PlayerOneCardPack[i], CardPack);

				PlayerTwoCardPack[i] = CardPack[Rand.Next(0, CardPack.Length)];
				CardPack = RemoveFromCardPack(PlayerTwoCardPack[i], CardPack);
			}

			holdingCard = CardPack[Rand.Next(0, CardPack.Length)];
			CardPack = RemoveFromCardPack(holdingCard, CardPack);
		}


		/// <summary>
		/// Shuffles the deck of card. The deck of 
		/// cards ("texts") passed to the method 
		/// is been swap with array temp and then returned. 
		/// </summary>
		/// <param name="texts"></param>
		public void Reshuffle(string[] texts)
		{
			for (int i = 0; i < texts.Length; i++)
			{
				string temp = texts[i];
				int random = Rand.Next(i, texts.Length);
				texts[i] = texts[random];
				texts[random] = temp;
			}
		}


		/// <summary>
		/// cardToRemove == The particular card to be removed
		/// deckofCards == From which it will be removed
		/// 
		/// First get the index. When the index of the card is not less 
		/// than 0 then loop through the deckofCards,
		/// if i == index, then pass that index(s) to items and return it.  
		/// else just retun deckOfCards.
		/// </summary>
		/// <param name="cardToRemove"></param>
		/// <param name="deckOfCards"></param>
		/// <returns></returns>
		public string[] RemoveFromCardPack(string cardToRemove, string[] deckOfCards)
		{
			int index = Array.IndexOf(deckOfCards, cardToRemove);

			if (index >= 0)
			{
				string[] items = new string[deckOfCards.Length - 1];
				for (int i = 0, j = 0; i < items.Length; i++, j++)
				{
					if (i == index)
					{
						j++;
					}
					items[i] = deckOfCards[j];
				}
				return items;
			}
			else
			{
				return deckOfCards;
			}
		}


		/// <summary>
		/// Resize the deck and 
		/// Add the card. 
		/// </summary>
		/// <param name="cardToAdd"></param>
		/// <param name="deckOfCards"></param>
		/// <returns></returns>
		public string[] AddToCardPack(string cardToAdd, string[] deckOfCards)
		{
			Array.Resize(ref deckOfCards, deckOfCards.Length + 1);
			deckOfCards[deckOfCards.GetUpperBound(0)] = cardToAdd;

			return deckOfCards;
		}


		/// <summary>
		/// Liznu kartu
		/// </summary>
		/// <param name="deckOfCards"></param>
		/// <returns></returns>
		public string[] DrawCard(string[] deckOfCards)
		{
			if (CardPack.Length != 0)
			{
				deckOfCards = AddToCardPack(CardPack.Last(), deckOfCards);
				CardPack = RemoveFromCardPack(CardPack.Last(), CardPack);

				return deckOfCards;
			}
			else
			{
				CardPack = Generate();
				deckOfCards = AddToCardPack(CardPack.Last(), deckOfCards);

				return deckOfCards;
			}
		}


		/// <summary>
		/// Player (User) playes
		/// </summary>
		/// <param name="form"></param>
		public void PlayerMoves(Form1 form)
		{
			form.Display(PlayerOneCardPack);
		}


		/// <summary>
		/// Opponent (Robot) playes
		/// </summary>
		/// <param name="form"></param>
		public void RobotMoves(Form1 form)
		{
			if (form.Eso)
			{
				form.Eso = false;
				MessageBox.Show(form.RobotName + " STOJI");
				PlayerMoves(form);
			}
			else
			{
				bool winning = false;
				bool converter = false;
				int takeTwo = form.TakeTwo;
				bool eso = form.Eso;

				foreach (string card in PlayerTwoCardPack)
				{
					if (Moves(card, ref takeTwo, ref eso, out converter))
					{
						PlayerTwoCardPack = RemoveFromCardPack(card, PlayerTwoCardPack);
						if (converter)
						{
							string convertTo = Constants.CardColors[Rand.Next(0, 4)];
							form.ShowMoves(convertTo);

							winning = true;
							form.TakeTwo = takeTwo;
							form.Eso = eso;
							break;
						}
						else
						{
							form.ShowMoves(card);
							winning = true;
							form.TakeTwo = takeTwo;
							form.Eso = eso;
							break;
						}
					}
				}

				if (!winning)
				{
					if (takeTwo > 0)
					{
						for (int i = 0; i < takeTwo; i++)
						{
							PlayerTwoCardPack = DrawCard(PlayerTwoCardPack);
						}
						form.TakeTwo = 0;
					}
					else
					{

						form.TakeTwo = takeTwo;
						PlayerTwoCardPack = DrawCard(PlayerTwoCardPack);
					}
				};
				PlayerMoves(form);
			}
		}


		/// <summary>
		/// Rules of the game and certain laws
		/// 
		/// Card name is Split into two with ' ' as delimeter
		/// One array for the card from the player
		/// Another array for the card on the table
		/// 
		/// So when a player plays, these two cards ( Card on the table & Card played by player )
		/// are compared to see that it satisfies the rules. 
		/// 
		/// If it doesn't satisfies the rules or is not a valid card
		/// then no action / no event. 
		/// </summary>
		/// <param name="card"></param>
		/// <param name="takeTwo"></param>
		/// <param name="eso"></param>
		/// <param name="change"></param>
		/// <returns></returns>
		public bool Moves(string card, ref int takeTwo, ref bool eso, out bool change)
		{

			String[] card_color = card.Split(' ');
			String[] playerCard_color = holdingCard.Split(' ');

			change = false;

			if (playerCard_color.Length == 1)
			{
				if (card_color[0] == playerCard_color[0]) { return true; } else { return false; }

			}
			else
			{

				if (card_color[1] == "Z")
				{

					if (playerCard_color[1] == "7") { return false; }
					else { change = true; return true; }

				}
				else if (playerCard_color[1] == "E")
				{

					if (eso) { return false; }
					else
					{

						if (card_color[0] == playerCard_color[0])
						{

							if (card_color[1] == "7") { takeTwo += 2; }

							if (card_color[1] == "E") { eso = true; }
							return true;
						}

						if (card_color[1] == playerCard_color[1])
						{

							if (card_color[1] == "7") { takeTwo += 2; }

							if (card_color[1] == "E") { eso = true; }
							return true;
						}

					}
					return false;

				}
				else if (playerCard_color[1] == "7")
				{

					if (takeTwo > 0)
					{

						if (card_color[1] == "7") { takeTwo += 2; return true; }
						else { return false; }

					}
					else
					{

						if (card_color[0] == playerCard_color[0])
						{

							if (card_color[1] == "7") { takeTwo += 2; }

							if (card_color[1] == "E") { eso = true; }
							return true;
						}

						if (card_color[1] == playerCard_color[1])
						{

							if (card_color[1] == "7") { takeTwo += 2; }

							if (card_color[1] == "E") { eso = true; }
							return true;
						}
						else { return false; }
					}

				}
				else if (card_color[1] == playerCard_color[1])
				{

					if (card_color[1] == "7") { takeTwo += 2; }

					if (card_color[1] == "E") { eso = true; }
					return true;

				}
				else if (card_color[0] == playerCard_color[0])
				{

					if (card_color[1] == "7") { takeTwo += 2; }

					if (card_color[1] == "E") { eso = true; }
					return true;

				}
				else return false;
			}
		}

		private readonly Random Rand;
		public string[] CardPack { get; set; }
		public string[] PlayerOneCardPack { get; set; }
		public string[] PlayerTwoCardPack { get; set; }
		public string holdingCard { get; set; }

		public Logic()
		{
			Rand = new Random();
		}

	}
}
