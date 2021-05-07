using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFrogController : MonoBehaviour {
    private Animator anim;
    private float direction;

    public Transform launchPosition;
    public GameObject mudBall;
    private bool isShooting = false;

    //This is used to have a certain distance before the frog turns towards the player
    public float turnDistance = 0.3f;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    //Runs every frame
    private void FixedUpdate() {
        SetDirection();
        if (anim.GetBool("isAttacking") && !isShooting) {
            StartCoroutine(Shoot());
        }
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
        launchPosition.localPosition = new Vector3(0.2f * direction, launchPosition.localPosition.y, launchPosition.localPosition.z);
        SetAnim();
    }

    //Setting the x axis animation
    private void SetAnim() {
        if (direction != 0) {
            anim.SetFloat("x", direction);
        }
    }

    //This is used to shoot a mudball at player
    IEnumerator Shoot() {
        //Instantiate a mud ball
        isShooting = true;
        yield return new WaitForSeconds(0.4f) ;
        Instantiate<GameObject>(mudBall, launchPosition.position, new Quaternion());
        yield return new WaitForSeconds(1.1f);
        isShooting = false;
    }

}
