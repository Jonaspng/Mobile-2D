using UnityEngine;

public abstract class Player : Unit {

    public bool isBroken;

    public GameObject brokenIcon;


    public abstract void receiveDamage(Enemy source, int damage, int enemyIndex);

    public void receivePoisonDamage(int damage) {
        SetHealth(GetHealth() - damage);
        DamageNumberAnimation(damage, Color.red);
        StageManager.instance.playerHUD.SetHP(GetHealth());
    }
    
    public virtual void ChangeIsBroken(bool status) {
        this.isBroken = status;
        if (status) {
            GameObject.Find("Player Battlestation").GetComponentInChildren<BattleHUD>().RenderBrokenIcon();
        }
    }

    public void ResetAttackModifier() {
        SetAttackModifier(1);
        GameObject.Find("Player Battlestation").GetComponentInChildren<BattleHUD>().RemoveAttackUpIcon();
        GameObject.Find("Player Battlestation").GetComponentInChildren<BattleHUD>().RemoveMysticShieldIcon();
    }

    public abstract int GetFullDamage(int cardDamage);

    public void RenderBrokenIndicator() {
        GameObject broken = Instantiate(brokenIcon, this.gameObject.transform.GetChild(0));
        broken.GetComponent<Animator>().SetTrigger("Broken");
    }


       
}
