using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
         if (other.gameObject.tag == "obstacle")
            {
                Debug.Log("Safe");
                Destroy(other.gameObject);
            }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="obstacle")
        {
            Destroy(other.gameObject);
        }
    }



}
