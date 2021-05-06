using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {

    private Animator anim;
    private float direction;

    //This is used to have a certain distance before the frog turns towards the player
    private float turnDistance = 0.3f;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    //Runs every frame
    private void FixedUpdate() {
        SetDirection();
    }

    //This will be used to set the x value in animator depending on where the player is
    private void SetDirection() {

        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        direction = 0;

        if(playerPos.x > transform.position.x + turnDistance) {
            direction += 1;
        } else if (playerPos.x < transform.position.x - turnDistance) {
            direction -= 1;
        }
        SetAnim();
    }

    private void SetAnim() {
        if (direction != 0) {
            anim.SetFloat("x", direction);
        } 
    }


}
