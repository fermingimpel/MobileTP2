using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PluginSaveData {
    public List<string> logs;

    public PluginSaveData(PluginTest t) {
        logs = new List<string>();
        for (int i = 0; i < t.GetLogLength(); i++)
            logs.Add(t.GetLogIndex(i));
    }
}