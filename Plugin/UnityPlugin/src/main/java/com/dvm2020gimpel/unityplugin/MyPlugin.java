package com.dvm2020gimpel.unityplugin;

import android.util.Log;

public class MyPlugin {

    private static final String LOG_TAG = "FGLogger";
    private static final String GAME_TAG = "TPNro2";

    private static MyPlugin _instance = null;
    public static MyPlugin getInstance() {
        if (_instance == null) {
            Log.d(LOG_TAG, "FGLogger created");
            _instance = new MyPlugin();
        }
        return _instance;
    }

    private int timesPlayed = 0;
    private int enemiesKilled = 0;

    public void setTimesPlayed(int tp) {
        timesPlayed = tp;
    }
    public void addTimesPlayed(int tp) {
        timesPlayed += tp;
    }
    public int getTimesPlayed() {
        return timesPlayed;
    }

    public void setEnemiesKilled(int ek) {
        enemiesKilled = ek;
    }
    public void addEnemiesKilled(int ek) {
        enemiesKilled += ek;
    }
    public int getEnemiesKilled() {
        return enemiesKilled;
    }
}



