using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : UpdateBase
{
    Text message_text;
    float show_timer = 0.0f;
    bool is_update = true;
   public enum ActionStatus{
        None,
        ResultScene,
    }
    ActionStatus status;
    public Text MessageText { get { return message_text; } set { message_text = value; } }

    public void Show(string message, float show_time = 1.0f ,ActionStatus action = ActionStatus.None)
    {
        if(message_text == null)
        {
            var text_obj = StaticDatas.Instance.UIManger.SearchCanvasChildObject("Message");
            message_text = text_obj.GetComponent<Text>();
            StaticDatas.Instance.UpdateManager.Add(this,message_text.gameObject);
        }
        status = action;
        message_text.text = message;
        show_timer = show_time;
        is_update = true;
    }

    public override void Update()
    {
        if(!is_update)
        {
            return;
        }
        show_timer -= Time.deltaTime;

        if (show_timer <= 0.0f)
        {
            message_text.text = "";
            is_update = false;
            Action();
        }
    }

    void Action()
    {
        switch(status)
        {
            case ActionStatus.ResultScene:
                LoadScenes.Instance.LoadScene(SceneNames.RESULT);
                break;
        }
    }
}
