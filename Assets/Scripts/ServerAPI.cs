using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using APIParams;
public class ServerAPI : MonoBehaviour
{
    MonoBehaviour mono;
    static ServerAPI instance;
    HTTPRequest requester;
    public ServerAPI (MonoBehaviour _mono)
        {
        mono = _mono;
        }

    public static ServerAPI Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = new GameObject();
                instance = obj.AddComponent<ServerAPI>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    void Awake()
    {
        requester = new HTTPRequest(this);
        DontDestroyOnLoad(this);
    }

    public void RegistScore(RegistScore param)
    {
        Dictionary<string, string> request = new Dictionary<string, string>();
        request.Add(ConstValues.NAME_KEY, param.name);
        request.Add(ConstValues.SCORE_KEY, param.score.ToString());
        var url = ConstValues.SERVER_URL + ConstValues.REGIST_SCORE_URL;
        StartCoroutine(requester.PostRequest(request,url));
    }

    public void GetScoreList(GetScoreList param)
    {
        Dictionary<string, string> request = new Dictionary<string, string>();
        request.Add(ConstValues.NAME_KEY, param.name);
        var url = ConstValues.SERVER_URL + ConstValues.GET_SCORE_LIST_URL;
        StartCoroutine(requester.PostRequest(request, url));
    }
}
