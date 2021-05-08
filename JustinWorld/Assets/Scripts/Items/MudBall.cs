using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBall : MonoBehaviour {

    public float direction = 0;
    public float destructionTime = 3;
    public float speed = 2;
    private Animator anim;


    private void Awake() {
        anim = GetComponent<Animator>();

        //Set up the direction the mud is being thrown and its animation
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        if(playerPos.x > transform.position.x) {
            direction = 1;
        } else if (playerPos.x < transform.position.x) {
            direction = -1;
        }
        anim.SetFloat("x", direction);

        //Start the death timer
        StartCoroutine(DestroyByTime());
    }

    private void Update() {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    //Triggers when hits player 
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<HeartSystem>().takeDamage(this.transform);
            StartCoroutine(BreakMud());
        }
    }

    IEnumerator DestroyByTime() {
        yield return new WaitForSeconds(destructionTime);
        StartCoroutine(BreakMud());
    }

    //This is used to set up a quick break animation before it gets destroyed
    IEnumerator BreakMud() {
        anim.SetBool("isBreaking", true);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
