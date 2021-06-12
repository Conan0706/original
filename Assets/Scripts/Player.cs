using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float slidespeed = 100.0f;
    public float pos_x;

    GameObject hp;
    GameObject ui;
    GameObject par1;
    
   
    public HPbar script;
    public UIManager uiscript;
    public GameController gamescript;
    
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
    public Image Skill;
    
    public Image Skill2;
    public bool skill2 = false;

    public bool speedup = false;
    public float speedupcount;
    public int speedUPcount=0;
    public float objspeed=0.0f;

    public int test1;
    public int test2;

    private bool safezone=false;

    AudioSource audioSourse;
    public AudioClip heal;
    public AudioClip get;
    public AudioClip res;



    public Animator anim;
    GameObject anime;

    public bool nowgaming;

    public GameObject particle;
    public GameObject particle2;
    public GameObject particle3;
    

    private Vector3 particle_pos;

    public GameObject speedpar;
    public GameObject mutekipar;
    //bool gameOverselect=false;
    // Start is called before the first frame update
    void Start()
    {

        audioSourse = GetComponent<AudioSource>();
        hp = GameObject.Find("HPbar");
        script = hp.GetComponent<HPbar>();
        ui = GameObject.Find("Canvas");
        uiscript = ui.GetComponent<UIManager>();

        par1 = GameObject.Find("GaneManager");
        gamescript = par1.GetComponent<GameController>();


        sceneName = SceneManager.GetActiveScene().name;
        Skill.gameObject.SetActive(false);
        Skill2.gameObject.SetActive(false);

        StartCoroutine("Speedup");

        int test1 = LayerMask.NameToLayer("Player");
        int test2 = LayerMask.NameToLayer("Obstacle");

        
        anime = GameObject.Find("dreyar_m_aure");
        anim = anime.GetComponent<Animator>();

        nowgaming = true;

       

        //PlayerPrefs.GetFloat("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {

        playerHp = script.currentHP;


        //ëOÇ…êiÇﬁ
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        //transform.position +=new Vector3(0,0,0)*Time.deltaTime;

        //åªç›ÇÃXé≤éÊìæ
        pos_x = transform.position.x;

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
            Destroy(other.gameObject);
            
            audioSourse.PlayOneShot(heal);
            particle_pos = this.transform.position;
            particle_pos.z += 2;
            Instantiate(particle, particle_pos, Quaternion.identity);
            //Destroy(gamescript.particle);

        }

        if(other.gameObject.tag=="respawn")
        {
            rescount += 1;
            restext.text = "Åô:" + rescount.ToString("f1");
            particle_pos = transform.position;
            particle_pos.z += 2;
            Instantiate(particle2, particle_pos, Quaternion.identity);
            Destroy(other.gameObject);
            audioSourse.PlayOneShot(get);
            //Destroy(gamescript.particle2);
        }

        if(other.gameObject.tag=="obstacle2")
        {
            if(skill2 == true)
                {
                Destroy(other.gameObject);
                Invoke("stopSkill2", 5.0f);
            }

            else if (rescount >= 5)
            {
                rescount -= 5;
                Destroy(other.gameObject);
                restext.text = "Åô:" + rescount.ToString("f1");
                particle_pos = this.transform.position;
                Instantiate(particle3, particle_pos, Quaternion.identity);
                audioSourse.PlayOneShot(res);
            }

            else
            {
                result.text = "Score" + uiscript.scorecounter.ToString("f1") + "M";
                result.gameObject.SetActive(true);
                Restart.gameObject.SetActive(true);
                gameOver();
                uiscript.score = false;
                uiscript.Best();
                script.damageselect = false;
                Skill.gameObject.SetActive(false);
                Skill2.gameObject.SetActive(false);

                skill2 = false;


                anim.SetBool("Dead", true);

                nowgaming = false;
            }
            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            if(safezone==false)
            {
                if (skill2 == true)
                {
                    Destroy(collision.gameObject);
                    Invoke("stopSkill2", 5.0f);
                }

                else if (rescount >= 5)
                {
                    rescount -= 5;
                    Destroy(collision.gameObject);
                    restext.text = "Åô:" + rescount.ToString("f1");
                    particle_pos = this.transform.position;
                    Instantiate(particle3, particle_pos, Quaternion.identity);
                    audioSourse.PlayOneShot(res);
                }

            else if(safezone==true)
                {
                    Destroy(collision.gameObject);
                }
                    

                
                else
                {
                    //gameover.gameObject.SetActive(true);
                    result.text = "Score" + uiscript.scorecounter.ToString("f1") + "M";
                    result.gameObject.SetActive(true);
                    Restart.gameObject.SetActive(true);
                    gameOver();
                    uiscript.score = false;
                    uiscript.Best();
                    script.damageselect = false;
                    Skill.gameObject.SetActive(false);
                    Skill2.gameObject.SetActive(false);

                    skill2 = false;


                    anim.SetBool("Dead", true);

                    nowgaming = false;



                    

                }
            }
            
            

            
            
            
            script.stopdamage();
            if(Input.GetKeyDown("space"))
            {
                changeScene();
            }
        }
    }
    private IEnumerator Speedup()
    {
        
        while(true)
        {
            speed += 2.0f;
            //Debug.Log("speedup");
            speedupcount = 0.0f;
            speedup = false;

            speedUPcount += 1;
            if(objspeed<=5.0f)
            {
                objspeed += 1.0f;
            }
            


            yield return new WaitForSeconds(30.0f);
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
            if (Input.GetKey(KeyCode.Z) && speed!=0.0f)
            {

                speedpar.gameObject.SetActive(true);
               
                Skill.gameObject.SetActive(false);
                nowskill += Time.deltaTime;
                speed += 5;
                Invoke("stopSkill", 5.0f);
                
                
                skillcount = 0.0f;
               
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
                mutekipar.gameObject.SetActive(true);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SAFEZONE")

        {
            safezone = true;
            Debug.Log(safezone);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        safezone = false;
        Debug.Log("safeoff");
    }






    public void stopSkill()
    {
        speed -= 5.0f;
        speedpar.gameObject.SetActive(false);
    }
    public void stopSkill2()
    {
        skill2 = false;
        mutekipar.gameObject.SetActive(false);
    }

}
