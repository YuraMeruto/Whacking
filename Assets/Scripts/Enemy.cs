using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UpdateBase
{
    EnemyAction action = new EnemyAction();
    EnemyParam param = new EnemyParam();
    public EnemyAction EnemyAction{ get { return action; }}
    public EnemyParam EnemyParam { get { return param; } }

    public void Ini(EnemyParam.Level level = EnemyParam.Level.Mob)
    {
        action.Ini(param,level);
        StaticDatas.Instance.EnemyManager.EnemyList.Add(this);
        StaticDatas.Instance.UpdateManager.Add(this,param.Obj);
    }

    public override void Update()
    {
        action.Update(param);
    }
}
