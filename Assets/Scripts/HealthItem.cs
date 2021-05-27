using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    GameObject hp;
    public HPbar script;

    public float healthHP;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("HPbar");
        script = hp.GetComponent<HPbar>();
        //float healthHP = script.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        float healthHP = script.currentHP;
        Debug.Log(healthHP);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            healthHP += 15.0f;
            
        }
        
    }

}
