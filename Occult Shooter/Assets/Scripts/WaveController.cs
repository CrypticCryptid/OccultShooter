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
    private List<GameObject> waveEnemies = new List<GameObject>();

    private float timeBtwWaves;
    public float startTimeBtwWaves;

    void Start()
    {
        cap = capBase;
        CreateWave();
    }

    void Update()
    {
        // if (waveNum % 5 == 0) {
        //     capBase++;
        // }

        // if(timeBtwWaves <= 0) {
        //     CreateWave();
        //     timeBtwWaves = startTimeBtwWaves;
        // } else {
        //     timeBtwWaves -= Time.deltaTime; //This is the time between waves
        // }
    }

    void CreateWave() {
        wavePoints = waveNum * 5;

        while(wavePoints > 0) {
            if(wavePoints < cap) {
                cap = wavePoints;
            }

            int ranEnemy = Random.Range(0, cap);
            GameObject enemyToSpawn = enemies[ranEnemy];
            wavePoints -= enemyToSpawn.GetComponent<EnemyController>().GetWaveCost();
            waveEnemies.Add(enemyToSpawn);
            int ranSpawnPos = Random.Range(0, spawnPos.Length);
            Instantiate(enemyToSpawn, spawnPos[ranSpawnPos].position, Quaternion.identity);
        }
    }
}
