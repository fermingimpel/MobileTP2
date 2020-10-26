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
    [Space]
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color normalColor;
    [SerializeField] Color hittedColor;
    bool hitted = false;
    void Start() {
        actualHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void HitEnemy(float d) {
        actualHealth -= d;
        if (!hitted)
            StartCoroutine(Hit());
        if(actualHealth <= 0) 
            this.gameObject.SetActive(false);
        
    }

    public void ResetEnemy() {
        transform.position = new Vector3(startX, Random.Range(minY, maxY));
        actualHealth = maxHealth;
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
