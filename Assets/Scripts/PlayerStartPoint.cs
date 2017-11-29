using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement playerPos;
    private CameraMovement cameraPos;

    public string pointName;

	private void Start () {
        playerPos = FindObjectOfType<PlayerMovement>();

        if (playerPos.startPoint == pointName) {
            playerPos.transform.position = transform.position;

            cameraPos = FindObjectOfType<CameraMovement>();
            cameraPos.transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }
    }
	
}
