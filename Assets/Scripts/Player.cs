using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float slidespeed = 100.0f;

    GameObject hp;
    GameObject ui;
   
    public HPbar script;
    public UIManager uiscript;
    
    //public float healthHP;
    public float playerHp;

    public Text gameover;
    public Text Restart;
    public float damage;

    public Text result;

    string sceneName;

    //bool gameOverselect=false;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("HPbar");
        script = hp.GetComponent<HPbar>();
        ui = GameObject.Find("Canvas");
        uiscript = ui.GetComponent<UIManager>();

        sceneName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {

        playerHp = script.currentHP;


        //ëOÇ…êiÇﬁ
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        //transform.position +=new Vector3(0,0,0)*Time.deltaTime;

        //åªç›ÇÃXé≤éÊìæ
        float pos_x = transform.position.x;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (pos_x < 9.0f)
            {
                transform.position += new Vector3(slidespeed, 0, 0) * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(pos_x>-9.0f)
            {
                transform.position -= new Vector3(slidespeed, 0, 0) * Time.deltaTime;
            }
        }
        
        if(result.gameObject==true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "health")
        {
            script.heal();
            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            gameover.gameObject.SetActive(true);
            result.text ="Score"+ uiscript.scorecounter.ToString("f1") + "M";
            result.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);



            //gameOverselect = true;
            gameOver();
            uiscript.score = false;
            script.damageselect = false;
            

            
            //Time.timeScale = 0;
            
            script.stopdamage();
            if(Input.GetKeyDown("space"))
            {
                changeScene();
            }
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Result");
    }

    public void gameOver()
    {
        script.damage = 0;
        speed = 0;
        slidespeed = 0.0f;
        uiscript.scorecounter += 0.0f;
    }



}
