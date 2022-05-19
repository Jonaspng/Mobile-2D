using UnityEngine;

public class Dodge : Cards {

    public int evasionCount;

    public Dodge(int evasionCount, int turns, int manaCost) : base(manaCost, turns) {
        this.evasionCount = evasionCount;
    }

    public void OnMouseDown() {
        int enemyIndex = 0;
        if (StageManager.instance.manaCount - this.manaCost >= 0) {
            StageManager.instance.playerMove(this, enemyIndex);
            GameObject.Destroy(this.transform.gameObject);
        } 
    }

    public override void executeCard(Player player, Enemy[] enemies, int enemyIndex) {
        Archer archer = (Archer) player;
        archer.AddEvasionCount(this.evasionCount);
    }
}
