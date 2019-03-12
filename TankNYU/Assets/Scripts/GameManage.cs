using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    static public GameManage gm;
    public GameObject Player;
    public GameObject MainCamera;

    public bool IsPlayerDead;
    private TankHealth playerTankHealth;

    public GameObject PlayingUI;
    public GameObject GameOverUI;
    public GameObject GameStartUI;

    public Text scoreText;
    private float currentScore;

    public Text timeText;
    public float currentTime;
    private float startTime;

    public float MaxHealth;
    public float CurrentHealth;
    public Text healthText;


    public enum GameState
    {
        GamePlaying,
        GameOver
    };
    public GameState currentGameState;

    public class Event
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
            gm = GetComponent<GameManage>();

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (MainCamera == null)
        {
            MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        gm.currentGameState = GameState.GamePlaying;
        IsPlayerDead = false;
        currentScore = 0;
        startTime = Time.time;
        playerTankHealth = Player.GetComponent<TankHealth>();

        ShowPlayingUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerDead)
        {
            ShowGameOverUI();
            gm.currentGameState = GameState.GameOver;
        }

        if(!IsPlayerDead)
        {
            Debug.Log("hi");
            scoreText.text = "Score :  " + currentScore;
            currentTime = Time.time - startTime;
            timeText.text = "Time :  " + currentTime.ToString("0.00");
        }
    }

    public void AddScore(float score)
    {
        currentScore += score;
    }

    public void ShowPlayingUI()
    {
        PlayingUI.SetActive(true);
        GameOverUI.SetActive(false);
        GameStartUI.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        PlayingUI.SetActive(false);
        GameOverUI.SetActive(true);
        GameStartUI.SetActive(false);
    }

    public void ShowGameStartUI()
    {
        PlayingUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameStartUI.SetActive(true);
    }
}
