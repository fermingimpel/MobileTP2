using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI textEnemiesLeft;
    [SerializeField] TextMeshProUGUI textDifficulty;
    [SerializeField] TextMeshProUGUI textLives;
    private void Awake() {
        EnemyManager.KilledEnemy += KilledEnemy;
        EnemyManager.Difficulty += ChangeDifficulty;
        House.HittedHome += ChangeLives;
    }
    private void OnDisable() {
        EnemyManager.KilledEnemy -= KilledEnemy;
        EnemyManager.Difficulty -= ChangeDifficulty;
        House.HittedHome -= ChangeLives;
    }
    void ChangeLives(int l) {
        textLives.text = "LIVES: " + l;
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
