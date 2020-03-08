using UnityEngine.UI;
using UnityEngine;

public class StartCount : UpdateBase
{
    float timer;
    Text text_obj;

    public float Timer { get { return timer; } }
    public Text TextObj { get { return text_obj; } set { text_obj = value; } }

    public void Ini()
    {
        timer = 3.0f;
        var obj = GameObject.Find(ConstValues.START_COUNT);
        text_obj = obj.GetComponent<Text>();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        text_obj.text = timer.ToString("F0");
        if(timer <= 0.0f)
        {
            Destroy();
        }
    }

    void Destroy()
    {

        StaticDatas.Instance.UpdateManager.Destory(text_obj.gameObject);
        StaticDatas.Instance.UIManger.GameTimerIni();
        StaticDatas.Instance.TimeManger.Ini();
        StaticDatas.Instance.UIManger.MessageUI.Show(ConstMessage.START_MESSAGE,2.0f);
    }
}
