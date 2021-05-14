using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    //This method will be used to detect player interaction then move to the next level
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            //Activate winner UI
            EndMenuManager.instance.ActivateWinMenu();
        }
        
    }

}
