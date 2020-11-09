using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    static Music m;
    [SerializeField] AudioSource source;
    float volume = 0.75f;
    void Awake() {
        source.volume = volume;
        if (m != null) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        m = this;
    }
}
