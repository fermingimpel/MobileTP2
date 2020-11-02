using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    [SerializeField] GameObject house;
    public static event Action Lose;
    bool ended = false;
    [SerializeField] AudioSource source;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!ended && collision.CompareTag("Enemy")) {
            if (Lose != null)
                Lose();
            ended = true;
            house.SetActive(false);
            source.Play();
        }
    }
}
