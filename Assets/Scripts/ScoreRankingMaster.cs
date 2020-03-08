using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ScoreRankingMaster : MonoBehaviour
{
    void Start()
    {
        LoadScore();
        StaticDatas.Instance.PlayFabAPI.GetScoreRanking();
    }

    void LoadScore()
    {
        var load = new LoadScore();
        var score = load.Load();
        var obj = GameObject.Find(ConstObjectNames.PLAYER_SCORE);
        var text = obj.GetComponent<Text>();
        text.text = score.score.ToString();
        obj = GameObject.Find(ConstObjectNames.PLAYER_NAME);
        text = obj.GetComponent<Text>();
        text.text = score.name;
        StaticDatas.Instance.PlayFabAPI.UserName = score.name;
    }

}
