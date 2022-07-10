using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gates : MonoBehaviour
{
   
    public delegate void OnHeightScaleHandler(float value);
    public static event OnHeightScaleHandler OnHeightScale;

    public delegate void OnThicknessScaleHandler(float value);
    public static event OnThicknessScaleHandler OnThicknessScale;

    [SerializeField] float size;
    private float heightMultiplier = 0.005f;
    private float thicknessMultiplier = 0.01f;
    [SerializeField] ParticleSystem particle;
    enum TriggerState
    {
        Height,Thickness    
    }
    [SerializeField] TriggerState transformState;

    

    private void OnTriggerEnter(Collider other)
    {
        switch (transformState)
        {
            case TriggerState.Height:
                OnHeightScale?.Invoke(size* heightMultiplier);          
                Instantiate(particle, transform.position, Quaternion.identity);
               
                break;
            case TriggerState.Thickness:
                OnThicknessScale?.Invoke(size* thicknessMultiplier);
                Instantiate(particle, transform.position, Quaternion.identity);
                break;
               
        }

        gameObject.transform.parent.gameObject.SetActive(false);

    }
}
