using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour {
    public static HeartManager instance;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public int life = 3;
    public float invincibilityTimer = 3;
    public bool canTakeDamage = true;

    public GameObject player;

    private void Awake() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //This function will take away a heart
    public void takeDamage(Transform enemy) {
        if(canTakeDamage) {
            life--;

            //Apply invulnerability and knockback
            if (life > 0) {
                _ = StartCoroutine(GetInvulnerable());
                player.GetComponent<Knockback>().ActivateKnockback(enemy);
            }

            //Update hearts
            if (life == 0) {
                heart1.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
                GameOver();
            } else if (life == 1) {
                heart2.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            } else if (life == 2) {
                heart3.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            }
        }
    }

    public void takeDamage() {
        if (canTakeDamage) {
            life--;
            //Update hearts
            if (life == 0) {
                heart1.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
                GameOver();
            } else if (life == 1) {
                heart2.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            } else if (life == 2) {
                heart3.gameObject.GetComponent<Animator>().SetBool("isDirty", true);
            }
        }
    }

    //This is used to make the player invincible for a few seconds
    IEnumerator GetInvulnerable() {
        canTakeDamage = false;
        StartCoroutine(ChangeColor());
        yield return new WaitForSeconds(invincibilityTimer);
        canTakeDamage = true;
    }

    //This is used to change the color of the player and then fade back to the original color
    IEnumerator ChangeColor() {
        //Set up the original states
        SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
        Color originalColor = renderer.color;
        Color dmgColor = new Color(130f, 0f, 0f, 1f);
        float fadeTime = invincibilityTimer - 1;

        //Change to damage color
        renderer.color = dmgColor;

        yield return new WaitForSeconds(1);

        //Fade back to original color
        for (float time = 0; time < 1.0f; time += Time.deltaTime / fadeTime) {
            renderer.color = Color.Lerp(dmgColor, originalColor, time);
            yield return null;
        }

            //turn player color back to normal
            renderer.color = originalColor;
        

    }

    public void heal() {
        life++;
        if (life == 3) {
            heart3.gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        } else if (life == 2) {
            heart2.gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        }
    }

    public bool canHeal() {
        if (life < 3) {
            return true;
        }

        return false;
    }

    public void restoreAll() {
        life = 3;
        heart1.gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        heart2.gameObject.GetComponent<Animator>().SetBool("isDirty", false);
        heart3.gameObject.GetComponent<Animator>().SetBool("isDirty", false);
    }

    //Function for when the players hearts run out
    public void GameOver() {
        //GAME OVER
        EndMenuManager.instance.ActivateLoseMenu();

    }
}
