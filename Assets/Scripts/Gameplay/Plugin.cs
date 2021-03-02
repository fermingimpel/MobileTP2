using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public /*abstract*/ class Plugin : MonoBehaviour {

    //static Plugin p;
    //void Awake() {
    //    if (p != null) {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    DontDestroyOnLoad(gameObject);
    //    p = this;
    //}

    public virtual void SetEnemyKilled(int ek) {
        Debug.Log("SetEnemyKilled");
    }
    public virtual void AddEnemyKilled(int ek) {
        Debug.Log("AddEnemyKilled");

    }
    public virtual int GetEnemiesKilled() {
        Debug.Log("GetEnemiesKilled");

        return 0;
    }
    public virtual void SetTimesPlayed(int tp) {
        Debug.Log("SetTimesPlayed");

    }
    public virtual void AddTimesPlayed(int tp) {
        Debug.Log("AddTimesPlayed");

    }
    public virtual int GetTimesPlayed() {
        Debug.Log("GetTimesPlayed");
        return 0;
    }

    public virtual void SaveData() {
        Debug.Log("SaveData");

    }
    public virtual void LoadData() {
        Debug.Log("LoadData");

    }
}
