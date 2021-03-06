using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Niflheim : Cards {

    [SerializeField] private Material material;

    [SerializeField] private bool dissolve;

    [SerializeField] private TextMeshProUGUI descriptionTag;

    private void Awake() {
        InitialiseValues(25, 25, "Deal 25 damage to all enemies.");
    }

    private void Update() {
        if (this.dissolve) {
            material.SetFloat("_Fade", Mathf.MoveTowards(material.GetFloat("_Fade"), 0f, 2f * Time.deltaTime));
            Destroy(this.gameObject, 0.4f);
        }
    }

    public override void OnDrop(int enemyIndex) {
        foreach (Transform word in this.transform.Find("Frame").transform) {
            word.gameObject.SetActive(false);
        }
        material.SetFloat("_Fade",1f);
        this.GetComponentInChildren<Image>().material = material;
        this.dissolve = true;
        StageManager.GetInstance().playerMove(this, enemyIndex);
        GameObject.Find("Current Hand").GetComponent<FanShapeArranger>().ReArrangeCards();

    }

     public override void executeCard(Player player, Enemy[] enemies, int enemyindex) {
        player.GetAnimator().SetTrigger("Attack");
        player.PlayAttackSound();
        for (int i = 0; i < enemies.Length; i ++) {
            if (enemies[i] != null) {
                enemies[i].receiveDamage(player.GetFullDamage(GetOriginalDamage()), i);                
            }
        }
        
    }
}
