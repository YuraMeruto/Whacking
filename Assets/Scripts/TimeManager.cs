using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : UpdateBase
{
    EnemyInstanceTimer instance_timer = new EnemyInstanceTimer();

    public void Ini()
    {
        StaticDatas.Instance.UpdateManager.UpdateList.UpdateBases.Add(instance_timer);
    }

    public override void Update()
    {
    }
}
