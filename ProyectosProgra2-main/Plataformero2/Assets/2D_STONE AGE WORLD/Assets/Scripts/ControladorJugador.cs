using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float velocidadCaminar = 5;
    public float fuerzaSalto = 11;
    public bool enPiso;
    public int contadorSaltos;

    public int puntosDanio = 30;


    private Rigidbody2D MiCuerpo;
    private Animator miAnimador;
    private ReproductorSonidos misSonidos;
    private Personaje miPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        //asignar rigid body al atributo mi cuerpo
        MiCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<ReproductorSonidos>();
        miPersonaje = GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        comprobarPiso();

        float velActualVert = MiCuerpo.velocity.y;

        float movHoriz = Input.GetAxis("Horizontal");
        if (movHoriz > 0) //a la derecha
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            MiCuerpo.velocity = new Vector3(velocidadCaminar, velActualVert, 0);
            miAnimador.SetBool("CAMINANDO", true);
        }

        else if (movHoriz < 0)//a la izquierda
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            MiCuerpo.velocity = new Vector3(-velocidadCaminar, velActualVert, 0);
            miAnimador.SetBool("CAMINANDO", true);
        }

        else//quieto
        {
            MiCuerpo.velocity = new Vector3(0, velActualVert, 0);
            miAnimador.SetBool("CAMINANDO", false);
        }

        if (enPiso == true)
        {
            if (Input.GetButtonDown("Jump") && !miPersonaje.aturdido)
            {
                print("Saltando");
                MiCuerpo.AddForce(new Vector3(0, fuerzaSalto, 0),
                    ForceMode2D.Impulse);

                misSonidos.reproducir("SALTAR");
            }

            contadorSaltos = contadorSaltos - 1;
            miAnimador.SetBool("EN_PISO", true);
        }
        else if (contadorSaltos > 0)
        {

            if (Input.GetButtonDown("Jump"))
            {
                print("Saltando");
                MiCuerpo.AddForce(
                    new Vector3(0, fuerzaSalto, 0),
                    ForceMode2D.Impulse);
                contadorSaltos = contadorSaltos - 1;
                miAnimador.SetBool("EN_PISO", true);
            }
        }

        if (Input.GetButtonDown("Fire1") && !miPersonaje.aturdido)
        {//atacar
            miAnimador.SetTrigger("ATACAR");
        }


        miAnimador.SetFloat("VEL_VERT", velActualVert);
    }
    void comprobarPiso()
    {
        enPiso = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            0.1f);

        if (enPiso == true)
        {
            contadorSaltos = 2;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        print("Arma " +name + " hizo colisiòn con " + collider.gameObject.name);

        GameObject otro = collider.gameObject;


        if (otro.tag == "Enemigo")
        {

            Personaje elPerso = otro.GetComponent<Personaje>();

            elPerso.hacerDanio(puntosDanio, this.gameObject);


        }
    }
}


