using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoretext;
    public float scorecounter=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scorecounter += Time.deltaTime*1.5f;
        scoretext.text = scorecounter.ToString("f1") + "M";
    }

   
}
