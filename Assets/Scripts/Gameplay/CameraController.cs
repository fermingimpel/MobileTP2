using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] Canvas canvas;


    //fov: 7 --------- aspect: 16/9
    //fox: X --------- aspect 4/3
    //(3/4) * 7 / (9/16)

    [Serializable]
    public class CameraWidthHeight {
        public float width;
        public float height;
        public float cameraSize;
    }

    [SerializeField] List<CameraWidthHeight> cameraWidthHeights;

    float baseSize = 7f;
    void Awake() {
        //bool foundedAspectRatio = false;
        //
        //for (int i = 0; i < cameraWidthHeights.Count; i++) 
        //    if ((Screen.width / Screen.height) == (cameraWidthHeights[i].width / cameraWidthHeights[i].height)) {
        //
        //        foundedAspectRatio = true;
        //        cam.orthographicSize = cameraWidthHeights[i].cameraSize;
        //        i = cameraWidthHeights.Count;
        //    }
        //
        //if (!foundedAspectRatio)
        //    cam.orthographicSize = 6;
    }
    private void LateUpdate() {
        cam.orthographicSize = ((float)Screen.height / (float)Screen.width) * baseSize / (1080f / 1920f);
    }
}
