using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float startX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [Space]
    [SerializeField] float actualHealth;
    [SerializeField] float maxHealth;
    [Space]
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float baseSpeed;
    [Space]
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color normalColor;
    [SerializeField] Color hittedColor;
    bool hitted = false;
    bool canMove = true;
    bool slowed = false;
    public delegate void Dead();
    public static event Dead EnemyDead;


    void Start() {
        speed = baseSpeed;
        actualHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (!canMove)
            return;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void HitEnemy(float d) {
        actualHealth -= d;
        if (!hitted)
            StartCoroutine(Hit());
        if (actualHealth <= 0) {
            if (EnemyDead != null)
                EnemyDead();
            this.gameObject.SetActive(false);
        }
    }

    public void ResetEnemy() {
        transform.position = new Vector3(startX, Random.Range(minY, maxY));
        actualHealth = maxHealth;
        hitted = false;
        sr.color = normalColor;
        canMove = true;
        speed = baseSpeed;
    }

    public void NegativeEffect(int t) {
        if (t == 1) {
            if (!slowed)
                if (this.gameObject.activeSelf)
                    StartCoroutine(Slow());
        }
        else if (t == 2) {
            if (canMove)
                if (this.gameObject.activeSelf)
                    StartCoroutine(Stun());
        }
    }

    IEnumerator Stun() {
        canMove = false;
        yield return new WaitForSeconds(0.1f);
        canMove = true;
    }

    IEnumerator Slow() {
        slowed = true;
        speed *= 0.5f;
        yield return new WaitForSeconds(0.5f);
        speed = baseSpeed;
        slowed = false;
    }

    IEnumerator Hit() {
        hitted = true;
        sr.color = hittedColor;
        yield return new WaitForSeconds(0.1f);
        sr.color = normalColor;
        hitted = false;
        StopCoroutine(Hit());
        yield return null;
    }
}
