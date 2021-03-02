using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {
    [SerializeField] EnemyManager em;
    [SerializeField] ScenesManager sm;
    [SerializeField] Plugin pluginTest;
    void Start() {
        EnemyManager.EliminatedAllEnemies += AllEnemiesEliminated;
        House.Lose += AllEnemiesEliminated;
        EnemyManager.KilledEnemy += KilledEnemy;

        if (Application.platform == RuntimePlatform.Android)
            pluginTest = FindObjectOfType<PluginAndroid>();
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            pluginTest = FindObjectOfType<PluginIOS>();
    }
    private void OnDisable() {
        EnemyManager.EliminatedAllEnemies -= AllEnemiesEliminated;
        House.Lose -= AllEnemiesEliminated;
        EnemyManager.KilledEnemy -= KilledEnemy;
        pluginTest.SaveData();
    }

    void AllEnemiesEliminated() {
        StartCoroutine(EndGame());
    }

    void KilledEnemy(int a) {
        pluginTest.AddEnemyKilled(1);
    }

    IEnumerator EndGame() {
        pluginTest.AddTimesPlayed(1);
        yield return new WaitForSeconds(5.0f);
        sm.ChangeScene("Menu");
    }
}