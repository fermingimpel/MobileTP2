using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PluginTest : MonoBehaviour {

    [SerializeField] TextMeshProUGUI outPutText;

    const string LOGGER_CLASS_NAME = "com.example.fglogger.FGSuperLogger";

    static AndroidJavaClass _pluginClass = null;
    public static AndroidJavaClass PluginClass {
        get {
            if (_pluginClass == null)
                _pluginClass = new AndroidJavaClass(LOGGER_CLASS_NAME);
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

    string GetLogs() {
        return PluginInstance.Call<string>("getAllLogs");
    }

    public void TestPluginBtn() {
       // if (Application.platform != RuntimePlatform.Android) {
       //     Debug.LogWarning("No tas en android wachin");
       //     outPutText.text = "No tas en android";
       //     return;
       // }

        PluginInstance.Call("sendLog", Time.time.ToString());

        outPutText.text = GetLogs();
    }


}
