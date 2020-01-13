using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanceTimer : UpdateBase
{
    float timer = 3;
    public override void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            timer = 10.0f;
            Action();
        }
    }

    void Action()
    {
        var box_list = StaticDatas.Instance.BoxManager.BoxList;
        foreach(var box in box_list)
        {
            Debug.Log(box);
            if(box.IsEnemyInstance == false)
            {
               var obj = GameObject.CreatePrimitive( PrimitiveType.Capsule);
                obj.transform.position = box.Obj.transform.position;
                box.Enemy.EnemyParam.Obj = obj;
                box.IsEnemyInstance = true;
                box.Enemy.Ini();
            }
        }
    }

}
