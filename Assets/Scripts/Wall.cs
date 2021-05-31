using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject sp;
    public Player script;
    public float chspeed;
    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("Player");
        script = sp.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        chspeed = script.speed;
        transform.position += new Vector3(0, 0, chspeed) * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
