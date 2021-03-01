using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData {
    public static void SaveLogData(PluginTest t) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/logs.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PluginSaveData logsData = new PluginSaveData(t);
        formatter.Serialize(stream, logsData);
        stream.Close();
    }
    public static PluginSaveData LoadLogData() {
        string path = Application.persistentDataPath + "/logs.dat";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PluginSaveData psd = (PluginSaveData)formatter.Deserialize(stream);
            stream.Close();
            return psd;
        }
        return null;
    }

}