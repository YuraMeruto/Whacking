using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    List<Enemy> enemy_list = new List<Enemy>();
    public List<Enemy> EnemyList { get { return enemy_list; } set { enemy_list = value; } }
}
