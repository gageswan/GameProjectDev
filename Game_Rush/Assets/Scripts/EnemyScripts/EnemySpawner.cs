using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //public Transform[] enemyStarts;
    //public Transform[] enemyEnds;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemiesList = new List<GameObject>();

    public GameObject[] enemyPrefabs;
    public Transform[] enemySpawns;
    public Transform[] enemyPositions;
    int[] enemyInts = {
            //1st Wave - 6
                       0, 1, 0, 1,
                       0, 4, 1, 0,
                       0, 1, 3, 2,
                       0, 4, 2, 3,
                       0, 0, 3, 2,
                       0, 3, 2, 3,
            //2nd Wave - 5
            0, 0, 3, 0,
            0, 1, 0, 3,
            1, 2, 1, 0,
            0, 3, 2, 1,
            0, 4, 1, 2,
            //3rd Wave - 9
            0, 1, 0, 1,
            0, 4, 1, 0,
            1, 0, 3, 1,
            1, 2, 4, 5,
            1, 3, 2, 0, 
            0, 0, 3, 2,
            0, 1, 0, 1, 
            0, 3, 2, 3,
            0, 4, 1, 0, 
            1, 2, 4, 5,
                       };
    int[] waveSizeArray = { 6, 5, 9 };
    int spawnKey = 0;
    int waveKey = 0;

    void SpawnEnemy(int type, int spawnPosition, int positionOne, int positionTwo) {
        GameObject newEnemy = Instantiate(
            enemyPrefabs[type],
            enemySpawns[spawnPosition]
            ) as GameObject;

        enemiesList.Add(newEnemy);

        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyPositions[positionOne]);
        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyPositions[positionTwo]);
    }


    public void waveSpawn() {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn() {
        int waveSize = waveSizeArray[waveKey];
        if (spawnKey >= enemyInts.Length) {
            yield break;
        }
        for (int i = 1; i <= waveSize; i++) {
            SpawnEnemy(enemyInts[spawnKey], enemyInts[spawnKey + 1], enemyInts[spawnKey + 2], enemyInts[spawnKey + 3]);
            spawnKey += 4;            
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
        waveKey++;
        Debug.Log("Enemy Wave Size = " + enemiesList.Count);
    }

    void Update()
    {
/*        if (Input.GetKeyDown("i")) {
            SpawnEnemy();
        }
        if (Input.GetKeyDown("s")) {
            waveSpawn();
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
// Update is called once per frame


/*    void SpawnEnemy() {
            ///Debug.Log("SPAWN");

        GameObject newEnemy = Instantiate(
            enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
            enemySpawns[Random.Range(0, enemySpawns.Length)].position, transform.rotation
            ) as GameObject;

        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyStarts[Random.Range(0, enemyStarts.Length)]);
        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyEnds[Random.Range(0, enemyEnds.Length)]);
    }*/

/*    public void waveSpawn() {
        int waveSize = waveSizeArray[waveKey];
        if (spawnKey >= enemyInts.Length) {
            return;
        }
        for (int i = 1; i <= waveSize; i++) {
            SpawnEnemy(enemyInts[spawnKey], enemyInts[spawnKey + 1], enemyInts[spawnKey + 2], enemyInts[spawnKey + 3]);
            spawnKey += 4;
        }
        waveKey++;
    }*/
