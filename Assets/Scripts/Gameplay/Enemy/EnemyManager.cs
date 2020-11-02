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
        enemiesEliminated++;
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
