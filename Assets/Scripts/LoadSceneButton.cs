using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    enum SceneStatus
    {
        None,
        Title,
        Game,
        ScoreRanking
    }
    [SerializeField]
    SceneStatus scene_status;

    public void LoadScene()
    {
        LoadScenes.Instance.LoadScene(SceneNames.DIRECTORY + scene_status.ToString());
    }
}
