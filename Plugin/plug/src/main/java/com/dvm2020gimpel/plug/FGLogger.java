package com.dvm2020gimpel.plug;

import android.util.Log;

import java.util.ArrayList;

public class FGLogger  {

    private static final String LOG_TAG = "FGLogger";
private static final String GAME_TAG = "TPNro2";

    private static FGLogger _instance = null;
    public static FGLogger getInstance(){
        if(_instance == null){
            Log.d(LOG_TAG , "FGLogger created");
            _instance = new FGLogger();
        }
        return _instance;
    }

    private ArrayList<String> allLogs = new ArrayList<String>();

    public void sendLog(String msj){
        Log.d(LOG_TAG, msj);
        allLogs.add(msj);
    }

    private static final String SEPARATOR = " - ";
    public String getAllLogs(){
        Log.d(LOG_TAG, "getAllLogs()");
        String logs = "";
        for(int i=0;i< allLogs.size(); i++)
            logs += allLogs.get(i) + SEPARATOR;
        return logs;
    }

    public void clearLog(){
        allLogs.clear();
    }
    public String getIndexLog(int i){
        return allLogs.get(i);
    }

    public int getLogLength(){
        return allLogs.size();
    }

}
