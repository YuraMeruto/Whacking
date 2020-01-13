using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UpdateBase
{
    GameObject game_object;
    protected GameObject Object { get { return game_object; } set { game_object = value; } }
    public abstract void Update();
}
