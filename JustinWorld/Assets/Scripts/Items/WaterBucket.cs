using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucket : MonoBehaviour {

    public int numOfHeals = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player" && numOfHeals > 0) {
            if (HeartManager.instance.canHeal()) {
                HeartManager.instance.heal();
                numOfHeals--;
            }
        }
    }
}
