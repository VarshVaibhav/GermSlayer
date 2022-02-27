using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLevel1 : MonoBehaviour
{
    public static ScoreLevel1 Instance { set; get; }
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        highscore = PlayerPrefs.GetInt("ScoreLevel1");
        highscoreText.text = "BEST:" + highscore.ToString();
    }
    public void IncrementScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "BEST:" + highscore.ToString();
            PlayerPrefs.SetInt("ScoreLevel1", highscore);
        }
    }
}
