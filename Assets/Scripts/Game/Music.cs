﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    static Music m;
    [SerializeField] AudioSource source;
    [SerializeField] float volume ;
    void Awake() {
        if (m != null) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        m = this;
        source.volume = volume;
    }
}
