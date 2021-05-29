using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public GameObject[] objects = new GameObject[5];

    //生成時間間隔
    private float interval;

    //経過時間
    private float time = 0f;

    GameObject obj;

    public GameObject player;

    public Vector3 player_pos;

    //x座標の最小値
    public float xMinPos = 6f;
    //x座標の最大
    public float xMaxpos = -6f;
    //取得した座標
    float x_pos;

    Vector3 obj_pos;

    GameObject temp;

    GameObject[] num;

    

    // Start is called before the first frame update
    void Start()
    {
        //Shuffle(objects);

        //時間間隔の指定
        interval = 1.0f;

        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Shuffle(objects);

        player_pos = player.transform.position;

        obj_pos = player_pos;
        obj_pos.z += 30f;
        obj_pos.x = Random.Range(xMinPos, xMaxpos);

        time += Time.deltaTime;

        //生成時間になると
        if(time>interval)
        {
            GameObject enemy = Instantiate(obj);
            //Debug.Log(enemy);
            enemy.transform.position = obj_pos;
            time = 0f;         

        }


    }
    void Shuffle(GameObject[] num)
    {
        for(int i=0;i<num.Length;i++)
        {
            GameObject temp = num[i];
            int randomIndex = Random.Range(0, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = temp;
            obj = num[randomIndex];
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
