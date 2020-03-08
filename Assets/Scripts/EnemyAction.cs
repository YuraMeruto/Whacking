using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction 
{
    public void Ini(EnemyParam param,EnemyParam.Level level)
    {
        switch (level) {
            case EnemyParam.Level.Mob:
                param.LevelStatus = level;
                param.ActionTimer = Random.Range(1.0f, 3.0f);
                param.HP = 1;
                break;
            case EnemyParam.Level.Boss:
                param.LevelStatus = level;
                param.ActionTimer = Random.Range(3.0f, 5.0f);
                param.HP = 5;
                break;
            case EnemyParam.Level.LastBoss:
                param.LevelStatus = level;
                param.ActionTimer = 1;
                param.HP = 20;
                break;
        }
    }

    public void Update(EnemyParam param)
    {
        UpdateTime(param);
    }

    void UpdateTime(EnemyParam param)
    {
        param.ActionTimer -= Time.deltaTime;

        if (param.ActionTimer <= 0.0f)
        {
            if(param.ActionStatus == EnemyParam.Status.In)
            {
                OutAction(param);
            }
            else if (param.ActionStatus == EnemyParam.Status.Out)
            {
                InAction(param);
            }
        }

        if (!param.IsDamage)
        {
            return;
        }
        var color = param.Renderer.material.color;
        if (!param.IsColorRecovery)
        {
            color.r -= Time.deltaTime * 5;
            if (color.r <= 0.0f)
            {
                param.IsColorRecovery = true;
            }
        }
        else
        {
            color.r += Time.deltaTime * 5;
            if (color.r >= 1.0f)
            {
                param.IsDamage = false;
                param.IsColorRecovery = false;
            }
        }
        param.Renderer.material.color = color;
    }

    void OutAction(EnemyParam param)
    {
        if(param.LevelStatus == EnemyParam.Level.LastBoss)
        {
            param.ActionTimer = 10.0f;
        }
        else
        {
            param.ActionTimer = 1.0f;
        }
        var pos = param.Obj.transform.position;
        pos += Vector3.up;
        param.Obj.transform.position = pos;
        param.ActionStatus = EnemyParam.Status.Out;

    }

    void InAction(EnemyParam param)
    {
        if (param.LevelStatus == EnemyParam.Level.LastBoss)
        {
            LastBossAction(param);
            return;
        }
        param.ActionTimer = 1.0f;
        var pos = param.Obj.transform.position;
        pos += Vector3.down;
        param.Obj.transform.position = pos;
        param.ActionStatus = EnemyParam.Status.In;
    }

    void LastBossAction(EnemyParam param)
    {
        StaticDatas.Instance.EnemyManager.Destroy(param.Obj);
    }
}
