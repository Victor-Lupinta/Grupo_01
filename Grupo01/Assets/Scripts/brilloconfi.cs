using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;

public class brilloconfi : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image panelbrillo;
    // Star is callled before the first frame upadate 
    private void Start()
    {
       slider.value = PlayerPrefs.GetFloat("brillo",0.5f);

       panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, slider.value);
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void changeSlider(float valor)
    {
        SliderValue = valor;
        PlayerPrefs.SetFloat("brillo", SliderValue);
        panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, slider.value);
    }
    
    
}
