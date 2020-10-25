using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 movement;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movement = new Vector3(InputManager.Instance.GetAxis("Horizontal"), InputManager.Instance.GetAxis("Vertical")) * speed;
    }

    private void FixedUpdate() {
        rb.velocity = movement;
    }
}
