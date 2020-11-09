using TMPro;
using UnityEngine;

public class PluginTest : MonoBehaviour {

    [SerializeField] TextMeshProUGUI outputText;

    const string PLUGIN_NAME = "com.dvm2020gimpel.plug.FGLogger";
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

    void SendLog(string msj) {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginInstance.Call("sendLog", msj);
    }
    public string GetLogs() {
        if (Application.platform != RuntimePlatform.Android)
            return "";

        return PluginInstance.Call<string>("getAllLogs");
    }
    public string GetLogIndex(int i) {
        if (Application.platform != RuntimePlatform.Android)
            return "";

        return PluginInstance.Call<string>("getIndexLog", i);
    }
    public void TestPluginButton() {
        if (Application.platform != RuntimePlatform.Android) {
            Debug.LogWarning("You are not in Android Platform");
            outputText.text = "You are not in Android Platform";
            return;
        }

        SendLog(((int)Time.time).ToString());
        outputText.text = GetLogs();
    }

    public int GetLogLength() {
        if (Application.platform != RuntimePlatform.Android)
            return 0;

        return PluginInstance.Call<int>("getLogLength");
    }
    public void SaveLogs() {
        SaveData.SaveLogData(this);
    }
    public void LoadLogs() {
        if (Application.platform != RuntimePlatform.Android)
            return;

        PluginSaveData psd = SaveData.LoadLogData();
        PluginInstance.Call("clearLog");
        Debug.Log(psd != null);
        if (psd != null) {
            for (int i = 0; i < psd.logs.Count; i++)
                SendLog(psd.logs[i]);
            outputText.text = GetLogs();
            return;
        }
    }

    public void ClearLogs() {
        if (Application.platform != RuntimePlatform.Android)
            PluginInstance.Call("clearLog");
        outputText.text = GetLogs();
    }

    public void DeleteLogs() {
        PluginInstance.Call("clearLog");
        if (Application.platform != RuntimePlatform.Android)
            return;
        outputText.text = GetLogs();
        SaveLogs();
    }
}
