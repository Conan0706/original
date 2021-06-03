using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoretext;
    public float scorecounter=0.0f;
   

    GameObject player;
    public Player script;

    public bool score = true;

    public float best;
    public float nowscore=0.0f;
    public Text Bestscore;
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
            //スコア表示
            scorecounter += Time.deltaTime * 1.5f;
            //scorecounter += 0;
            scoretext.text = scorecounter.ToString("f1") + "M";
            
           
        }
        else if(score==false)
        {
            
            scorecounter += 0.0f;
           
        }
      
       

        
    }

    public void Best()
    {
        if (best < scorecounter)
        {
            Debug.Log("AAA");
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
