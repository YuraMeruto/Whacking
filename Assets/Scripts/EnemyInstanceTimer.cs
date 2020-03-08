using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanceTimer : UpdateBase
{
    float timer = 0.0f;
    bool is_lastboss_instance = true;

    public void Ini()
    {
        is_lastboss_instance = true;
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            timer = 3.0f;
            Action();
        }
    }

    void Action()
    {
        var box_list = StaticDatas.Instance.BoxManager.BoxList;
        foreach(var box in box_list)
        {
            if (box.IsEnemyInstance == true)
            {
                if (StaticDatas.Instance.RandomEnemyList.Count == 0)
                {
                    for (var index = 0; index <= 10; index++)
                    {
                        var rand_value = Random.Range(1,5);
                        StaticDatas.Instance.RandomEnemyList.Add(rand_value);
                    }
                }
                var list_index = StaticDatas.Instance.RandomEnemyList[0];
                //@Todo ボスキャラの生成処理
                if (is_lastboss_instance && StaticDatas.Instance.UIManger.GameTimer.TimeValue <= ConstValues.GAME_TIMER / 2)
                {
                    Instance(Resources.Load<GameObject>(ResourcesObject.LAST_BOSS), box, EnemyParam.Level.LastBoss);
                    is_lastboss_instance = false;
                    StaticDatas.Instance.RandomEnemyList.RemoveAt(0);
                    return;
                }
                switch (list_index)
                {
                    case 1:
                        Instance(Resources.Load<GameObject>(ResourcesObject.BOSS_OBJECT), box,EnemyParam.Level.Boss);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Instance(Resources.Load<GameObject>(ResourcesObject.MOB_OBJECT), box);
                        break;
                }
                StaticDatas.Instance.RandomEnemyList.RemoveAt(0);
            }
        }
    }

    void Instance(GameObject obj,BoxObject box,EnemyParam.Level level = EnemyParam.Level.Mob)
    {
        var instance = MonoBehaviour.Instantiate(obj);
        instance.transform.position = box.Obj.transform.position;
        var enemy = new Enemy();
        box.Enemy = enemy;
        box.Enemy.EnemyParam.Obj = instance;
        box.Enemy.EnemyParam.Renderer = instance.GetComponent<Renderer>();
        instance.tag = "Enemy";
        if(level == EnemyParam.Level.LastBoss)
        {
            instance.name = "last_boss";
        }
        box.IsEnemyInstance = false;
        box.Enemy.Ini(level);

    }
}
