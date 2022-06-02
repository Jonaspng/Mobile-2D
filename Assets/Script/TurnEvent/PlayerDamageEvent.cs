using UnityEngine;

class PlayerDamageEvent : AbstractEvent {

    // Affects player
    public int damage;

    public PlayerDamageEvent(int numberOfTurns, int damage, int enemyIndex) 
    : base(numberOfTurns, enemyIndex){
        this.numberOfTurns = numberOfTurns;
        this.damage = damage;
    }

    public override void executeEvent(Player player, Enemy[] enemies) {
        player.AddBaseAttack(this.damage);

        if (this.damage > 0) {
            GameObject.Find("PlayerHUD").GetComponent<BattleHUD>().RenderAttackUpIcon();
        } else {
            GameObject.Find("PlayerHUD").GetComponent<BattleHUD>().RemoveAttackUpIcon();
        }
    }

}