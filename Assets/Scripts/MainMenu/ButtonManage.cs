using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManage : MonoBehaviour {
    public void StartGameButton (string levelName) {
        SceneManager.LoadScene(levelName);
        if (GameObject.FindWithTag("Player") != null && GameObject.FindWithTag("GameGUI") != null) {
            GameObject.FindWithTag("Player").SetActive(true);
            GameObject.FindWithTag("GameGUI").SetActive(true);
        }
    }
}
