using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{   
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private PowerupSpawner powerupSpawner;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TMP_Text beatHighScoreText;
    [SerializeField] private TMP_Text highScoreText;
    private float timer=0;
    private bool didShow = false;
    public void endGame(){
        asteroidSpawner.enabled = false;
        powerupSpawner.enabled = false;
        int finalScore= scoreSystem.stopMultiply();
        gameOverText.text= $"Your Score: {finalScore}";
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        if(finalScore>highScore){
          beatHighScoreText.gameObject.SetActive(true);
          highScore = finalScore;
          PlayerPrefs.SetInt(ScoreSystem.HighScoreKey, highScore);
        }
        gameOverDisplay.gameObject.SetActive(true);
        playAgainButton.interactable = false;
        mainMenuButton.interactable = false;
        highScoreText.text = $"HIGHSCORE: {highScore}";
        didShow = false;
    }
    public void playAgain(){
      SceneManager.LoadScene(1);
      beatHighScoreText.gameObject.SetActive(false);
  }
    public void mainMenu(){
      SceneManager.LoadScene(0);
      beatHighScoreText.gameObject.SetActive(false);
  }
  private void Update() {
    if(!didShow){
      timer+=Time.deltaTime;
      if(timer >5){
        playAgainButton.interactable = true;
        mainMenuButton.interactable = true;
        timer = 0;
        didShow = true;
      }
    }
  }
}
