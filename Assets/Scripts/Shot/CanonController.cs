using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public float speed = 5.0f; //プレイヤーの移動速度

    float vx = 0;
    float vy = 0;

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;
        if(Input.GetKey("w")) 
        {
            vy = speed;
        }
        else if(Input.GetKey("a")) 
        {
            vx = -speed;
        }
        else if(Input.GetKey("s")) 
        {
            vy = -speed;
        }
        else if(Input.GetKey("d")) 
        {
            vx = speed;
        }
    }

    void FixedUpdate()
    {
        this.transform.Translate(vx/50, vy/50, 0);
    }
}
