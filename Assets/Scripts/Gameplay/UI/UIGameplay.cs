using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplay : MonoBehaviour {
    [SerializeField] Player player;
    public void PressedButtonShoot() {
        player.Shoot();
    }
}
