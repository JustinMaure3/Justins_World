using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float knockback = 2;                     //knockback force
    private float knockbackLength = 0.5f;        //Total amount of time 
    public float enemyDirection;                //if negative then ememy is attacking from left. if positive enemy is to the right

    private Rigidbody2D knockbackObject;        //The object that will be effected by the knockback

    private void Awake() {
        knockbackObject = GetComponent<Rigidbody2D>();
    }

    public void ActivateKnockback(Transform enemy) {
        //Find enemy direction
        if (enemy.position.x > transform.position.x) {
            enemyDirection = 1;
        } else if (enemy.position.x < transform.position.x) {
            enemyDirection = -1;
        }

        //Start knockback
        if (!GetComponent<HeartSystem>().canTakeDamage) {
            StartCoroutine(KnockBack());
        }
    }

    IEnumerator KnockBack() {
        //Stop players controls
        GetComponent<CharacterMovement>().DisableMovement();

        //If enemy is hitting from right
        if (enemyDirection > 0) {
            knockbackObject.velocity = new Vector2(-knockback, knockback + 1);
        }
        //If enemy is hitting from left
        else if (enemyDirection < 0) {
            knockbackObject.velocity = new Vector2(knockback, knockback + 1);
        }

        //Wait for knockbakc length
        yield return new WaitForSeconds(knockbackLength);

        //Enable controls
        GetComponent<CharacterMovement>().EnableMovement();
    }
}
