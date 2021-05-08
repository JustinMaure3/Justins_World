using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour {

    public GameObject[] hearts;
    public int life;
    public float invincibilityTimer;
    public bool canTakeDamage = true;

    public GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
        for(float time = 0; time < 1.0f; time += Time.deltaTime/fadeTime) {
            renderer.color = Color.Lerp(dmgColor, originalColor, time);
            yield return null;
        }

        //turn player color back to normal
        renderer.color = originalColor;

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
