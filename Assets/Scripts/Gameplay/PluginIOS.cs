using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginIOS : Plugin {

    //Cosas de IOS

    //const string PLUGIN_NAME = "com.dvm2020gimpel.unitypluginIOS.MyIOSPlugin";
    //static AndroidJavaClass _pluginClass = null;
    //public static AndroidJavaClass PluginClass {
    //    get {
    //        if (_pluginClass == null)
    //            _pluginClass = new AndroidJavaClass(PLUGIN_NAME);
    //        return _pluginClass;
    //    }
    //}
    //
    //static AndroidJavaObject _pluginInstance = null;
    //public AndroidJavaObject PluginInstance {
    //    get {
    //        if (_pluginInstance == null)
    //            _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
    //        return _pluginInstance;
    //    }
    //}

    public override void SetEnemyKilled(int ek) {
        Debug.Log("Has not been implemented...");
    }
    public override void AddEnemyKilled(int ek) {
        Debug.Log("Has not been implemented...");

    }
    public override int GetEnemiesKilled() {
        Debug.Log("Has not been implemented...");
        return 0;
    }
    public override void SetTimesPlayed(int tp) {
        Debug.Log("Has not been implemented...");
    }
    public override void AddTimesPlayed(int tp) {
        Debug.Log("Has not been implemented...");

    }
    public override int GetTimesPlayed() {
        Debug.Log("Has not been implemented...");
        return 0;
    }

    public override void SaveData() {
        Debug.Log("Has not been implemented...");
    }
    public override void LoadData() {
        Debug.Log("Has not been implemented...");
    }
}
