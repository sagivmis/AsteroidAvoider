using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public const string HighScoreKey = "HighScore";
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private GameObject player;
    private float score;
    private bool shouldCount = true;
    

    void Update()
    {
        if(!shouldCount){return;}
        score+=Time.deltaTime*scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    
    }

    private void OnDestroy() {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score>currentHighScore){
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
    public int stopMultiply(){
        shouldCount = false;
        scoreText.text=string.Empty;

        return Mathf.FloorToInt(score);
    }
    public int getScore(){
        return Mathf.FloorToInt(score);
    }
}
