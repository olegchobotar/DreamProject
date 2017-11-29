using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealManager : MonoBehaviour {

    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private int CurrentHealth;

    [SerializeField]
    private int XPToGive;

    private PlayerStats thePlayerStats;

    private void Start() {
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update() {
        if (CurrentHealth < 0) {
            Destroy(gameObject);
            thePlayerStats.AddXP(XPToGive);   
        }
    }

    public void HurtEnemy(int damageToGive) {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealt() {
        CurrentHealth = MaxHealth;
    }
}
