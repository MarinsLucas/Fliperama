using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    public Transform[] lineSpawners;
    public float spawnInterval = 0.3f; 
    float spawnTimer;
    public GameObject whiteLinePrefab;
    public GameObject yellowLinePrefab;

    void Start()
    {
        spawnTimer = 0.3f; 
    }
    void Update()
    {
        if(GameManager.instance.isRunning)
        {
            if(spawnTimer <= 0)
            {
                for(int i=0; i<lineSpawners.Length;i++)
                {
                    GameObject lineInstance; 
                    if(i%2==0)
                        lineInstance = Instantiate(whiteLinePrefab, transform);
                    else
                        lineInstance = Instantiate(yellowLinePrefab, transform);
                    lineInstance.transform.position = lineSpawners[i].position;
                    lineInstance.transform.SetParent(transform);
                }
                spawnTimer = spawnInterval;
            }
            else
                spawnTimer -= Time.deltaTime; 
        }
    }
}
