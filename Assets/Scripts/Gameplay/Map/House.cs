using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    [SerializeField] GameObject house;
    public static event Action Lose;
    bool ended = false;
    [SerializeField] AudioSource source;

    [SerializeField] int lives;

    public delegate void EnemyHitHome(int l);
    public static event EnemyHitHome HittedHome;

    private void Start() {
        if (HittedHome != null)
            HittedHome(lives);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!ended && collision.CompareTag("Enemy")) {
            lives--;

            collision.GetComponent<Enemy>().HitEnemy(9999);

            if (lives <= 0) {
                lives = 0;
                if (Lose != null)
                    Lose();
                ended = true;
                house.SetActive(false);
                source.Play();
            }

            if (HittedHome != null)
                HittedHome(lives);

        }
    }
}
