using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using System;

//this script is exactly the same as the one you made in class 
public class VignetteScript : MonoBehaviour
{
    [SerializeField] float intensity = 0.75f;
    [SerializeField] float duration = 0.75f;
    [SerializeField] private Volume volume;
    Vignette vigette;
    [SerializeField] InputActionReference continuousMove;

    private void Awake()
    {
        if (volume.profile.TryGet(out Vignette vignette))
            this.vigette = vignette;


        continuousMove.action.performed += FadeIn;
        continuousMove.action.canceled += FadeOut;
    }

    private void FadeOut(InputAction.CallbackContext obj)
    {
        StartCoroutine(Fade(0, intensity));
    }

    private void FadeIn(InputAction.CallbackContext obj)
    {
        if (obj.ReadValue<Vector2>() != Vector2.zero)
        {
            StartCoroutine(Fade(intensity, 0));
        }
    }
    IEnumerator Fade(float startValue, float endValue)
    {
        float elapsedTime = 0.0f;
        float blend = elapsedTime / duration;
        float intensity = Mathf.Lerp(startValue, endValue, blend);
        ApplyValue(intensity);

        yield return null;
    }
    
    void ApplyValue (float value)
    {
        vigette.intensity.Override(value);
    }
}
