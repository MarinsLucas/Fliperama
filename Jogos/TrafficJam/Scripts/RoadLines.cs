using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLines : MonoBehaviour
{
    public float speed = 1f;
    public float bottomLimit = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= 0)
        {
            Destroy(gameObject);
        }
        if(!GameManager.instance.isRunning)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; 
        }
    }
}
