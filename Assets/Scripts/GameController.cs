using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public GameObject[] objects = new GameObject[5];

    //�������ԊԊu
    private float interval;

    //�o�ߎ���
    private float time = 0f;

    GameObject obj;

    public GameObject player;

    public Vector3 player_pos;

    //x���W�̍ŏ��l
    public float xMinPos = 6f;
    //x���W�̍ő�
    public float xMaxpos = -6f;
    //�擾�������W
    float x_pos;

    Vector3 obj_pos;

    GameObject temp;

    GameObject[] num;

    

    // Start is called before the first frame update
    void Start()
    {
        //Shuffle(objects);

        //���ԊԊu�̎w��
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

        //�������ԂɂȂ��
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
