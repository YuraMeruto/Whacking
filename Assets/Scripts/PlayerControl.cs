using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!StaticDatas.Instance.IsGamePlay)
            {
                return;
            }
            var pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var distance = Mathf.Infinity;
            if(Physics.Raycast(pos, out hit,distance))
            {
                Debug.Log(hit.collider.name);
                HitCollider(hit.collider.gameObject);
            }
        }
    }

    void HitCollider(GameObject obj)
    {
        if (obj.tag == "Enemy")
        {
            StaticDatas.Instance.EnemyManager.PlayerAttack(obj);
        }
        
    }
}
