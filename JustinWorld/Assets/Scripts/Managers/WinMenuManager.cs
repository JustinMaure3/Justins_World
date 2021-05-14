using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuManager : MonoBehaviour {
    public static WinMenuManager instance;

    public GameObject winMenuUI;
    public GameObject player;

    public string nextLevel;
    public string currentLevel;

    private void Awake() {
        instance = this;
        player = GameObject.FindWithTag("Player");
    }

    //When the player reaches the end
    public void ActivateMenu() {
        //Pause game
        Time.timeScale = 0f;

        //Activate the UI
        winMenuUI.SetActive(true);

        //Disable player controls
        player.GetComponent<PlayerController>().controls.Basic.Disable();

        //Set first button to selected
        EventSystem.current.SetSelectedGameObject(winMenuUI.GetComponentInChildren<Button>().gameObject, null);
    }

    //When the player hits the next button
    public void OnNext() {
        //Play the next level
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

    //When the player hits the restart button
    public void OnRestart() {
        //Restart the level
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
    }

    //When the player hits the exit button
    public void OnExit() {
        //Launch the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
