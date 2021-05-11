using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    public GameObject bubble;

    //When the player enters the signs radius
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            bubble.SetActive(true);
        }
    }

    //When the player leaves the signs radius
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            bubble.SetActive(false);
        }
    }

}
