using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {

    //Function to hit the player
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            HeartManager.instance.takeDamage(this.transform);
        }
    }
}
