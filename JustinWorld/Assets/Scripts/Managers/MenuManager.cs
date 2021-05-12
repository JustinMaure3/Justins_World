using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    //Function that will start the first level
    public void OnStart() {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    //Function that will bring the user to the options screen
    public void OnOptions() {

    }

    //Function that will exit the application
    public void OnQuit() {
        Application.Quit();
        print("It quit");
    }

}
