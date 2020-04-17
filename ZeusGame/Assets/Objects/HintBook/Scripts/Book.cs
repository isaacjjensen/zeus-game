using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : Interactable
{
    public string text;
    public float textDuration;
    public AudioClip bookOpen;
    private AudioSource bOpen;

    // Start is called before the first frame update
    void Start()
    {
        bOpen = GetComponent<AudioSource>();
    }

    public override void Interact(Transform interactor)
    {
        ReadBook();
    }

    private void ReadBook()
    {
        GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(text, textDuration);
    }
}
