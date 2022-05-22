using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMastiga : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] float speed; 
    NavMeshAgent player;
    Vector3 direction = Vector3.zero;
    Vector3 newDirection = Vector3.zero; 
    Transform nextPoint, lastPoint;

    // Start is called before the first frame update
    void Start()
    {
        direction =  new Vector3(speed, 0f, 0f);
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            newDirection =  new Vector3(speed, 0f, 0f);
        if(Input.GetKeyDown(KeyCode.A))
            newDirection = new Vector3(-speed, 0f, 0f);
        if(Input.GetKeyDown(KeyCode.W))
            newDirection = new Vector3(0f,0f,speed);
        if(Input.GetKeyDown(KeyCode.S))
            newDirection = new Vector3(0f,0f,-speed);

        if(direction.x != 0 && newDirection.x + direction.x == 0)
        {
            player.destination = lastPoint.position;
            Transform aux = lastPoint;
            lastPoint = nextPoint;
            nextPoint = aux; 
            direction = newDirection;
        }

        if(direction.z !=0 && newDirection.z + newDirection.z == 0)
        {
            player.destination = lastPoint.position;
            Transform aux = lastPoint;
            lastPoint = nextPoint;
            nextPoint = aux;  
            direction = newDirection;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "changeDirectionMastigaCome")
        {
            direction = newDirection; 
            nextPoint = other.gameObject.GetComponent<changeDirectionMC>().changeDirection(direction); 
            lastPoint = other.gameObject.transform;
            if(nextPoint != null)
            {
                player.destination = nextPoint.position;
            }
        }
    }
}
