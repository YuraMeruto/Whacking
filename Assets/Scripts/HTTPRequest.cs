using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using APIParams;
public class HTTPRequest 
{
    MonoBehaviour mono;
    static HTTPRequest instance;
    public HTTPRequest (MonoBehaviour _mono)
    {
        mono = _mono;
    }

    public IEnumerator PostRequest(Dictionary<string, string> datas,string url)
    {
        WWWForm form = new WWWForm();

        foreach (var data in datas)
        {
            form.AddField(data.Key, data.Value);
        }

        var request = UnityWebRequest.Post(url, form);
        if (request.downloadHandler == null)
        {
            request.downloadHandler = new DownloadHandlerBuffer();
        }
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            PostResponse(request.downloadHandler.text);
        }
    }

    public IEnumerator PostResponse(string data)
    {

        var json = JsonUtility.FromJson<ResponseGetScoreList>(data);
        yield return null;
    }
}
