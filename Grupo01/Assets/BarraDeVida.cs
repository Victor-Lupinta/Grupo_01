using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    private void Star()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaMaxima(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaMaxima(cantidadVida);
    }
}
