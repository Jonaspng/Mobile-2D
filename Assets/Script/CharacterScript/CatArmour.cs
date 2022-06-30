using UnityEngine;

public class CatArmour : Enemy {
    
    public CatArmour (double attackModifier, double shieldModifier) 
    : base(30, attackModifier, shieldModifier) { 
        //empty
    }

    public override void EnemyMove(Player player, Enemy[] enemies, int index) {
        int moveNumber = Random.Range(1, 4);
        if (!this.isImmobilised) {
            if (moveNumber == 1) {
                this.animator.SetTrigger("Attack");
                player.receiveDamage(this, this.GetFullDamage(2), index);
            } else if (moveNumber == 2) {
                this.AddBaseShield(8);
                this.gameObject.GetComponentInParent<BattleHUD>().RenderEnemyShieldIcon(index);
            } else {
                foreach (Enemy enemy in enemies) {
                    if (enemy != null) {
                        enemy.AddBaseShield(6);
                        enemy.gameObject.GetComponentInParent<BattleHUD>().RenderEnemyShieldIcon(enemy.enemyIndex);
                    }
                } 
            }
        }
        

    }
       

}
