/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Card;

/**
 *
 * @author emers
 */
public class Cards {  
    
    public CardColor cardColor;
    public CardValue cardValue;

    public Cards(CardColor cardColor, CardValue cardValue) {
        this.cardColor = cardColor;
        this.cardValue = cardValue;
    }

    public Cards() {
    }

    public CardColor getCardColor() {
        return cardColor;
    }

    public CardValue getCardValue() {
        return cardValue;
    }

    public void setCardColor(CardColor cardColor) {
        this.cardColor = cardColor;
    }

    public void setCardValue(CardValue cardValue) {
        this.cardValue = cardValue;
    }

    @Override
    public String toString() {
        return cardColor.toString() + " " + cardValue.toString();
    }
    
    
    
}
