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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<Player>();
        
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
        //スコア表示
        //scorecounter += Time.deltaTime * 1.5f;
        //scorecounter += 0;
        //scoretext.text = scorecounter.ToString("f1") + "M";
        

        //scorecounter += Time.deltaTime*1.5f;
        //scoretext.text = scorecounter.ToString("f1") + "M";
    }

   
}
