using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    private void Star()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaActual(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaActual(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
 