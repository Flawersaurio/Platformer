using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabanoEnemigo : MonoBehaviour
{
    public float velocidadCaminar = 1.5f;
    public float distanciaAgro = 5;
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private GameObject heroe;

    public int puntosDanio = 10;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        heroe = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 posHeroe = heroe.transform.position;
        Vector3 posYo = this.transform.position;

        float distancia = (posYo - posHeroe).magnitude;
        float velActualVert = miCuerpo.velocity.y;

        if (distancia < distanciaAgro)
        {
            if (posHeroe.x > posYo.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
               
            }

            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
              
            }
        }

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(name + " hizo collisi�n con " + collision.gameObject.name);

        GameObject otro = collision.gameObject;

        if (otro.tag == "Player")
        {
            Personaje elPerso = otro.GetComponent<Personaje>();
            elPerso.hacerDanio(puntosDanio, this.gameObject);
        }
    }
}

