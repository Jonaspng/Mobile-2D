using UnityEngine;
public class PopUpMenu : MonoBehaviour  {
    public GameObject cardSelectionMenu;
 
    void Start ()  {
        cardSelectionMenu.SetActive(false); 
    }
         
    public void PopUp()  { 
        cardSelectionMenu.SetActive (!cardSelectionMenu.activeSelf); 
    }

    public void OnConfirmClick() {
        StageManager.instance.deckManager.SaveJson(StageManager.instance.deckManager.currentDeckID);
        GameObject.Find("GameManager").GetComponent<GameManager>().stageNumber += 1;
        foreach (Transform obj in GameObject.Find("NewCards").transform) {
            GameObject.Destroy(obj.gameObject);
        }
        GameObject.Find("StageManager").GetComponent<PopUpMenu>().PopUp();
        
        StageManager.instance.InitialiseBattle();
    }
}