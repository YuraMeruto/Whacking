using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    Renderer ren;
    [SerializeField]
    bool is_damage = true;
    [SerializeField]
    bool is_color_recovery = false;
    // Start is called before the first frame update
    void Start()
    {
        ren = obj.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_damage = true;
            is_color_recovery = false;

        }
        if (!is_damage)
        {
            return;
        }
        var color = ren.material.color;
        if (!is_color_recovery)
        {
            color.r -= Time.deltaTime * 2;
            if(color.r <= 0.0f)
            {
                is_color_recovery = true;
            }
        }
        else
        {
            color.r += Time.deltaTime * 2;
            if(color.r >= 1.0f)
            {
                is_damage = false;
            }
        }
        ren.material.color = color;

    }
}
