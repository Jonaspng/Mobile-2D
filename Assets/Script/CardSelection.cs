using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour {
    public Material outline;

    private void Start() {
        outline = Resources.Load<Material>("Solid_Contour_inside");
    }

    public void OnMouseDown() {
        foreach (Transform obj in GameObject.Find("NewCards").transform) {
            obj.gameObject.GetComponentInChildren<Image>().material = null;
        }
        this.GetComponentInChildren<Image>().material = outline;
        GameObject.Find("StageManager").GetComponent<PopUpMenu>().newCardId = this.GetComponent<Cards>().id;    
    }

}
