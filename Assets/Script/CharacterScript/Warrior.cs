using UnityEngine;
using System;
using EZCameraShake;


public class Warrior : Player {

    public bool isStrongWillpower;

    public bool isEndure;

    public int hitCount;

    public Warrior(double attackModifier, double shieldModifier) 
    : base(100, attackModifier, shieldModifier) { 
        //empty
    }

    public override void receiveDamage(Enemy Source, int damage, int enemyIndex) {
        int realDamage;
        this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        this.animator.SetTrigger("Damaged");
        if (isStrongWillpower) {
            hitCount++;
        }
        if (isBroken) {
            realDamage = (int) Math.Round(damage * 1.25, MidpointRounding.AwayFromZero);
        } else {
            realDamage = damage;
        }
        if (realDamage >= this.baseShield ) {
            if (this.isEndure && this.health - realDamage + this.baseShield <= 0) {
                this.health = 1;
                this.isEndure = false;          
            } else {
                health = health - realDamage + this.baseShield;
            }
            if (realDamage == this.baseShield) {
                DamageNumberAnimation("Blocked", Color.white);
            } else {
                DamageNumberAnimation(realDamage - this.baseShield, Color.red);
            }            
            ResetBaseShield();
            StageManager.instance.playerHUD.RemoveShieldIcon();
        } else {
            DamageNumberAnimation("Blocked", Color.white);
            StageManager.instance.playerHUD.RenderPlayerShieldIcon(-realDamage);
            this.baseShield -= realDamage;
        }
        print(health);
        StageManager.instance.playerHUD.SetHP(this.health);
        
    }

    public void ChangeIsStrongWillpower(bool status) {
        this.isStrongWillpower = status;
    }

    public void ChangeIsEndure(bool status) {
        this.isEndure = status;
    }

    public void resetHitCount() {
        this.hitCount = 0;
    }


    public override int GetFullDamage(int cardDamage) {
        if (this.isStrongWillpower) {
            return (int) Math.Round(this.attackModifier * (this.baseAttack + cardDamage + this.hitCount * 2));
        } else {
            return (int) Math.Round(this.attackModifier * cardDamage + baseAttack);
        }
    }

}
