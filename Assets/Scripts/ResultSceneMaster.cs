using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneMaster : MonoBehaviour
{

    void Start()
    {
        var load_score = new LoadScore();
        var score = load_score.Load();
        var text_obj = GameObject.Find("Score").GetComponent<Text>();
        text_obj.text = "今回のスコア:" + score.score.ToString();
        score = load_score.Load(true);
        text_obj = GameObject.Find("BestScore").GetComponent<Text>();
        text_obj.text = "ベストスコア:" + score.score.ToString();
    }
}
