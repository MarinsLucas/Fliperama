using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script responsável pela movimentação de todos os elementos presentes no cenário do jogo
    Adiciona velocidade no objeto quando iniciado e destroy o objeto quando ele sai da tela
*/

public class BackGround : MonoBehaviour
{
    public float speed;
    public Vector3 maxSize;
    public Vector3 minSize;
    public float spawnPos; 
    float aux; 

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -speed);
        aux = Random.Range(minSize.x, maxSize.x);
        transform.localScale = new Vector3(aux, aux, aux);
    }

    void Update()
    {
        if(!GameManager.instance.isRunning)
            GetComponent<Rigidbody>().velocity = Vector3.zero; 

        if(transform.position.z<0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnPos);
            aux = Random.Range(minSize.x, maxSize.x);
            transform.localScale = new Vector3(aux, aux, aux);
            transform.eulerAngles = new Vector3(-90f,0f, Random.Range(0f,360f));
        }
    }
}
