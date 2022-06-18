using UnityEngine;

public class Cleave : Cards {


    public int damage;

    public Cleave(int damage, int turns, 
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
                enemy.receiveDamage(player.GetFullDamage(this.damage), enemyindex);
            }
        }
        
    }
}
