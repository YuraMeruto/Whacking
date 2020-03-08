using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    List<Enemy> enemy_list = new List<Enemy>();
    public List<Enemy> EnemyList { get { return enemy_list; } set { enemy_list = value; } }

    public void Destroy(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        var effect = MonoBehaviour.Instantiate(StaticDatas.Instance.EffectObject);
        effect.transform.position = pos;
        MonoBehaviour.Destroy(effect,3.0f);
        StaticDatas.Instance.BoxManager.EnemyDestory(obj);
        StaticDatas.Instance.UpdateManager.Destory(obj);
        EnemyDestory(obj);
    }

    void EnemyDestory(GameObject obj)
    {
        foreach(var enemy in enemy_list)
        {
            if(enemy.InstanceId == obj.GetInstanceID())
            {
                enemy_list.Remove(enemy);
                break;
            }
        }
    }

    public void PlayerAttack(GameObject obj)
    {
        foreach (var enemy in enemy_list)
        {
            if (enemy.InstanceId == obj.GetInstanceID())
            {
                if (enemy.EnemyParam.ActionStatus == EnemyParam.Status.In)
                {
                    break;
                }
                enemy.EnemyParam.HP--;
                Debug.Log(enemy.EnemyParam.IsDamage);
                enemy.EnemyParam.IsDamage = true;
                if (enemy.EnemyParam.HP <= 0)
                {
                    StaticDatas.Instance.SeManager.PlaySe( SEManager.Status.EnemyDestory);
                    UpdateScore(enemy.EnemyParam);
                    Destroy(obj);
                }
                else
                {
                    StaticDatas.Instance.SeManager.PlaySe(SEManager.Status.EnemyDamage);
                }
                break;
            }
        }
    }

    void UpdateScore(EnemyParam param)
    {
        switch(param.LevelStatus)
        {
            case EnemyParam.Level.Mob:
                StaticDatas.Instance.UIManger.ScoreText.Score += 1;
                break;
            case EnemyParam.Level.Boss:
                StaticDatas.Instance.UIManger.ScoreText.Score += 10;
                break;
            case EnemyParam.Level.LastBoss:
                StaticDatas.Instance.UIManger.ScoreText.Score += 100;
                break;
        }
    }

}
