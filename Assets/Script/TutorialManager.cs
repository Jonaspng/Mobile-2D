using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public GameObject panel1;

    public GameObject panel2;

    public GameObject panel3;

    public GameObject panel4;

    public GameObject nextBtn;

    public GameObject prevBtn;

    private int counter;

    private void Start() {
        counter = 1;
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        nextBtn.SetActive(true);
        prevBtn.SetActive(false);   
    }

    public void OnMainMenuClick() {
        SceneManager.LoadScene("Start Menu");
    }

    public void OnNextClick() {
        counter += 1;
        if (counter <= 4) {
            if (counter == 2) {
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel3.SetActive(false);
                panel4.SetActive(false);
                nextBtn.SetActive(true);
                prevBtn.SetActive(true);
            } else if (counter == 3) {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(true);
                panel4.SetActive(false);
                nextBtn.SetActive(true);
                prevBtn.SetActive(true);
            } else if (counter == 4) {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(true);
                nextBtn.SetActive(false);
                prevBtn.SetActive(true);
            }
        }
    }

    public void OnPreviousClick() {
        counter -= 1;
        if (counter >= 1) {
            if (counter == 1) {
                panel1.SetActive(true);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                nextBtn.SetActive(true);
                prevBtn.SetActive(false);
            } else if (counter == 2) {
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel3.SetActive(false);
                panel4.SetActive(false);
                nextBtn.SetActive(true);
                prevBtn.SetActive(true);
            } else if (counter == 3) {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(true);
                panel4.SetActive(false);
                nextBtn.SetActive(true);
                prevBtn.SetActive(true);
            }
        }
    }

    




}
