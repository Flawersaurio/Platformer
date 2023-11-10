using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGUI : MonoBehaviour
{
    public Personaje heroe;
    public Text etiquetaHPHeroe;
    public Image barraHPHeroe;

    public Text puntosHeroe;
    public Text etiquetaVidas;

    // Update is called once per frame
    void Update()
    {

        etiquetaHPHeroe.text = heroe.hp + "/" + heroe.hpMax;
        float porcentajeHp = heroe.hp / (float) heroe.hpMax;
        barraHPHeroe.fillAmount = porcentajeHp;

        puntosHeroe.text = heroe.score.ToString();
        

        etiquetaVidas.text = heroe.vidas.ToString();
        

    }
}
