using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private SpriteRenderer playerSprite;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    //[SerializeField]
    //private float waitToReload;

    //private bool reloading;
    
	private void Start () {
        playerCurrentHealth = playerMaxHealth;

        playerSprite = GetComponent<SpriteRenderer>();
	}

	private void Update () {
		/*if (playerCurrentHealth < 0 && !reloading) {
            reloading = true;
            gameObject.SetActive(false);
        }
        if (reloading) {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                gameObject.SetActive(true);
                playerCurrentHealth = playerMaxHealth;
                reloading = false;
            }
        }*/
        if (playerCurrentHealth <= 0) {
            gameObject.SetActive(false);
        }

        if (flashActive) {
            if (flashCounter > flashLength * 0.66f) {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);
            } else if (flashCounter > flashLength * 0.33f) {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1.0f);
            } else if (flashCounter > 0f) {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);
            } else {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1.0f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive) {
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
    }

    public void SetMaxHealt() {
        playerCurrentHealth = playerMaxHealth;
    }
}
