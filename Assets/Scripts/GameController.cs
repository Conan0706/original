using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public GameObject[] objects = new GameObject[2];
    public GameObject[] objects2 = new GameObject[2];
    public GameObject[] healthpla = new GameObject[3];

    //生成時間間隔
    public float interval;
    private float interval2;
    private float interval3;

    //経過時間
    private float time = 0f;
    private float time2 = 0f;
    private float heal_time = 0f;

    GameObject obj;
    GameObject obj2;
    GameObject health;

    public GameObject player;

    public Vector3 player_pos;

    //x座標の最小値
    public float xMinPos = 6f;
    //x座標の最大
    public float xMaxpos = -6f;
    //取得した座標
    float x_pos;

    float x2_pos;

    float health_pos;

    Vector3 obj_pos;
    Vector3 obj2_pos;
    Vector3 healthobj_pos;

    GameObject temp;
    GameObject two;
    GameObject healthobj;

    GameObject[] num;
    GameObject[] sec;
    GameObject[] hel;

    public Player script;

    public bool objon = false;

    public float objspeedup = 2.0f;

    public GameObject particle;
    public GameObject particle2;

    private Vector3 particle_pos;
    private Vector3 particle_pos2;
    // Start is called before the first frame update
    void Start()
    {
        //Shuffle(objects);

        //時間間隔の指定
        interval = 1.0f;
        interval3 = 2.0f;
        interval2 = 3.0f;

        player = GameObject.Find("Player");
        script = player.GetComponent<Player>();


    }

    // Update is called once per frame
    void Update()
    {

        objSpeedUp();
        

        Shuffle(objects);

        Shuffle_heal(healthpla);

        if (script.speedUPcount >= 5)

        {
            objon = true;
            if(objon==true)
            {
                shuffle(objects2);
            }
        }
        //shuffle(objects2);

        


            player_pos = player.transform.position;

            obj_pos = player_pos;
            obj_pos.z += 30f;
            obj_pos.x = Random.Range(xMinPos, xMaxpos);

            obj2_pos = player_pos;
            obj2_pos.z += 25.0f;
            obj2_pos.x = Random.Range(xMinPos, xMaxpos);

            healthobj_pos = player_pos;
            healthobj_pos.z += 30f;
            healthobj_pos.x = Random.Range(xMinPos, xMaxpos);
            healthobj_pos.y = 1.0f;
        

            time += Time.deltaTime;
            heal_time += Time.deltaTime;
            time2 += Time.deltaTime;

            //生成時間になると
            if (time > interval)
            {
                GameObject enemy = Instantiate(obj);

                
    
                enemy.transform.position = obj_pos;

                time = 0f;
                


            }
            if (heal_time > interval2)
            {
                GameObject healthIns = Instantiate(health);
                healthIns.transform.position = healthobj_pos;
                if (health.tag == "health")
                {
                    
                    particle_pos = healthobj_pos;
                    Instantiate(particle, particle_pos, Quaternion.identity);
                }
                if (health.tag == "respawn")
                {
                    
                    particle_pos2 = healthobj_pos;
                    Instantiate(particle2, particle_pos2, Quaternion.identity);
                }
            heal_time = 0f;
                Debug.Log("a");
            }
        if (time2 > interval3 && objon==true)
        {
            GameObject enemy2 = Instantiate(obj2);
            enemy2.transform.position = obj2_pos;
            time2 = 0f;
        }


           


    }
        void Shuffle(GameObject[] num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                GameObject temp = num[i];
                int randomIndex = Random.Range(0, num.Length);
                num[i] = num[randomIndex];
                num[randomIndex] = temp;
                obj = num[randomIndex];



            }
        }
        void shuffle(GameObject[] sec)
        {
           
        
            for (int i = 0; i < sec.Length; i++)
            {
                GameObject two = sec[i];
                int randomInd = Random.Range(0, sec.Length);
                sec[i] = sec[randomInd];
                sec[randomInd] = two;
                obj2 = sec[randomInd];
            }
            
        }

        void Shuffle_heal(GameObject[] hel)
        {
            for (int i = 0; i < hel.Length; i++)
            {
                GameObject healthobj = hel[i];
                int random = Random.Range(0, hel.Length);
                hel[i] = hel[random];
                hel[random] = healthobj;
                health = hel[random];
            }
        }
        
        public void objSpeedUp()
        { 
        if (objspeedup == script.objspeed)
        {
            interval -= 0.1f;
            Debug.Log("Doen");
            objspeedup += 1.0f;
        }
        }



        /*void PlayerPos()
        {
            player_pos = player.transform.position;

            obj_pos = player_pos;
            obj_pos.z -= 10f;

        }*/
        /*public void Random_x_pos()
        {
            float x = Random.Range(xMinPos, xMaxpos);

        }*/



    
}
