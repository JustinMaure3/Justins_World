using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject player;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        player.transform.position = respawnPoint.position;

    }


}
