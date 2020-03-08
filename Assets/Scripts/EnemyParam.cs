using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam 
{
    float action_timer;
    int hp = 10;
    Renderer renderer;
    Renderer ren;
    bool is_damage = false;
    bool is_color_recovery = false;

    GameObject obj;
    public GameObject Obj { get { return obj; } set { obj = value; } }
    public Renderer Renderer { get { return renderer; } set { renderer = value; } }
    public bool IsDamage { get { return is_damage; } set { is_damage = value; } }
    public bool IsColorRecovery { get { return is_color_recovery; } set { is_color_recovery = value; } }

    public enum Status
    {
        In,
        Out
    }

    public enum Level
    {
        Mob,
        Boss,
        LastBoss,
    }

    Status status = Status.In;
    Level level = Level.Mob;

    public Level LevelStatus { get { return level; } set { level = value; } }
    public Status ActionStatus { get { return status; } set { status = value; } }
    public float ActionTimer { get { return action_timer; } set { action_timer = value; } }
    public int HP { get { return hp; } set { hp = value; } }
}
