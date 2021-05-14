using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerManager : MonoBehaviour {
    public static TimerManager instance;

    public Text timerText;
    public bool isTimerOn;
    public float time;
    public TimeSpan displayTime;

    private void Awake() {
        instance = this;
        isTimerOn = false;
    }

    private void Update() {
        if(isTimerOn) {
            time += Time.deltaTime;
            displayTime = TimeSpan.FromSeconds(time);
        }
    }

    public void BeginTimer() {
        isTimerOn = true;
        time = 0f;
    }

    public void EndTimer() {
        isTimerOn = false;
        timerText.text = "Time: " + displayTime.ToString("mm':'ss'.'ff") ;
    } 

    
}
