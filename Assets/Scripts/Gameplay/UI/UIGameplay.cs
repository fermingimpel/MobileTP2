using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour {
    [SerializeField] Player player;
    public void PressedButtonShoot() {
        player.Shoot();
    }
}
