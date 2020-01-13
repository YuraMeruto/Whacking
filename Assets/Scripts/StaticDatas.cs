using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDatas : MonoBehaviour
{
    static StaticDatas instance = new StaticDatas();
    public static StaticDatas Instance { get { return instance; }}
    UpdateManager update_manager = new UpdateManager();
    BoxManager box_manager = new BoxManager();
    TimeManager time_manger = new TimeManager();
    EnemyManager enemy_manager = new EnemyManager();
    public TimeManager TimeManger { get { return time_manger; } }
    public UpdateManager UpdateManager { get { return update_manager; } }
    public BoxManager BoxManager { get { return box_manager; } }
    public EnemyManager EnemyManager { get { return enemy_manager; } }
    public void Ini()
    {
        update_manager = new GameObject().AddComponent<UpdateManager>();
        box_manager.Ini();
        time_manger.Ini();
    }
}
