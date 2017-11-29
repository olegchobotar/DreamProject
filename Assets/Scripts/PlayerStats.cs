using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int currentLevel;
    public int currentXP;

    public int[] toLevelUp;

    private bool isLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;

	private void Start () {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	void Update () {
	    if (currentXP >= toLevelUp[currentLevel]) {
            //currentLevel++;
            LevelUp();
            isLevelUp = true;
        }
        if (isLevelUp) {
            currentXP -= toLevelUp[currentLevel - 1];
            isLevelUp = false;
        }
	}
    
    public void AddXP (int XPToAdd) {
        currentXP += XPToAdd;
    }

    public void LevelUp() {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth = currentHP;

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
