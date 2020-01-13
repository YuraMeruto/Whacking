using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam 
{
    float action_timer;
    int hp;
    GameObject obj;
    public GameObject Obj { get { return obj; } set { obj = value; } }

    public float ActionTimer { get { return action_timer; } set { action_timer = value; } }
    public int HP { get { return hp; } set { hp = value; } }
}
