using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialLever2 : Interactable
{
    public float activeTime;
    private Animator animator;
    private bool triggered = false;
    GameObject b1, b2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        b1 = GameObject.Find("Block1");
        b2 = GameObject.Find("Block2");
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
        DeathManagerTimeTrial.wallsBeMoving = true;
        triggered = true;
        animator.SetBool("IsOn", true);
        b1.SetActive(false);
        b2.SetActive(false);
        Invoke("EndPuzzle", activeTime);
    }

    private void EndPuzzle()
    {
        DeathManagerTimeTrial.wallsBeMoving = false;
        animator.SetBool("IsOn", false);
        b1.SetActive(true);
        b2.SetActive(true);
        triggered = false;
    }
}
