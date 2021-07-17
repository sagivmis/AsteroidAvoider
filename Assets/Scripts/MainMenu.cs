using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private iOSNotificationHandler iosNotificationHandler;
    private float timer = 0;
    private bool sentNotification = false;

  public void startGame(){
      SceneManager.LoadScene(1);
  }
  private void Start() {
    
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"HIGHSCORE: {highScore}";
  }

  private void Update() {
    timer+=Time.deltaTime;
    if(timer >= 5 && !sentNotification){
      sentNotification=true;
      timer = 0;
      initNotifications();
    }
  }
  private void initNotifications(){
    DateTime notificationReady = DateTime.Now.AddMinutes(1);
    #if UNITY_IOS
    iosNotificationHandler.ScheduleNotification(1);
    #elif UNITY_ANDROID
    androidNotificationHandler.ScheduleNotification(notificationReady);
    #endif
  }
}
