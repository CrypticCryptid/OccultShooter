using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int cap;
    public int capBase;
    public int wavePoints;
    public GameObject[] enemies;
    public Transform[] spawnPos;
    public int waveNum;
    public List<GameObject> waveEnemies = new List<GameObject>();

    private float timeBtwWaves;
    public float startTimeBtwWaves;

    void Start()
    {
        cap = capBase;
        timeBtwWaves = startTimeBtwWaves;
        CreateWave();
    }

    void Update()
    {
        if(waveEnemies.Count <= 0) {
            if(timeBtwWaves <= 0) {
                CreateWave();
                timeBtwWaves = startTimeBtwWaves;
            } else {
                timeBtwWaves -= Time.deltaTime; //This is the time between waves
            } 
        }


    }

    void CreateWave() {
        waveNum++;
        // if (waveNum % 5 == 0) {
        //     capBase++;
        // }
        cap = capBase;

        wavePoints = waveNum * 5;

        while(wavePoints > 0) {
            if(wavePoints < cap) {
                cap = wavePoints;
            }

            int ranEnemy = Random.Range(0, cap);
            GameObject enemyToSpawn = enemies[ranEnemy];
            wavePoints -= enemyToSpawn.GetComponent<EnemyController>().GetWaveCost();
            int ranSpawnPos = Random.Range(0, spawnPos.Length);
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPos[ranSpawnPos].position, Quaternion.identity);
            waveEnemies.Add(spawnedEnemy);

            // Assign the WaveController reference to the enemy
            EnemyController enemyController = spawnedEnemy.GetComponent<EnemyController>();
            if (enemyController != null) {
                enemyController.waveController = this;
            }
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (waveEnemies.Contains(enemy))
        {
            waveEnemies.Remove(enemy);
        }
    }
}
