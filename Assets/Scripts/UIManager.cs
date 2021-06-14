using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoretext;
    public float scorecounter=0.0f;
   

    GameObject player;
    public Player script;

    public bool score = true;

    public static float  best;
    public float nowscore=0.0f;
    public Text Bestscore;

    public Text StartScene;
    //Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<Player>();
        best=PlayerPrefs.GetFloat("SCORE");

    }

    // Update is called once per frame
    void Update()
    {
        if(score==true)
        { 
        
            if(script.nowspeedup==true)
            {
                scorecounter += Time.deltaTime * 2.0f;
            }
            //スコア表示
            scorecounter += Time.deltaTime * 1.5f;
            //scorecounter += 0;
            scoretext.text = scorecounter.ToString("f1") +  " " + "M";
            
           
        }

        else if(score==false)
        {
            StartScene.gameObject.SetActive(true);

            scorecounter += 0.0f;
            if(Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Start");
                
            }
           
        }
      
       

        
    }

    public void Best()
    {
        if (best < scorecounter)
        {
            
            best = scorecounter;
            Debug.Log(best);
            Bestscore.text = "BestScore" + best.ToString("f1") + "M";
            Bestscore.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("SCORE", best);
            PlayerPrefs.Save();
        }

        else
        {
            Bestscore.text = "BestScore" + best.ToString("f1") + "M";
            Bestscore.gameObject.SetActive(true);

        }
    }

   
}
