using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuplySW : MonoBehaviour
{
    public float verticalSpeed; 
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, -verticalSpeed, 0f);
    }
}
