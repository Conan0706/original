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

    public int rescount=0;
    public Text restext;

    public float skillcount;

    public float nowskill;
    public Text Skill;
    public Text Skill2;
    public bool skill2 = false;
        

    //bool gameOverselect=false;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("HPbar");
        script = hp.GetComponent<HPbar>();
        ui = GameObject.Find("Canvas");
        uiscript = ui.GetComponent<UIManager>();

        sceneName = SceneManager.GetActiveScene().name;
        Skill.gameObject.SetActive(false);
        Skill2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        playerHp = script.currentHP;


        //前に進む
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        //transform.position +=new Vector3(0,0,0)*Time.deltaTime;

        //現在のX軸取得
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
        skillcount += Time.deltaTime;
        skill();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "health")
        {
            script.heal();
            
        }

        if(other.gameObject.tag=="respawn")
        {
            rescount += 1;
            restext.text = "☆:" + rescount.ToString("f1");
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            if(skill2==true)
            {
                Destroy(collision.gameObject);
                Invoke("stopSkill2", 5.0f);
            }

            else if(rescount>=5)
            {
                rescount -= 5;
                Destroy(collision.gameObject);
                restext.text = "☆:" + rescount.ToString("f1");
            }
            else
            {
                gameover.gameObject.SetActive(true);
                result.text = "Score" + uiscript.scorecounter.ToString("f1") + "M";
                result.gameObject.SetActive(true);
                Restart.gameObject.SetActive(true);
                gameOver();
                uiscript.score = false;
                script.damageselect = false;
            }
            /*gameover.gameObject.SetActive(true);
            result.text ="Score"+ uiscript.scorecounter.ToString("f1") + "M";
            result.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            */



            //gameOverselect = true;
            /*gameOver();
            uiscript.score = false;
            script.damageselect = false;
            */

            
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

    public void skill()
    {
        if(skillcount>=10 && skillcount<20)
        {
            Skill.gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.Z))
            {
                Skill.gameObject.SetActive(false);
                nowskill += Time.deltaTime;
                speed += 5;
                Invoke("stopSkill", 5.0f);
                Debug.Log(speed);
                
                skillcount = 0.0f;
                Debug.Log(skillcount);
                //if(nowskill>=5.0f)
                //{
                    //speed = -5.0f;
                    
                //}
            }
           
        }
        else if (skillcount >=20)
        {
            Skill.gameObject.SetActive(false);
            Skill2.gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.Z))
            {
                skill2 = true;
                Skill2.gameObject.SetActive(false);
                skillcount = 0.0f;
            }
        }

    }

    

    public void stopSkill()
    {
        speed -= 5.0f;
    }
    public void stopSkill2()
    {
        skill2 = false;
    }
    //private void OnTriggerStay(Collider other)
    //{
        //this.gameObject.SetActive(false);
    //}





}
