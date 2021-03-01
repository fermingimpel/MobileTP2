package com.dvm2020gimpel.unityplugin;

import android.util.Log;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
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

    public void saveData(String path, String name, int value){
        File file = new File(path, name);
        try {
            FileOutputStream stream = new FileOutputStream(file);
            try {
                if(value==0)
                    stream.write(Integer.toString(timesPlayed).getBytes());
                else
                    stream.write(Integer.toString(enemiesKilled).getBytes());
            }
            finally {
                stream.close();
            }
        }
        catch (IOException e) {
           Log.e(LOG_TAG, "No se pudo guardar: " + name);
        }
    }

    public void loadData(String path, String name, int value) {
        File file = new File(path, name);
        if (!file.exists())
            return;

        int length = (int) file.length();
        byte[] bytes = new byte[length];

        try {
            FileInputStream stream = new FileInputStream(file);
            try {
                stream.read(bytes);
            }
            finally {
                stream.close();
            }
        }
        catch (IOException e) {
            Log.e(LOG_TAG, "No se pudo cargar: " + name);
        }

        if(value ==0){
            String tp = new String(bytes);
            timesPlayed = Integer.parseInt(tp);
        }
        else {
            String ek = new String(bytes);
            enemiesKilled = Integer.parseInt(ek);
        }
    }

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



