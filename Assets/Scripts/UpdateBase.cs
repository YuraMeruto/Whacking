using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UpdateBase
{
    GameObject game_object;
    int instance_id;
    protected GameObject Object { get { return game_object; } set { game_object = value; } }
    public int InstanceId { get { return instance_id; } set { instance_id = value; } }
    public abstract void Update();

}
