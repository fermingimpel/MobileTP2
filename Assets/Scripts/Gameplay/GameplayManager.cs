using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {
    [SerializeField] EnemyManager em;
    [SerializeField] ScenesManager sm;
    void Start() {
        EnemyManager.EliminatedAllEnemies += AllEnemiesEliminated;
    }
    private void OnDisable() {
        EnemyManager.EliminatedAllEnemies -= AllEnemiesEliminated;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void AllEnemiesEliminated() {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame() {
        yield return new WaitForSeconds(5.0f);
        sm.ChangeScene("Menu");
    }
}
