using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPbar : MonoBehaviour
{
    public float maxHP = 50;
    public float currentHP;
    public Slider slider;
    public float damage;

    public Text gameOver;
    public Text Result;
    public Text Restart;
    
    public GameObject player;
    public Player script;

    public GameObject decision;
    

    public bool damageselect=true;

    public GameObject ui;
    public UIManager uiscript;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        //HP‚ð–žƒ^ƒ“‚É
        slider.value = 1;

        currentHP = maxHP;

        player = GameObject.Find("Player");
        script = player.GetComponent<Player>();
        ui = GameObject.Find("Canvas");
        uiscript = ui.GetComponent<UIManager>();

        sceneName = SceneManager.GetActiveScene().name;



    }

    // Update is called once per frame
    void Update()
    {
       

        //Slider‚É”½‰f
        slider.value =currentHP / maxHP; ;
        
        Damage();

        if (Result.gameObject == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneName);
            }
        }

    }

    public void Damage()
    {
        if(damageselect==true)
        {
            damage = Time.deltaTime * 1.0f;




            currentHP -= damage;



            //Slider‚É”½‰f
            slider.value = currentHP / maxHP;
        }

        else if(damageselect==false)
        {
            damage = 0.0f;
        }
       
        

        if (currentHP <= 0)
        {
            gameOver.gameObject.SetActive(true);
            Result.text = "Score"+uiscript.scorecounter.ToString("f1")+"M";
            Result.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            script.gameOver();
            damageselect = false;
            uiscript.score = false;
            script.Skill.gameObject.SetActive(false);
            script.Skill2.gameObject.SetActive(false);
            script.skill2 = false;


        }
        
    }

    public void heal()
    {
        currentHP += 15.0f;
        if(currentHP>50.0f)
        {
            currentHP = 50.0f;
        }
    }

    public void stopdamage()
    {
        damage = 0;
    }

   
}

