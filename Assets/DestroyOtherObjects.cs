using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherObjects : MonoBehaviour {
    void Start() {
        if (GameObject.FindWithTag("Player") != null && GameObject.FindWithTag("GameGUI") != null) {
            GameObject.FindWithTag("Player").SetActive(false);
            GameObject.FindWithTag("GameGUI").SetActive(false);
        }
    }
}
