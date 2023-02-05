using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PostProcessCode : MonoBehaviour
{
    [SerializeField] Volume volume;
    ColorAdjustments colorAdjustments;
    [SerializeField] Color lightcolorFlicker;
    [SerializeField] float flickerRateMin,flickerRateMax;
    Color defaultcolor;


    bool flickered;
    bool vignToggle;


    Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        ColorAdjustments tmp;
        volume.profile.TryGet<ColorAdjustments>(out tmp);
        colorAdjustments = tmp;
        defaultcolor = colorAdjustments.colorFilter.value;
        Invoke(nameof(LightFlicker),0);


        Vignette tmp2;
        volume.profile.TryGet<Vignette>(out tmp2);
        vignette = tmp2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LightFlicker()
    {
        if (!flickered)
        {
            colorAdjustments.colorFilter.Override(lightcolorFlicker);
            flickered = true;
        }
        else
        {
            colorAdjustments.colorFilter.Override(defaultcolor);
            flickered = false;
        }
        Invoke(nameof(LightFlicker),Random.Range(flickerRateMin,flickerRateMax));
    }
    public void ToggleVinginette()
    {
        vignToggle = !vignToggle;
        if (vignToggle)
        {
            vignette.smoothness.value = 1;
        }
        else
        {
            vignette.smoothness.value = .2f;
        }
    }
}
