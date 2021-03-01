using TMPro;
using UnityEngine;

public class PluginTest : MonoBehaviour {
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

    static PluginTest p;
    void Awake() {
        if (p != null) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        p = this;
    }

    public void SetEnemyKilled(int ek) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("setEnemiesKilled", ek);
    }
    public void AddEnemyKilled(int ek) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("addEnemiesKilled", ek);
    }
    public int GetEnemiesKilled() {
        if (Application.platform != RuntimePlatform.Android)
            return 0;

        return PluginInstance.Call<int>("getEnemiesKilled");
    }
    public void SetTimesPlayed(int tp) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("setTimesPlayed", tp);
    }
    public void AddTimesPlayed(int tp) {
        if(Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("addTimesPlayed", tp);
    }
    public int GetTimesPlayed() {
        if (Application.platform != RuntimePlatform.Android)
            return 0;

        return PluginInstance.Call<int>("getTimesPlayed");
    }

    public void SaveLogs() {
        SaveData.SaveLogData(this);
    }
    public void LoadLogs() {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginSaveData psd = SaveData.LoadLogData();
        Debug.Log(psd != null);
        if (psd != null) {
            PluginInstance.Call("setEnemiesKilled", psd.enemiesKilled);
            PluginInstance.Call("setTimesPlayed", psd.timesPlayed);
        }
    }
}
