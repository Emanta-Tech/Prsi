/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Deck;

import Card.Cards;
import Card.CardColor;
import Card.CardValue;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Random;

/**
 *
 * @author emers
 */
public class CardDeck {

    public ArrayList<Cards> deckOfCards;
    public ArrayList<Cards> playerCards;
    public ArrayList<Cards> robotCards;
    public Cards cardOnBoard;
    private Random random = new Random();

    public CardDeck(ArrayList<Cards> deckOfCards) {
        this.deckOfCards = deckOfCards;
    }

    public CardDeck() {
        deckOfCards = new ArrayList<>(32);
        playerCards = new ArrayList<>(4);
        robotCards = new ArrayList<>(4);
    }

    public ArrayList<Cards> createCardDeck() {

        List<String> cardColor;
        List<String> cardValue;

        for (CardColor color : CardColor.values()) {
            for (CardValue value : CardValue.values()) {
                deckOfCards.add(new Cards(color, value));
            }
        }

        Shuffle(deckOfCards);
        return deckOfCards;
    }

    public void printDeck() {
        if (!deckOfCards.isEmpty()) {
            System.out.println(deckOfCards);
        }
    }

    public void Shuffle(ArrayList<Cards> deck) {

        for (int i = 0; i < deck.size(); i++) {
            Cards temp = deck.get(i);
            int ran = random.nextInt(deck.size());
            deck.set(i, deck.get(ran));
            deck.set(ran, temp);
        }
    }

    public ArrayList<Cards> AddToCardDeck(Cards card, ArrayList<Cards> deck) {

        if (card != null) {
            deck.add(card);
        }

        return deck;
    }

    public ArrayList<Cards> RemoveFromCardDeck(Cards card, ArrayList<Cards> deck) {
        int index = deck.indexOf(card);
        if (index >= 0) {
            deck.remove(index);
        }

        return deck;
    }

    public ArrayList<Cards> DrawCard(ArrayList<Cards> deck) {
        if (!deckOfCards.isEmpty()) {
            deck = AddToCardDeck(deckOfCards.get(deckOfCards.size() - 1), deck);
            deckOfCards = RemoveFromCardDeck(deckOfCards.get(deckOfCards.size() - 1), deckOfCards);

            return deck;
        } else {
            deckOfCards = createCardDeck();
            deck = AddToCardDeck(deckOfCards.get(deckOfCards.size() - 1), deck);
            return deck;
        }
    }

    public void Sharing() {
        for (int i = 1; i <= 4; i++) {
            playerCards.add(deckOfCards.get(i));
            deckOfCards = RemoveFromCardDeck(playerCards.get(i), deckOfCards);

            robotCards.add(deckOfCards.get(i));
            deckOfCards = RemoveFromCardDeck(robotCards.get(i), deckOfCards);
        }

        cardOnBoard = deckOfCards.get(deckOfCards.size() - 1);
        deckOfCards = RemoveFromCardDeck(cardOnBoard, deckOfCards);

    }

    public void Game() {
        createCardDeck();
        Sharing();
    }

}
