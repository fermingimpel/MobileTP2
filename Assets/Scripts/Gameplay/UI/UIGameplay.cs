using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI fpstext;

    private void FixedUpdate() {
        fpstext.text = (1.0f / Time.deltaTime).ToString("F2");
    }
    public void PressedButtonShoot() {
        player.Shoot();
    }
}
