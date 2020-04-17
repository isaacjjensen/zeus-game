using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialLever1 : Interactable
{
    public float activeTime;
    private Animator animator;
    private bool triggered = false;
    GameObject s1, s2, s3, s4, s5, s6;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        s1 = GameObject.Find("Sphere1");
        s2 = GameObject.Find("Sphere2");
        s3 = GameObject.Find("Sphere3");
        s4 = GameObject.Find("Sphere4");
        s5 = GameObject.Find("Sphere5");
        s6 = GameObject.Find("Sphere6");
        EndPuzzle();
    }

    public override void Interact(Transform interactor)
    {
        if (!triggered)
        {
            TriggerPuzzle();
        }
    }

    private void TriggerPuzzle()
    {
        triggered = true;
        animator.SetBool("IsOn", true);
        s1.SetActive(true);
        s2.SetActive(true);
        s3.SetActive(true);
        s4.SetActive(true);
        s5.SetActive(true);
        s6.SetActive(true);
        Invoke("EndPuzzle", activeTime);
    }

    private void EndPuzzle()
    {
        animator.SetBool("IsOn", false);
        s1.SetActive(false);
        s2.SetActive(false);
        s3.SetActive(false);
        s4.SetActive(false);
        s5.SetActive(false);
        s6.SetActive(false);
        triggered = false;
    }
}
