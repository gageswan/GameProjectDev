using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRanged : MonoBehaviour
{
    Renderer renderer;
    float colorLerp;
    float timeSinceAwake = 0;
    public int timeTillAttack = 3;
    public int attackDamage = 10;
    LineRenderer shootLine;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Transform weakPoint;
    float shootingDelay = .5f;
    float shootingTimer = 0f;

    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject soldierBody = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        renderer = soldierBody.GetComponent<Renderer>();
        weakPoint = this.gameObject.transform.GetChild(0).GetChild(1);
        shootLine = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update() {
        if (!paused) { 
                if (timeSinceAwake <= timeTillAttack) {
                    colorLerp = (timeSinceAwake += Time.deltaTime) / timeTillAttack;
                }
                else {
                    colorLerp = Mathf.PingPong(Time.time, .3f) / .3f;
                    Shoot();
                    if (shootingTimer <= shootingDelay) {
                        shootingTimer += Time.deltaTime;
                    }
                    else {
                        playerHealth.TakeDamage(attackDamage);
                        shootingTimer = 0;
                    }
                }
            renderer.material.color = Color.Lerp(Color.white, Color.red, colorLerp);
        }
    }

    void Shoot() {
        if (!paused) {
            shootLine.enabled = true;
            shootLine.SetPosition(0, weakPoint.position);
            shootLine.SetPosition(1, player.transform.position);
        }
    }
}
