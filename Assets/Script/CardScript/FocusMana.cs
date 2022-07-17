using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class FocusMana : Cards {

    [SerializeField] private int manaGained = 2;

    [SerializeField] private Material material;

    [SerializeField] private bool dissolve;

    [SerializeField] private TextMeshProUGUI descriptionTag;

    private void Awake() {
        InitialiseValues("Gain 2 mana next turn.");
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
        GameObject.Find("Current Hand").GetComponent<Testing>().ReArrangeCards();
    }

    public override void executeCard(Player player, Enemy[] enemies, int enemyIndex) {
        int currentTurn = StageManager.GetInstance().GetCurrentTurn();
        Dictionary<int, AbstractEvent[]> eventManager = StageManager.GetInstance().GetPlayerEventManager();
        AbstractEvent[] newManaEvent = {new GainManaEvent(manaGained, enemyIndex)};
        if (eventManager.ContainsKey(currentTurn)) {
            AbstractEvent[] currEvent = (AbstractEvent[])eventManager[currentTurn];
            eventManager[currentTurn] = currEvent.Concat(newManaEvent).ToArray();
        } else {
            eventManager.Add(currentTurn, newManaEvent);
        }
    }
    
}
