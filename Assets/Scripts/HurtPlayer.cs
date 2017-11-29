using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    [SerializeField]
    private int damageToGive = 10;
    private int currentDamage;
    public GameObject damageNumber;

    private PlayerStats thePlayerStats;

    private void Start() {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Character") {
            currentDamage = damageToGive - thePlayerStats.currentDefence;

            if (currentDamage < 0) currentDamage = 1;
           

            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);

            var clone = (GameObject)Instantiate(damageNumber, collision.transform.position , Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
