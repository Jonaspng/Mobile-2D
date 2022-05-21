using UnityEngine;

public class Defend : Cards {

    public int shield;

    public Defend(int shield, int turns, int manaCost) : base(manaCost, turns) {
        this.shield = shield;
    }
    
    // public void OnMouseDown() {
    //     int enemyIndex = 0;
    //     if (StageManager.instance.manaCount - this.manaCost >= 0) {
    //         StageManager.instance.playerHUD.RenderPlayerShieldIcon(this.shield);
    //         StageManager.instance.playerMove(this, enemyIndex);
    //         GameObject.Destroy(this.transform.gameObject);
    //     } 
    // }


    public bool Testing() {
        int enemyIndex = 0;
        if (StageManager.instance.manaCount - this.manaCost >= 0) {
            StageManager.instance.playerHUD.RenderPlayerShieldIcon(this.shield);
            StageManager.instance.playerMove(this, enemyIndex);
            GameObject.Destroy(this.transform.gameObject);
            return true;
        }
        return false;
    }

    public override void executeCard(Player player, Enemy[] enemies, int enemyIndex) {
        player.changeBaseShield(this.shield);
    }
}
