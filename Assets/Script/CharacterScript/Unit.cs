using UnityEngine;


public abstract class Unit : MonoBehaviour {

    public string unitName;

    public int health;

    public int maxHp;
    
    public int baseAttack;

    public double attackModifier;

    public int baseShield;

    public double shieldModifier;

    public bool isPoisoned;

    public Animator animator;

    public void ChangeIsPoisoned(bool status) {
        this.isPoisoned = status;
    }

       
}
