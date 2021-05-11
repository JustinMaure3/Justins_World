using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFrogController : MonoBehaviour {

    private Animator anim;
    public float direction;

    public Transform whirlwind;

    //This is used to have a certain distance before the frog turns towards the player
    public float turnDistance = 0.1f;

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

        if (playerPos.x > transform.position.x + turnDistance) {
            direction += 1;
        } else if (playerPos.x < transform.position.x - turnDistance) {
            direction -= 1;
        }

        whirlwind.localPosition = new Vector3(0.6f * direction, whirlwind.localPosition.y, whirlwind.localPosition.z);
        SetAnim();
    }

    private void SetAnim() {
        if (direction != 0) {
            anim.SetFloat("x", direction);
        }
    }


}
