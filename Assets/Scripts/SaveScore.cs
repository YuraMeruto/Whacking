using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore
{
    public void Save(Score score)
    {
        Debug.Log(score);
        PlayerPrefs.SetString(GameKeyValue.PLAYER_NAME,score.name);
        PlayerPrefs.SetInt(GameKeyValue.PLAYER_SCORE,score.score);
        UpdateBestScore(score.score);
    }

    public void Save(int score)
    {
        UpdateBestScore(score);
        PlayerPrefs.SetInt(GameKeyValue.PLAYER_SCORE, score);
    }

    public void SaveName(string name)
    {
        PlayerPrefs.SetString(GameKeyValue.PLAYER_NAME,name);
    }

    void UpdateBestScore(int score)
    {
        var best_score = PlayerPrefs.GetInt(GameKeyValue.PLAYER_BEST_SCORE);
        if(score >= best_score)
        {
            PlayerPrefs.SetInt(GameKeyValue.PLAYER_BEST_SCORE,score);
        }
    }
}
