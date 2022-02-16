using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    int laserDPS = 1;

    [SerializeField]
    float range = 100;

    [SerializeField]
    float fireRate = 0.50f;

    // [SerializeField]
    // public Transform gunEnd;

    [SerializeField]
    Image overHeat;

    [SerializeField]
    Image overHeat2;

    float timer;

    LineRenderer laserFire;
    Ray shootRay = new Ray();
    RaycastHit shootHit;

    float effectdisplay = 0.2f;

    // Start is called before the first frame update
    void Start() {
        laserFire = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate && Time.timeScale != 0) {
            Shoot();



        }
        if (timer >= laserDPS * effectdisplay) {
            laserFire.enabled = false;
        }
    }

    public void Shoot() {
        timer = 0f;
        laserFire.SetPosition(0, transform.position);

        laserFire.enabled = true;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        /* this code is fine
         * 
        if (Physics.Raycast(shootRay, out shootHit, range))
            
        {               
             *******just replace TargetBox with the enemy health script name***********
            
            TargetBox targetBox = shootHit.collider.GetComponent<TargetBox>();
            if(targetBox != null)
            {
                targetBox.TakeDamage(laserDPS);
            }
            laserFire.SetPosition(1, shootHit.point);

        }
        else
        {
            laserFire.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
            */
    }
}
