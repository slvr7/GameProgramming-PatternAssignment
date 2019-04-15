using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceSpace;
using UnityEngine.UI;

public class ScoreManager : Service
{
    public Text scoretext;
    private float currentScore;

    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void GetScore(float value)
    {
        currentScore += value;
    }

    public void initialize()
    {
        currentScore = 0;
        SetServiceStatus(Status.GameStart);
    }

    public void clearScore()
    {
        currentScore = 0;
        SetServiceStatus(Status.GameOver);
    }

    public void displayScore()
    {
        scoretext.text = "Score :  " + currentScore;
    }

    internal override void Update()
    {
        displayScore();
        SetServiceStatus(Status.GamePlaying);
    }
}
