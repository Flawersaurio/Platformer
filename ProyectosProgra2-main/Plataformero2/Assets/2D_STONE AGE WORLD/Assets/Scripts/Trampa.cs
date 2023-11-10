using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{

    public int puntosDanio = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(name + " hizo colisi�n con " + collision.gameObject.name);

        GameObject otro = collision.gameObject;
        if (otro.tag == "Player")
        {

            //Accedo al componente de tipo Personaje del objeto con el que choque
            Personaje elPerso = otro.GetComponent<Personaje>();

            //Aplico el da�o al otro invocado al metodo hacer da�o
            elPerso.hacerDanio(puntosDanio, this.gameObject);
        
        }

    }

    void Update()
    {
        
    }
}

