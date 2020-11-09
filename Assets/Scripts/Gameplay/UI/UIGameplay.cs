using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI textEnemiesLeft;
    [SerializeField] TextMeshProUGUI textDifficulty;
    private void Start() {
        EnemyManager.KilledEnemy += KilledEnemy;
        EnemyManager.Difficulty += ChangeDifficulty;
    }
    private void OnDisable() {
        EnemyManager.KilledEnemy -= KilledEnemy;
        EnemyManager.Difficulty -= ChangeDifficulty;

    }
    void ChangeDifficulty(string d) {
        textDifficulty.text = "DIFFICULTY: " + d;
    }
    void KilledEnemy(int er) {
        textEnemiesLeft.text = "ENEMIES LEFT: " + er;
    }
    public void PressedButtonShoot() {
        player.Shoot();
    }
    
}
