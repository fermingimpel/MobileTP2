using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    [SerializeField] GameObject grass;
    [SerializeField] Transform parent;
    [SerializeField] int width;
    [SerializeField] int height;
    void Start() {
        for(int i=0;i<width;i++)
            for(int j = 0; j < height; j++) {
                Instantiate(grass, new Vector3(i, j, 0), Quaternion.identity, parent);
            }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
