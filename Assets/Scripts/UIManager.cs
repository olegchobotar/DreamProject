using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public Slider healthBar;
    public Slider XPBar;
    public Text HPText;
    public Text LvlText;
    public PlayerHealthManager playerHP;

    private PlayerStats thePlayerStats;

    private static bool UIExists;

	void Start () {
        if (!UIExists) {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else {
            Destroy(gameObject);
        }
        thePlayerStats = GetComponent<PlayerStats>();
    }
	
	void Update () {
        healthBar.maxValue = playerHP.playerMaxHealth;
        healthBar.value = playerHP.playerCurrentHealth;
        HPText.text = "HP: " + playerHP.playerCurrentHealth + "/" + playerHP.playerMaxHealth;
        if (thePlayerStats.currentLevel >= 1) {
            XPBar.maxValue = thePlayerStats.toLevelUp[thePlayerStats.currentLevel];
            XPBar.value = thePlayerStats.currentXP;
            LvlText.text = "Level: " + thePlayerStats.currentLevel;
        }
    }
}
