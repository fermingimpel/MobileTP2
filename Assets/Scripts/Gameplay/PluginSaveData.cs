using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PluginSaveData {
    public int timesPlayed;
    public int enemiesKilled;

    public PluginSaveData(PluginTest t) {
        timesPlayed = t.GetTimesPlayed();
        enemiesKilled = t.GetEnemiesKilled();
    }
}