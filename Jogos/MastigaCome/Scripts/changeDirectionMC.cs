using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirectionMC : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] Transform up;
    [SerializeField] Transform down;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    public Transform changeDirection(Vector3 direction)
    {
        if(direction.z > 0f) return up;
        else if(direction.z<0f) return down;
        else if(direction.x>0f) return right;
        else if(direction.x<0f) return left;
        else return null;
    }
}
