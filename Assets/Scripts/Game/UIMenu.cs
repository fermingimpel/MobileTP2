using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour {
    [SerializeField] PluginTest pluginTest;

    [SerializeField] TextMeshProUGUI textTimesPlayed;
    [SerializeField] TextMeshProUGUI textEnemiesKilled;
    void Start() {
        pluginTest = FindObjectOfType<PluginTest>();
        pluginTest.LoadLogs();
        textTimesPlayed.text = "Times Played: " + pluginTest.GetTimesPlayed();
        textEnemiesKilled.text = "Enemies Killed: " + pluginTest.GetEnemiesKilled();
    }
}
