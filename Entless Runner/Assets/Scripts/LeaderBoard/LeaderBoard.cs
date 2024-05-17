using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard Instance { get; private set; }

    public string publicKey = "4173f0390691e96797cf5882e2251460410e24791ad3bcd15489dd506c6ffaac";
  /*  public GameObject leaderBoardPLayerPrefab;
    public Transform content;*/

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetLeaderBoardEntries( GameObject leaderBoardPLayerPrefab, Transform content)
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            for (int i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            int loopLength = (msg.Length < 10) ? msg.Length : 10;
            for (int i = 0; i < loopLength; i++)
            {
                GameObject player = Instantiate(leaderBoardPLayerPrefab, content);
                LeaderBoardPlayer l = player.GetComponent<LeaderBoardPlayer>();
                l.playerName.text = msg[i].Username;
                l.playerScore.text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry(int score)
    {
        string username = PlayerPrefs.GetString("UserName");
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) =>
        {
            //GetLeaderBoardEntries();
        }));
    }
}