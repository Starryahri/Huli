using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    void Start() {
        foreach(GameObject popUp in popUps) {
            popUp.SetActive(false);
        }
    }
    void Update() {

        if(popUpIndex == 0){
            popUps[0].SetActive(true);
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                popUpIndex++;
                popUps[0].SetActive(false);
            }
        } else if(popUpIndex == 1) {
            popUps[1].SetActive(true);
            if(Input.GetKeyUp(KeyCode.Mouse0)) {
                popUpIndex++;
                popUps[1].SetActive(false);
            }
        } else if(popUpIndex == 2) {
            popUps[2].SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                popUpIndex++;
                popUps[2].SetActive(false);
            }
        } else if (popUpIndex == 3)
        {
            popUps[3].SetActive(true);
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                popUpIndex++;
                popUps[3].SetActive(false);
            }
        }

    }
}
