using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour {

    //Amount of force that will push player
    public float windForce = 50f;
    public float windLength = 0.5f;

    private Transform playerPos;
    private float direction = 0f;

    private Animator anim;

    //Awake method
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void OnEnable() {
        playerPos = GameObject.FindWithTag("Player").transform;

        //Get direction
        direction = this.GetComponentInParent<GreenFrogController>().direction;
        anim.SetFloat("x", direction);
    }

    //On trigger this will start the push player coroutine
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            StartCoroutine(PushPlayer(collision));

        }
    }

    //This will apply force to the player
    IEnumerator PushPlayer(Collider2D collision) {
        collision.GetComponent<PlayerController>().DisableMovement();

        Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
        player.AddForce(new Vector2(direction * windForce, 0f), ForceMode2D.Impulse);

        yield return new WaitForSeconds(windLength);

        collision.GetComponent<PlayerController>().EnableMovement();
    }
}
