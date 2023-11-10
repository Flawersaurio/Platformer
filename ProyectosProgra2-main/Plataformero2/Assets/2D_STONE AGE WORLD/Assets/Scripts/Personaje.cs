using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int hp =60; 
    public int hpMax = 100;
    public int score = 0;
    public int vidas = 3;
    public bool aturdido = false;
    public bool muerto = false;

    public GameObject efectoSangrePrefab;
  
    private Animator miAnimador;
    private ReproductorSonidos misSonidos;

    void Start()
    {
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<ReproductorSonidos>();

    }

    // Update is called once per frame
    void Update()
    {

       
    }

    public void hacerDanio(int puntos, GameObject atacante )
    {
        print(name + " recibe daño de " + puntos + " por " + atacante.name);

        
        //resto los puntos al HP actual
        hp = hp - puntos;

        if (hp <= 0)
        {
            muerto = true;
        }

        if (miAnimador != null)
        {
            miAnimador.SetTrigger("DAÑAR");
        }

        //Creo una instancia de la particula de sangre
        GameObject sangre = Instantiate(efectoSangrePrefab, transform);

        if (misSonidos != null)
        {
            misSonidos.reproducir("DAÑAR");
        }


        aturdido = true;

        Invoke("desaturdir", 1);
    }

    private void desaturdir()
    {
        aturdido = false;
    }


    public void matar(GameObject atacante)
    {
        print(name + " ha sido matado por " + atacante.name);
        hp = 0;
        vidas--;

        misSonidos.reproducir("MORIR");
    }

}
