using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Script que define o movimento de um arbustinho que roda pelo cenário
*/
public class Bush : MonoBehaviour
{
    public float speed; 
    public float lateralSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-lateralSpeed,0f,-speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -30f)
        {
            transform.position = new Vector3(40f,7f,Random.Range(35f,50f));
            GetComponent<Rigidbody>().velocity = new Vector3(-lateralSpeed,0f, -speed);
        }
    }
}
