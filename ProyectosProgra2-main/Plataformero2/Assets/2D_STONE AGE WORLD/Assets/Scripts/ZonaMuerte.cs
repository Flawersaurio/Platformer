using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{

    public GameObject efectoSangreAgua;
    private ReproductorSonidos misSonidos;

    private void Start()
    {
        misSonidos = GetComponent<ReproductorSonidos>();
    }


     private void OnTriggerEnter2D(Collider2D collider)
        {
        print(name + " hizo colisiòn con " + collider.gameObject.name);
        
         GameObject otro = collider.gameObject;
         if (otro.tag =="Player")
        {
             Personaje elPerso = otro.GetComponent<Personaje>();
             elPerso.matar (this.gameObject);

             GameObject sangre = Instantiate(efectoSangreAgua, elPerso.transform);
             misSonidos.reproducir("SALPICAR");
        }
    }

   
}
