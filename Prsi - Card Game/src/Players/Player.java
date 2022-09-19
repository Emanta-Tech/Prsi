/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Players;

/**
 *
 * @author emers
 */
public class Player {
    
    private final String robotName = "EMERSON JAMES FALLAH";
    private String playerName;

    public Player(String playerName) {
        this.playerName = playerName;
    }

    public Player() {
    }

    public String getPlayerName() {
        return playerName;
    }

    public String getRobotName() {
        return robotName;
    }

    public void setPlayerName(String playerName) {
        this.playerName = playerName;
    }
    
    
}
