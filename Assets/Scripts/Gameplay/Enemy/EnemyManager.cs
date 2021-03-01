using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField] float timeToSpawn;
    [SerializeField] int enemiesToCreate;

    [SerializeField] Enemy[] enemies;
    int actualEnemy=0;
    int enemiesEliminated = 0;
    int enemiesCreated = 0;
    bool canCreateEnemies = true;
    public delegate void AllEnemiesEliminated();
    public static event AllEnemiesEliminated EliminatedAllEnemies;
    public delegate void EnemyKilled(int er);
    public static event EnemyKilled KilledEnemy;
    public delegate void PassDifficulties(string dif);
    public static event PassDifficulties Difficulty;

    [SerializeField] List<int> enemiesToChangeTimeToSpawn;
    [SerializeField] List<float> timesToSpawn;
    [SerializeField] List<string> difficulties;

    void Start() {
        actualEnemy = 0;
        enemiesEliminated = 0;
        enemiesCreated = 0;
        canCreateEnemies = true;
        Enemy.EnemyDead += EnemyDead;
        StartCoroutine(SpawnEnemies());
        House.Lose += UnableAllEnemies;
    }

    private void OnDisable() {
        Enemy.EnemyDead -= EnemyDead;
        House.Lose -= UnableAllEnemies;
    }

    void EnemyDead() {
        Handheld.Vibrate();
        enemiesEliminated++;
        if (KilledEnemy != null) {
            if (enemiesEliminated >= enemiesToCreate)
                KilledEnemy(0);
            else
                KilledEnemy(enemiesToCreate - enemiesEliminated);
        }
        if(enemiesEliminated == enemiesToCreate) {
            canCreateEnemies = false;
            if (EliminatedAllEnemies != null)
                EliminatedAllEnemies();
        }
    }

    void UnableAllEnemies() {
        enemiesCreated = enemiesToCreate;
        StopCoroutine(SpawnEnemies());
        for (int i = 0; i < enemies.Length; i++)
            if (enemies[i] != null && enemies[i].gameObject.activeSelf)
                enemies[i].gameObject.SetActive(false);
        canCreateEnemies = false;
    }

    IEnumerator SpawnEnemies() {
        yield return new WaitForSeconds(3.0f);
        while (enemiesCreated < enemiesToCreate) {
            int actualInd = 0;
            for (int i = 0; i < enemiesToChangeTimeToSpawn.Count; i++)
                if (enemiesCreated >= enemiesToChangeTimeToSpawn[i]) {
                    timeToSpawn = timesToSpawn[i];
                    actualInd = i;
                }

            if (Difficulty != null)
                Difficulty(difficulties[actualInd]);

            yield return new WaitForSeconds(timeToSpawn);
            if (canCreateEnemies) {
                if (enemies[actualEnemy] != null) {
                    enemies[actualEnemy].gameObject.SetActive(true);
                    enemies[actualEnemy].ResetEnemy();
                }

                actualEnemy++;
                if (actualEnemy >= enemies.Length)
                    actualEnemy = 0;
                enemiesCreated++;
            }
        }
    }
}
