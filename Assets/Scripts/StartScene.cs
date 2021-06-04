using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public Text Best;
    public float bestscore;
    GameObject start;
    public UIManager script;
    // Start is called before the first frame update
    void Start()
    {
         start= GameObject.Find("Canvas");
         script = start.GetComponent<UIManager>();
        bestscore = PlayerPrefs.GetFloat("SCORE");
        Best.text = "BestScore" + bestscore.ToString("f2")+"M";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Main");
        }
    }

   
}
