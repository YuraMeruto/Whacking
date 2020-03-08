using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using APIParams;
public class RegistScoreButton : MonoBehaviour
{
    [SerializeField]
    Text input_name_text;

    public void Regist()
    {
        if(StaticDatas.Instance.PlayFabAPI.IsExeNow)
        {
            return;
        }
        var load = new LoadScore();
        var score = load.Load();
        var save = new SaveScore();
        save.SaveName(input_name_text.text);
        StaticDatas.Instance.PlayFabAPI.SetUserName(input_name_text.text,score.score);
    }
}
