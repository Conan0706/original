using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float slidespeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�O�ɐi��
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        //���݂�X���擾
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
