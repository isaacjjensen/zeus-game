using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffWater : MonoBehaviour
{
    public GameObject underwaterEffect;
    public GameObject underwaterEffectHorizon;
    public GameObject underwaterEffectParticles;
    public GameObject underwaterEffectPostProcessing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Turns off water effect when passing through force field
    private void OnTriggerEnter(Collider other)
    {
        underwaterEffect.SetActive(false);
        underwaterEffectHorizon.SetActive(false);
        underwaterEffectParticles.SetActive(false);
        underwaterEffectPostProcessing.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        underwaterEffect.SetActive(false);
        underwaterEffectHorizon.SetActive(false);
        underwaterEffectParticles.SetActive(false);
        underwaterEffectPostProcessing.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        underwaterEffect.SetActive(true);
        underwaterEffectHorizon.SetActive(true);
        underwaterEffectParticles.SetActive(true);
        underwaterEffectPostProcessing.SetActive(true);
    }
}
