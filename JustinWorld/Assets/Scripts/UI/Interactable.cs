using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public GameObject dialogueBox;
    private Text dialogeText;
    public string dialogue;
    public bool isDialogueActive = false;

    private void Awake() {
        dialogeText = dialogueBox.GetComponentInChildren<Text>();
    }


    //This script makes the interactions
    public void Interact() {
        dialogueBox.SetActive(true);
        dialogeText.text = dialogue;
    }

    public void StopInteracting() {
        dialogueBox.SetActive(false);

    }
}
