using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText
{
    Text text_obj;
    int score;
    public Text TextObj { get { return text_obj; } set { text_obj = value; } }
    public int Score { get { return score; } set { score = value; text_obj.text = "スコア:" + score.ToString(); } }
}
