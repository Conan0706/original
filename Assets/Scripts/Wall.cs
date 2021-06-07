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
    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("Player");
        script = sp.GetComponent<Player>();
        anime = GameObject.Find("Zombie1");
        anim = anime.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player =sp.transform.position;
        chspeed = script.speed;
        transform.position += new Vector3(0, 0, chspeed) * Time.deltaTime;
        //transform.position += new Vector3(player.x , 0 , chspeed) * Time.deltaTime;

        if(script.nowgaming==false)
        {
            anim.SetBool("Bite", true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Stage")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
