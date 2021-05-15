using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour {
    public static PauseMenuManager instance;

    public bool isPaused;
    public GameObject pauseMenuUI;
    private GameObject player;

    private void Awake() {
        instance = this;
        player = GameObject.FindWithTag("Player");
        isPaused = false;
    }

    //Function is triggered when player hits the pause button
    public void OnPauseButton() {
        if(!isPaused) {
            Pause();
        }
    }

    //Function to resume the game
    public void Resume() {
        isPaused = false;
        //Hide UI and reset the selected button
        pauseMenuUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);

        //Resume time and enable game controls again
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().OnEnable();
    }

    //Function to pause the game
    public void Pause() {
        isPaused = true;
        //Show UI and manually set the first selected button
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(pauseMenuUI.GetComponentInChildren<Button>().gameObject, null);

        //Pause time and disable game controls 
        Time.timeScale = 0f;
        player.GetComponent<PlayerController>().OnDisable();
    }

    //When the options button is pressed
    public void OnRestartButton() {
        //Restart the level
        Time.timeScale = 1f;
        //isPaused = false;
        SceneManager.LoadScene(EndMenuManager.instance.currentLevel, LoadSceneMode.Single);
    }

    //When the exit button is pressed
    public void OnExitButton() {
        //Launch the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
