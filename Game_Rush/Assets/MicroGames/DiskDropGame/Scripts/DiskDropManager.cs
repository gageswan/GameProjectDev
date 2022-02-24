using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskDropManager : MonoBehaviour
{
    public GameObject[] disksArray;
    public int diskNum = 0;
    int diskArrayLength;
    public Transform[] targets;
    int targetIndex = 0;
    Transform currentTarget;
    float speed = 5;
    float dist = 1;
    MicroGameManager microGameManager;

    void Start() {
        updateTarget();
        diskArrayLength = disksArray.Length;
        GameObject go = GameObject.Find("MicroGameContainer");
        microGameManager = go.GetComponent<MicroGameManager>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, 
            (speed * Time.deltaTime)/Vector3.Distance(transform.position, currentTarget.position)
            );

        if (Vector3.Distance(transform.position, currentTarget.position) < dist) {
            targetIndex++;
            if (targetIndex >= targets.Length) {
                targetIndex = 0;
            }
            updateTarget();
        }

        if (Input.GetKeyDown("space") && diskNum < 4) {
            Instantiate(disksArray[diskNum], transform.position, transform.rotation);
            diskNum++;
            if (diskNum >= diskArrayLength) {
                StartCoroutine(CountDown());
            }
        }
    }

    IEnumerator CountDown() {
        yield return new WaitForSeconds(2f);
        microGameManager.SetActiveGame(0);
        diskNum = 0;
    }

    void updateTarget() {
        currentTarget = targets[targetIndex];
    }
}
