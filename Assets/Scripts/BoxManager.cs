using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager
{
    List<BoxObject> box_list = new List<BoxObject>();
    public List<BoxObject> BoxList { get { return box_list; } set { box_list = value; } }
    public void Ini()
    {
        var pos = Vector3.zero;
        for (var length = 0; length < 3; length++)
        {
            for (var side = 0; side < 3; side++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var box = new BoxObject();
                cube.transform.position = pos;
                box.Obj = cube;
                BoxList.Add(box);
                pos.x += 3;
            }
            pos.x = 0;
            pos.z+= 3;
        }
    }

    public void EnemyDestory(GameObject obj)
    {
        foreach(var box in box_list)
        {
            if (box.Enemy != null)
            {
                if (obj.GetInstanceID() == box.Enemy.InstanceId)
                {
                    box.Enemy = null;
                    box.IsEnemyInstance = true;
                    break;
                }
            }
        }
    }
}
