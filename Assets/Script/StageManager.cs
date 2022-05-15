using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public static StageManager instance;

    public Player player;

    public Enemy[] enemies;

    public int manaCount;

    public int currentTurn;
    
    //key = int; value = AbstractEvent[];
    public Hashtable eventManager;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        eventManager = new Hashtable();
    }

    public void playerMove(Cards card, int enemyIndex) {
        card.executeCard(player, enemies, enemyIndex);
    }
    
    
}
