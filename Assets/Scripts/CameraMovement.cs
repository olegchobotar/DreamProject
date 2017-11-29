using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Transform target;

    private Canvas theCanvas;

    private static bool cameraExists;

    public bool isGoingToMainMenu;

    private void Start() {
        if (GameObject.FindWithTag("Player") != null && GameObject.FindWithTag("GameGUI") != null) {
            print("Is exist");
            GameObject.FindWithTag("Player").SetActive(true);
            GameObject.FindWithTag("GameGUI").SetActive(true);
        }

        DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists) {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
            DontDestroyOnLoad(theCanvas);
        }
        else {
            Destroy(gameObject);
        }
        
    }

    private void Awake() {
        if (!target) target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update() {
        Vector3 position = target.position;
        position.z = -10.0f;

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
