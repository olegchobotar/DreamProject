using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour {
    [SerializeField]
    private int damageToGive;
    private int currentDamage;
    [SerializeField]
    private GameObject damageBurst;
    [SerializeField]
    private Transform hitPoint;
    [SerializeField]
    private GameObject damageNumber;

    private PlayerStats thePlayerStats;

    private void Start() {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            currentDamage = damageToGive + thePlayerStats.currentAttack;

            collision.gameObject.GetComponent<EnemyHealManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
