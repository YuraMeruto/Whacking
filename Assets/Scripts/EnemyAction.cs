using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction 
{
    public void Update(EnemyParam param)
    {
        Debug.Log("EnemyAction");
        UpdateTime(param);
    }

    void UpdateTime(EnemyParam param)
    {
        param.ActionTimer -= Time.deltaTime;
        if (param.ActionTimer <= 0.0f)
        {
            param.ActionTimer = 10.0f;
           var pos = param.Obj.transform.position;
            pos += Vector3.up;
            param.Obj.transform.position = pos;
        }
    }
}
