using UnityEngine;

public class ScatterShot : Cards {

    public int damage;

    public ScatterShot(int damage, int turns, 
    int manaCost) : base(manaCost, turns) {
        this.damage = damage;
    }


    public override void OnDrop(int enemyIndex) {
        if (StageManager.instance.manaCount - this.manaCost >= 0) {
            StageManager.instance.playerMove(this, enemyIndex);
            GameObject.Destroy(this.transform.gameObject);
            GameObject.Find("Current Hand").GetComponent<Testing>().ReArrangeCards();
        } 
    }

    public override void executeCard(Player player, Enemy[] enemies, int enemyindex) {
        player.animator.SetTrigger("Attack");
        foreach (Enemy enemy in enemies) {
            if (enemy != null) {
                Archer archer = (Archer) player;
                enemy.ReceiveArrowDamage(archer, player.GetFullDamage(damage), enemyindex);
            }
            
        }
        
    }
}
