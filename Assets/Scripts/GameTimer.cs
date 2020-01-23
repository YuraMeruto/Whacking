using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : UpdateBase
{
    Text text_obj;
    float time_value;
    public Text TextObj { get { return text_obj; } set { text_obj = value; } }
    public float TimeValue { get { return time_value; } set { time_value = value; } }



    public override void Update()
    {
        if(!StaticDatas.Instance.IsGamePlay)
        {
            return;
        }
        time_value -= Time.deltaTime;
        text_obj.text = time_value.ToString();
        if(time_value <= 0.0f)
        {
            Finish();
        }
    }

    void Finish()
    {
        StaticDatas.Instance.IsGamePlay = false;
        time_value = 0.0f;
        text_obj.text = time_value.ToString();
    }
}
