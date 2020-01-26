using UnityEngine;
using UnityEngine.UI;
public class ScoreRankingMaster : MonoBehaviour
{
    void Start()
    {
        LoadScore();
        LoadRankingList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LoadScore()
    {
        var load = new LoadScore();
        var score = load.Load();
        var obj = GameObject.Find("PlayerScore");
        var text = obj.GetComponent<Text>();
        text.text = score.score.ToString();
        obj = GameObject.Find("PlayerName");
        text = obj.GetComponent<Text>();
        text.text = score.name;
    }

    void LoadRankingList()
    {
        var ranking_list_obj = GameObject.Find("RankingList");
        var  rank = 0;
        var obj = Resources.Load<GameObject>(ResourcesObject.SCORE_UI);
        var list = new GetRankingListParam();
        for (var index = 0;index <= 10; index++)
        {
            var score = new Score();
            score.name = "Hoge";
            score.score = 10;
            list.ranking_list.Add(score);
        }
        foreach(var ranking in list.ranking_list)
        {
            var instance = MonoBehaviour.Instantiate(obj);
            instance.transform.parent = ranking_list_obj.transform;
            var children = instance.GetComponentsInChildren<Text>();
            children[0].text = rank.ToString();
            rank++;
            children[1].text = ranking.name;
            children[2].text = ranking.score.ToString();
        }
    }
}
