using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerDetails : MonoBehaviour
{
    public string PlayerName;
    public TMP_InputField PLayerName_input;
    public GameObject usernamrPannel;
    public TextMeshProUGUI lobbyPannelUserName;
    public TextMeshProUGUI lobyPannelHighScore;
    public GameObject leaderBoardPannel;

      public GameObject leaderBoardPLayerPrefab;
  public Transform content;

    void Start()
    {

        if (PlayerPrefs.GetString("UserName").Length <=0)
        {
            usernamrPannel.SetActive(true);
        }
        else
        {
            PlayerName = PlayerPrefs.GetString("UserName");
            lobbyPannelUserName.text = PlayerName;
            usernamrPannel.SetActive(false);
            lobyPannelHighScore.text = PlayerPrefs.GetInt("bestScore").ToString();
            LeaderBoard.Instance.GetLeaderBoardEntries(leaderBoardPLayerPrefab, content);
        }
    }
public    void SubmitUserName()
    {
        PlayerName = PLayerName_input.text;
        PlayerPrefs.SetString("UserName", PlayerName);
        usernamrPannel.SetActive(false);
        lobbyPannelUserName.text = PlayerName;

        lobyPannelHighScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        LeaderBoard.Instance.GetLeaderBoardEntries(leaderBoardPLayerPrefab,content);
        Debug.Log(PlayerName);
    }
    public   void OpenLeaderBord()
    {
        leaderBoardPannel.SetActive(true);
    }
    public void CloseLeaderBord()
    {
        leaderBoardPannel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
