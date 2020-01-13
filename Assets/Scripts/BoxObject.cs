using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject
{
    GameObject obj;
    Enemy enemy = new Enemy();
    bool is_enemy_instance = false;

    public bool IsEnemyInstance { get { return is_enemy_instance; } set { is_enemy_instance = value; } }
    public Enemy Enemy { get { return enemy; } set { enemy = value; } }
    public GameObject Obj { get { return obj; } set { obj = value; } }
}
