using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    ScoreText scote_text = new ScoreText();
    GameTimer game_timer = new GameTimer();
    GameObject canvas_obj;
    MessageUI message_ui = new MessageUI();

    public MessageUI MessageUI { get { return message_ui; } }
    public GameObject CanvasObj { get { return canvas_obj; } set { canvas_obj = value; } }
    public GameTimer GameTimer { get { return game_timer; } set { game_timer = value; } }
    public ScoreText ScoreText { get { return scote_text; } set { scote_text = value; } }


    public void Ini()
    {
        canvas_obj = GameObject.Find("Canvas");
        ScoreTextIni();
        StartCountIni();
    }



    void ScoreTextIni()
    {
        var text = SearchCanvasChildObject("Score");
        scote_text.TextObj =  text.GetComponent<Text>();
        scote_text.Score = 0;
        var t = scote_text.TextObj.GetComponent<Text>();
        t.text = scote_text.Score.ToString();
    }

    public void GameTimerIni()
    {
        var text = SearchCanvasChildObject("GameTimer").GetComponent<Text>();
        game_timer.TextObj = text;
        game_timer.TimeValue = ConstValues.GAME_TIMER;
        text.text = game_timer.TimeValue.ToString();
        StaticDatas.Instance.UpdateManager.Add(game_timer,text.gameObject);
    }

    void StartCountIni()
    {
        StartCount count = new StartCount();
        count.Ini();
        StaticDatas.Instance.UpdateManager.Add(count, count.TextObj.gameObject);
    }


    public GameObject SearchCanvasChildObject(string name)
    {
        var children = canvas_obj.GetComponentInChildren<Transform>();
        foreach (Transform child in children)
        {
           if(child.name == name)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
