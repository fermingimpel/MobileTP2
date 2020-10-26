using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public enum ShootType {
        Fire,
        Ice,
        Electric
    }

    [SerializeField] ShootType type;
    [SerializeField] float speedMovement;
    [SerializeField] float speedRotation;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float maxX;

    [SerializeField] float[] damages;

    private void Update() {
        transform.position += Vector3.right * speedMovement * Time.deltaTime;
        transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime);

        if (transform.position.x >= maxX)
            this.gameObject.SetActive(false);
    }

    public void SetType(ShootType t) {
        type = t;
        sr.sprite = sprites[(int)type];
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Enemy e = collision.GetComponent<Enemy>();
            if(e!=null) {
                e.HitEnemy(damages[(int)type]);
                return;
            }
        }
    }
}
