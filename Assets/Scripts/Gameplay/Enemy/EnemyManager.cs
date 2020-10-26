using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField] float timeToSpawn;
    [SerializeField] int enemiesToCreate;

    [SerializeField] Enemy[] enemies;
    int actualEnemy=0;
    int enemiesEliminated = 0;

    public delegate void AllEnemiesEliminated();
    public static event AllEnemiesEliminated EliminatedAllEnemies;

    void Start() {
        Enemy.EnemyDead += EnemyDead;
        StartCoroutine(SpawnEnemies());
    }

    private void OnDisable() {
        Enemy.EnemyDead -= EnemyDead;
    }

    void EnemyDead() {
        enemiesEliminated++;
        if(enemiesEliminated == enemiesToCreate) {
            if (EliminatedAllEnemies != null)
                EliminatedAllEnemies();
        }
    }

    IEnumerator SpawnEnemies() {
        int enemiesCreated = 0;
        while (enemiesCreated < enemiesToCreate) {
            yield return new WaitForSeconds(timeToSpawn);
            if (enemies[actualEnemy] != null) {
                enemies[actualEnemy].gameObject.SetActive(true);
                enemies[actualEnemy].ResetEnemy();
            }

            actualEnemy++;
            if (actualEnemy >= enemies.Length)
                actualEnemy = 0;
            enemiesCreated++;
        }
        StopCoroutine(SpawnEnemies());
    }
}
