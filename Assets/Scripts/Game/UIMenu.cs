using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour {
    [SerializeField] Plugin pluginTest;

    [SerializeField] TextMeshProUGUI textTimesPlayed;
    [SerializeField] TextMeshProUGUI textEnemiesKilled;
    void Start() {
        if (Application.platform == RuntimePlatform.Android)
            pluginTest = FindObjectOfType<PluginAndroid>();
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            pluginTest = FindObjectOfType<PluginIOS>();
        

        pluginTest.LoadData();
        textTimesPlayed.text = "Times Played: " + pluginTest.GetTimesPlayed();
        textEnemiesKilled.text = "Enemies Killed: " + pluginTest.GetEnemiesKilled();
    }
}
