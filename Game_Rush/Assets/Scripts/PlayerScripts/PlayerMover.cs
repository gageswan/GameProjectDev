using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) {
            anim.SetTrigger("movePlayer");
            if (anim.speed == 0.0f) {
                anim.speed = 1f;
            }
        }
    }

    public void PausePlayer(){
        anim.speed = 0.0f;
    }
}
