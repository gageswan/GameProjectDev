using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGameManager : MonoBehaviour
{
    public GameObject[] microGameViews;
    public GameObject[] microGame;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveGame(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g")) {
            SetActiveGame(0);
        }
    }

    public void SetActiveGame(int game) {
        if (microGame[game].activeSelf == false) {
            microGame[game].SetActive(true);
            PauseMainGame();
        }
        else {
            microGame[game].SetActive(false);
            ResumeMainGame();
        }
        if (microGameViews[game].activeSelf == false) {
            microGameViews[game].SetActive(true);
        }
        else {
            microGameViews[game].SetActive(false);
        }
    }

    void PauseMainGame() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects) {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }

    void ResumeMainGame() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects) {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
    }
}
