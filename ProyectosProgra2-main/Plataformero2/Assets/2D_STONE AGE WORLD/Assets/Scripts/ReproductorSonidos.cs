using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


 [RequireComponent(typeof(AudioSource))]


public class ReproductorSonidos : MonoBehaviour
{

     public EfectoSonoro[] efectos;
     private AudioSource miFuenteSonora;

     // Start is called before the first frame update
    void Start()
    {
        miFuenteSonora = GetComponent<AudioSource>();
        
    }

     public void reproducir (string accion)
    {
         for (int i = 0; i <efectos.Length; i++)
             {
                 EfectoSonoro efecto = efectos[i];
                 if (efecto.accion == accion)
                    {
                        miFuenteSonora.clip = efecto.archivoSonido;
                        miFuenteSonora.Play();
                        break;
                    }
             }
    }

     [Serializable]
    
 public class EfectoSonoro
   {
       public string accion;
       public AudioClip archivoSonido;
        
   }



}
