using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMastiga : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] float speed; 
    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            direction =  new Vector3(speed, 0f, 0f);
        else if(Input.GetKeyDown(KeyCode.A))
            direction = new Vector3(-speed, 0f, 0f);
        else if(Input.GetKeyDown(KeyCode.W))
            direction = new Vector3(0f,0f,speed);
        else if(Input.GetKeyDown(KeyCode.S))
            direction = new Vector3(0f,0f,-speed);
        GetComponent<Rigidbody>().velocity = direction;      
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Wall")
        {
            direction = Vector3.zero; 
        }
    }
}
