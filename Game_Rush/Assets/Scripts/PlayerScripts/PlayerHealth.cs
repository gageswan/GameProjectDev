using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int d) {
        currentHealth -= d;
        if (currentHealth <= 0 && isDead == false) {
            Death();
        }
    }

    public void Death() {
        isDead = true;
    }
}
