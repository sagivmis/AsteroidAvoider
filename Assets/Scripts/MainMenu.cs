using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
  public void startGame(){
      SceneManager.LoadScene(1);
  }
  private void Start() {
    
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"HIGHSCORE: {highScore}";
  }

}
