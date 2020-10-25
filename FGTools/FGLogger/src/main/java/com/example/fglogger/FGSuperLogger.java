package com.example.fglogger;

import android.util.Log;

import java.util.ArrayList;

public class FGSuperLogger {
    private static final String LOG_TAG = "FGSuperLogger";
    private static final String GAME_TAG = "TPNro2";

    private static FGSuperLogger _instance = null;

    public FGSuperLogger() {

    }

    public static FGSuperLogger getInstance(){
        if(_instance == null){
            Log.d(LOG_TAG, "FGSuperLogger Created");
            _instance = new FGSuperLogger();
        }
        return _instance;
    }

    private ArrayList<String> allLogs = new ArrayList<String>();

    public void sendLog(String msj){
        Log.d(GAME_TAG, logName + msj);
        allLogs.add(msj);
    }

    public FGSuperLogger(String logName){
        this.logName = logName;
    }

    private String logName = "";

    public static String staticMethod(String add){
        return "xd" + add;
    }

    private static final String SEPARATOR ="\n";
    public String getAllLogs(){
        Log.d(LOG_TAG, "getAllLogs()");
        String logs = "";
        for(int i=0;i<allLogs.size(); i++)
            logs += allLogs.get(i) + SEPARATOR;

        return logs;
    }

}