using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public float maxHP = 50;
    public float currentHP;
    public Slider slider;
    public float damage;

    public Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        //HP‚ð–žƒ^ƒ“‚É
        slider.value = 1;

        currentHP = maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*damage = Time.deltaTime*1.0f;

        currentHP -= damage;

        //Slider‚É”½‰f
        slider.value =currentHP / maxHP; ;
        */
        Damage();

    }

    public void Damage()
    {
        damage = Time.deltaTime * 1.0f;

        currentHP -= damage;

        //Slider‚É”½‰f
        slider.value = currentHP / maxHP; ;

        if (currentHP <= 0)
        {
            gameOver.gameObject.SetActive(true);
        }
    }

    
    }

