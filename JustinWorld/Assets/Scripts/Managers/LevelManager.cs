using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject player;

    public GameObject mainCamera;

    private float fallThreshold;

    private void FixedUpdate() {
        if(player.transform.position.y < fallThreshold) {
            Respawn();
            HeartManager.instance.takeDamage();
        }
    }

    private void Awake() {
        instance = this;
        fallThreshold = mainCamera.GetComponent<SmoothCamera>().minY - 2;
    }

    private void Start() {
        //PauseMenuManager.instance.Resume();
    }

    public void Respawn() {
        player.transform.position = respawnPoint.position;

    }


}
