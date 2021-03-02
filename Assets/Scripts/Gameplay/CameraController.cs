using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] Canvas canvas;

    [Serializable]
    public class CameraWidthHeight {
        public float width;
        public float height;
        public float cameraSize;
    }

    [SerializeField] List<CameraWidthHeight> cameraWidthHeights;
    void Awake() {
        bool foundedAspectRatio = false;

        for (int i = 0; i < cameraWidthHeights.Count; i++) 
            if ((canvas.pixelRect.width / canvas.pixelRect.height) == (cameraWidthHeights[i].width / cameraWidthHeights[i].height)) {
                foundedAspectRatio = true;
                cam.orthographicSize = cameraWidthHeights[i].cameraSize;
                i = cameraWidthHeights.Count;
            }

        if (!foundedAspectRatio)
            cam.orthographicSize = 6;
    }

}
