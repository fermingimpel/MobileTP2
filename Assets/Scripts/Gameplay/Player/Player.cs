﻿using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 movement;

    [SerializeField] GameObject[] balls;
    [SerializeField] float ballsRotationSpeed;

    [SerializeField] PlayerShoot[] playerShoots;
    int actualShoot = 0;

    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip soundShoot;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movement = new Vector3(InputManager.Instance.GetAxis("Horizontal"), InputManager.Instance.GetAxis("Vertical")) * speed;
        for (int i = 0; i < balls.Length; i++)
            if (balls[i] != null)
                balls[i].transform.Rotate(Vector3.forward * ballsRotationSpeed * Time.deltaTime); 
    }

    private void FixedUpdate() {
        rb.velocity = movement;
    }
    public void Shoot() {
        if (playerShoots[actualShoot] != null) {
            if (aSource.isPlaying)
                aSource.Stop();   
            aSource.PlayOneShot(soundShoot);
            playerShoots[actualShoot].gameObject.SetActive(true);
            int type = Random.Range(0, 3);
            playerShoots[actualShoot].SetType((PlayerShoot.ShootType)type);
            playerShoots[actualShoot].transform.position = balls[type].transform.position;
            actualShoot++;
            if (actualShoot >= playerShoots.Length)
                actualShoot = 0;
        }
    }
}
