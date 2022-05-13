using UnityEngine;

public class Cleave : Cards {

    public Cards cleaveCard;

    public int damage;

    public Cleave(int damage, int turns, 
    bool isAoe, int manaCost) : base(manaCost, turns, isAoe) {
        this.damage = damage;
    }

    public 
    // Start is called before the first frame update
    void Start() {
        cleaveCard = new Cleave(8, 1, true, 1);  
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            StageManager.instance.playerMove(cleaveCard);
        }        
    }

    public override void executeCard(Player player, Enemy enemy) {
        enemy.receiveDamage(this.damage);
    }
}
