using UnityEngine;


public class LoadScore 
{
    public Score Load()
    {
        var score = new Score();
        score.name = PlayerPrefs.GetString(GameKeyValue.PLAYER_NAME);
        score.score = PlayerPrefs.GetInt(GameKeyValue.PLAYER_SCORE);
        return score;
    }
}
