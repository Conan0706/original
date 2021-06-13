using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2 : MonoBehaviour
{

    public float speed = 10.0f;
    public Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * -3.0f + targetpos.x, targetpos.y, targetpos.z);
    }
}
