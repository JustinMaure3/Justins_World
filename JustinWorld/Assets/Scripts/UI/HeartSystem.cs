using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour {

    public GameObject[] hearts;
    public int life;
    public float invincibilityTimer;
    public bool canTakeDamage = true;

    //This function will take away a heart
    public void takeDamage() {
        if(canTakeDamage) {
            life--;
            if (life == 0) {
                hearts[0].gameObject.GetComponent<Animator>().SetBool("isDirty", true);
                //GAME OVER
            } else if (life == 1) {
                hearts[1].gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            } else if (life == 2) {
                hearts[2].gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            }
            _ = StartCoroutine(GetInvulnerable());
        }
    }

    IEnumerator GetInvulnerable() {
        //ignore collision between player (9) and enemy (10) layers
        canTakeDamage = false;
        //Physics2D.IgnoreLayerCollision(9, 10, true);
        yield return new WaitForSeconds(invincibilityTimer);
        //Physics2D.IgnoreLayerCollision(9, 10, false);
        canTakeDamage = true;

    }

    public void heal() {
        life++;
        if (life == 3) {
            hearts[2].gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        } else if (life == 2) {
            hearts[1].gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        }
    }

    public bool canHeal() {
        if (life < 3) {
            return true;
        }

        return false;
    }
}
