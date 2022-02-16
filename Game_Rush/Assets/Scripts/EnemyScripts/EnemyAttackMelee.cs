using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    public int attackDamage = 10;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack() {
        playerHealth.TakeDamage(attackDamage);
    }

}
