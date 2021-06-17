using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sousa()
    {
        button.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        
        
    }

    public void cansel()
    {
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
}
