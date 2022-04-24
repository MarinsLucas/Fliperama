using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySW : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] GameObject explosionEffect; 
    [SerializeField] GameObject hitEffect; 

    [Header("Variáveis")]
    [SerializeField] float horizontalSpeed; 
    [SerializeField] float verticalSpeed; 
    [SerializeField] float horizontalLimit;
    [SerializeField] float offset; 
    [SerializeField] projectileSW projectile;
    float shootTimer; 

    [Header("Parametros")]
    [SerializeField] float health;
    [SerializeField] int points; 

    [Header("Caracteristicas")]
    [SerializeField] bool shoot;
    [SerializeField] bool follow; 
    [SerializeField] bool kamikase;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalSpeed, -verticalSpeed, 0f);
        if(shoot)
            shootTimer = projectile.shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //if follow is true
        if(GameManagerSW.instance.isRunning)
        {
            if(follow && GameManagerSW.instance.player != null)
            {
                if(transform.position.x > GameManagerSW.instance.player.transform.position.x || transform.position.x < GameManagerSW.instance.player.transform.position.x )
                transform.position =  Vector3.MoveTowards(transform.position, new Vector3(GameManagerSW.instance.player.transform.position.x, transform.position.y, transform.position.z), horizontalSpeed/2);
            } 
            else
            {
                if(transform.position.x > horizontalLimit || transform.position.x < -horizontalLimit)
                {
                    horizontalSpeed *= -1; 
                    GetComponent<Rigidbody>().velocity = new Vector3(horizontalSpeed, -verticalSpeed, 0f);
                }
            }

            if(shoot)
            {
                if(shootTimer <=0)
                {
                    GameObject projectileInstance = Instantiate(projectile.gameObject, transform);
                    projectileInstance.transform.position = transform.position;
                    projectileInstance.transform.SetParent(this.transform.parent);

                    projectileInstance.GetComponent<projectileSW>().speed*=-1; 
                    shootTimer = projectileInstance.GetComponent<projectileSW>().shootCooldown; 
                }
                shootTimer-=Time.deltaTime;

            }

            if(health <= 0)
            {
                GameManagerSW.instance.AddPoints(points);
                GameObject explosion = Instantiate(explosionEffect, transform.parent);
                explosion.transform.position = transform.position;
                Destroy(explosion, 3);
                Destroy(this.gameObject);

            }
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage; 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            TakeDamage(other.gameObject.GetComponent<projectileSW>().damage);
            if(health>0)
            {
               GameObject hit = Instantiate(hitEffect, transform.parent);
               hit.transform.position = transform.position; 
               Destroy(hit, 3);
            }
            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            if(!kamikase)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                GameManagerSW.instance.player.TakeDamage(health);
                Destroy(this.gameObject);
            }     
            GameObject explosion = Instantiate(explosionEffect, transform.parent);
            explosion.transform.position = transform.position;
            Destroy(explosion, 3);
        }  
    }
}
