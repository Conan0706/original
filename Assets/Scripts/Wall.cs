using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject sp;
    public Player script;
    public float chspeed;
    public float slide = 20.0f;
    private Animator anim;
    GameObject anime;
    public float pos_x;
    public float playerpos_x;
    //float distance = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("Player");
        script = sp.GetComponent<Player>();
        anime = GameObject.Find("Zombie1");
        anim = anime.GetComponent<Animator>();
        chspeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 player =sp.transform.position;
        chspeed = script.speed;
        transform.position += new Vector3(0, 0, chspeed) * Time.deltaTime;
        pos_x = sp.transform.position.x;
        transform.position = new Vector3(pos_x , 0 , chspeed) * Time.deltaTime;
        */
        
        

        if(script.nowgaming==false)
        {
            this.transform.parent = null;
            //distance = sp.transform.position.z-this.transform.position.z;
            //distance =Vector3.Distance(sp.transform.position, this.transform.position);
            //transform.position += new Vector3(0, 0, distance * chspeed) * Time.deltaTime;
            
            transform.position += new Vector3(0, 0, chspeed) * Time.deltaTime;
            //pos_x = this.transform.position.z;
            //playerpos_x = sp.transform.position.z;
            //float pos_gap = pos_x -= playerpos_x;
            //if (pos_gap >1.0f)
            //{
                //chspeed = 0.0f;
                //anim.SetBool("Bite", true);
            //}
        }

    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Stage" && collision.gameObject.tag!="Player")
        {
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.tag=="Player")
        {
            chspeed = 0.0f;
            anim.SetBool("Bite", true);
        }
    }
}
