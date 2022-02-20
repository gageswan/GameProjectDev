using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public int damageTaken;
    public MicroGameManager microGames;
    public int playerLives = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damageTaken =  (currentHealth - startingHealth) * - 1;
        DisplayGameText();
    }

    void DisplayGameText() {
        GetComponentInChildren<Text>().text = damageTaken.ToString() + " Damage Taken";
            }

    public void TakeDamage(int d) {
        currentHealth -= d;
        if (currentHealth <= 0 && isDead == false) {
            Death();
        }
    }

    public void Death() {
        playerLives--;
        //isDead = true;
        if (playerLives > 0) {
            microGames.SetActiveGame(0);
        }
    }
}
