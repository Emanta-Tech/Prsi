/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package prsi.card.game;

import Card.Cards;
import Deck.CardDeck;
import java.util.ArrayList;
import java.util.Random;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author emers
 */
public class PrsiCardGame extends Application {
    
    @Override
    public void start(Stage stage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("FXMLDocument.fxml"));
        
        Scene scene = new Scene(root);
        
        stage.setScene(scene);
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) { //launch(args);
        
        CardDeck deck = new CardDeck();
        
        ArrayList<Cards> cards = new ArrayList<Cards>();
        ArrayList<Cards> ply = new ArrayList<>();
        Random random = new Random();
        
       cards = deck.createCardDeck();
       Cards top = cards.get(0);
       //deck.printDeck();
       
        System.out.println(cards);
       
       System.out.println("DECK "+deck.deckOfCards.size());
       
       deck.AddToCardDeck(top, ply);  
       
       System.out.println("DECK "+deck.deckOfCards.size());
        System.out.println("PLAYER "+deck.playerCards.size());
        System.out.println("ROBOT "+deck.robotCards.size());
        System.out.println("PLY "+ply.size());
        
        System.out.println(cards);
        System.out.println(ply);
        
        deck.RemoveFromCardDeck(top, ply);
        
        System.out.println("REMOVED " + ply);
        System.out.println(ply.size());
        
        deck.DrawCard(ply);
        
        System.out.println(ply);
        System.out.println(ply.size());  
        
        System.out.println("DECK "+deck.deckOfCards.size());
        System.out.println(cards);
        System.out.println("PLAYER "+deck.playerCards.size());
        System.out.println("ROBOT "+deck.robotCards.size()); 
        
        //deck.Sharing();
        
        System.out.println(random.nextInt(deck.deckOfCards.size() - 1));
        
        System.out.println("DECK "+deck.deckOfCards.size());
        System.out.println("PLAYER "+deck.playerCards.size());
        System.out.println("ROBOT "+deck.robotCards.size());
       
    }
    
}
