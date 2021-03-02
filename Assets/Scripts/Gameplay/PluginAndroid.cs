using TMPro;
using UnityEngine;

public class PluginAndroid : Plugin {
    const string PLUGIN_NAME = "com.dvm2020gimpel.unityplugin.MyPlugin";
    static AndroidJavaClass _pluginClass = null;
    public static AndroidJavaClass PluginClass {
        get {
            if (_pluginClass == null)
                _pluginClass = new AndroidJavaClass(PLUGIN_NAME);
            return _pluginClass;
        }
    }

    static AndroidJavaObject _pluginInstance = null;
    public AndroidJavaObject PluginInstance {
        get {
            if (_pluginInstance == null)
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            return _pluginInstance;
        }
    }

    public override void SetEnemyKilled(int ek) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("setEnemiesKilled", ek);
    }
    public override void AddEnemyKilled(int ek) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("addEnemiesKilled", ek);
    }
    public override int GetEnemiesKilled() {
        if (Application.platform != RuntimePlatform.Android)
            return 0;

        return PluginInstance.Call<int>("getEnemiesKilled");
    }
    public override void SetTimesPlayed(int tp) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("setTimesPlayed", tp);
    }
    public override void AddTimesPlayed(int tp) {
        if(Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("addTimesPlayed", tp);
    }
    public override int GetTimesPlayed() {
        if (Application.platform != RuntimePlatform.Android)
            return 0;

        return PluginInstance.Call<int>("getTimesPlayed");
    }

    public override void SaveData() {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("saveData", Application.persistentDataPath, "tp.dat", 0);
        PluginInstance.Call("saveData", Application.persistentDataPath, "ek.dat", 1);
    }
    public override void LoadData() {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("loadData", Application.persistentDataPath, "tp.dat", 0);
        PluginInstance.Call("loadData", Application.persistentDataPath, "ek.dat", 1);
    }
}
