using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book1 : Interactable
{
	public string text;
	public float textDuration;
	public AudioClip bookOpen;
	private AudioSource bOpen;
	public GameObject dImage;
	// Start is called before the first frame update
	void Start()
	{
		bOpen = GetComponent<AudioSource>();
		dImage.SetActiveRecursively(false);
	}

	public override void Interact(Transform interactor)
	{
		ReadBook();
	}
	public void Update()
	{
		if(Input.GetKeyDown("q"))
		{
			dImage.SetActiveRecursively(false);
		}
	}
	private void ReadBook()
	{
		dImage.SetActiveRecursively(true);
				
		
			//dImage.SetActiveRecursively(false);
		
		//  GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(text, textDuration);
	}
}