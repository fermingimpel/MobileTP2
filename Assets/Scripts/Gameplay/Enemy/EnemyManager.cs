using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField] float timeToSpawn;
    [SerializeField] int enemiesToCreate;

    [SerializeField] Enemy[] enemies;
    int actualEnemy=0;
    void Start() {
        StartCoroutine(SpawnEnemies());
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
