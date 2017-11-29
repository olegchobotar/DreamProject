using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingNumbers : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Text displayNumber;
    public int damageNumber;
    void Start () {
		
	}

	void Update () {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}
}
