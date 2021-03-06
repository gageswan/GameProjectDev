using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    int laserDPS = 1;

    [SerializeField]
    float range = 1000;

    [SerializeField]
    float fireRate = 0.50f;

    [SerializeField]
    Image overHeat;

    [SerializeField]
    Image overHeat2;

    float timer;

    LineRenderer laserFire;

    RaycastHit hit;
    Ray ray;

    public float effectdisplay = 0.1f;

    public Transform laserOrigin;
    public Camera camera;
    public Text hitText;

    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    // Start is called before the first frame update
    void Start() {
        laserFire = GetComponent<LineRenderer>();
    }

    void Update() {

        Vector3 mousePosition = Input.mousePosition;
        ray = camera.ScreenPointToRay(Input.mousePosition);

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate && Time.timeScale != 0 && !paused) {
            Shoot();
        }
        if (timer >= laserDPS * effectdisplay) {
            laserFire.enabled = false;
        }   
    }

    public void Shoot() {
        laserFire.SetPosition(0, laserOrigin.position);
        timer = 0f;

        laserFire.enabled = true;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.tag == "Enemy") {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null) {
                    enemyHealth.TakeDamage(laserDPS);
                    DisplayDamageText(laserDPS);
                }
            }
            laserFire.SetPosition(1, hit.point);
            Debug.Log(hit.collider.gameObject.name.ToString());
        }
        return;
    }

    void DisplayDamageText(int damage) {
        Vector3 mousePosition = Input.mousePosition;
        hitText.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y + 10f, mousePosition.z);
        hitText.text = damage.ToString() + " Damage!";
    }
}
/*                    Ray shootRay = new Ray();
    RaycastHit shootHit;
 *                shootRay.origin = camera.transform.position;
      shootRay.direction = transform.forward;

      if (Physics.Raycast(shootRay, out shootHit, range)) {
          if (shootHit.collider.tag == "Enemy") {
              EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
              if (enemyHealth != null) {
                  enemyHealth.TakeDamage(laserDPS);
              }
          }
          Debug.Log(shootHit.collider.gameObject.name.ToString());
          laserFire.SetPosition(1, shootHit.point);
      }*/