using UnityEngine;


public class LoadScore 
{
    public Score Load(bool is_best_score = false)
    {
        var score = new Score();
        score.name = PlayerPrefs.GetString(GameKeyValue.PLAYER_NAME);
        if (is_best_score)
        {
            score.score = PlayerPrefs.GetInt(GameKeyValue.PLAYER_BEST_SCORE);
        }
        else
        {
            score.score = PlayerPrefs.GetInt(GameKeyValue.PLAYER_SCORE);
        }
        return score;
    }

}
