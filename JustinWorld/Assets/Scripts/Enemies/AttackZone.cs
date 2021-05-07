using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour {

    //Function that activates when a game object enters a trigger zone
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.GetComponentInParent<Animator>().SetBool("isAttacking", true);
        }
    }

    //Function that activates when a game object leaves trigger zones
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.GetComponentInParent<Animator>().SetBool("isAttacking", false);
        }

    }
}
