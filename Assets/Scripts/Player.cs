using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float slidespeed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //前に進む
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        //現在のX軸取得
        float pos_x = transform.position.x;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (pos_x < 9.0f)
            {
                transform.position += new Vector3(slidespeed, 0, 0) * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(pos_x>-9.0f)
            {
                transform.position -= new Vector3(slidespeed, 0, 0) * Time.deltaTime;
            }
        }
        
    }
}
