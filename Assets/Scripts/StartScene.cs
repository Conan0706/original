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
 

    private bool walk;
    // Start is called before the first frame update
    void Start()
    {
         start= GameObject.Find("Canvas");
         script = start.GetComponent<UIManager>();
        bestscore = PlayerPrefs.GetFloat("SCORE");
        Best.text = "BestScore" + bestscore.ToString("f2")+"M";
        
        walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            walk = true;
            Invoke("change", 2.0f);
        }
        if(walk==true)
        {
            transform.position += new Vector3(0, 0, 5) * Time.deltaTime;
        }
    }

    private void change()
    {
        SceneManager.LoadScene("Main");
    }


}
