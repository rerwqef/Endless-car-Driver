using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted=false;
    public GameObject PlatformSpanner;
    public TextMeshProUGUI scoreText, dimondText, besttext;
    int score=0,bestScore=0;
    bool countScore=false;

    [Header("GameOver")]
    public GameObject GameOverPannel;
    public GameObject NewHighscoreim;
    public TextMeshProUGUI ScoretextInGameOver;
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        isGameStarted = false;
        scoreText.text = score.ToString();
        bestScore =  PlayerPrefs.GetInt("bestScore");

        besttext.text=bestScore.ToString();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameStart();
            }
        }
    }
    void GameStart()
    {
        isGameStarted=true;
        countScore=true;
        StartCoroutine(UpdateScore());
        PlatformSpanner.SetActive(true);
    }
    public void GameOver()
    {
        GameOverPannel.SetActive(true);
        ScoretextInGameOver.text = score.ToString();
        countScore = false;

        PlatformSpanner.SetActive(false);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
            LeaderBoard.Instance.SetLeaderBoardEntry(score);
            NewHighscoreim.SetActive(true);
        }
    }
    IEnumerator UpdateScore()
    {
        while (countScore)
        {
          
            score++;
            if (score > bestScore)
            {
                scoreText.text = score.ToString();
                besttext.text = score.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }


    public void Rewardads()
    {
        ADSManager.instance.rewardedADS.ShowAd();
    }
    public void tWICEthescORE()
    {
        
        score *= 2;
        if (score > bestScore)
        {
            scoreText.text = score.ToString();
            besttext.text = score.ToString();
            ScoretextInGameOver.text = score.ToString();
            PlayerPrefs.SetInt("bestScore", score);
            LeaderBoard.Instance.SetLeaderBoardEntry(score);
        }
        else
        {
            ScoretextInGameOver.text = score.ToString();
            scoreText.text = score.ToString();
        }

    
    }
}
