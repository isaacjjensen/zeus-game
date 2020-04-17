using UnityEngine;
using System.Collections;

public class Promptpoint : MonoBehaviour {
    public string prompt;
    public float promptDuration;
    private bool hasBeenTriggered = false;
	
	void OnTriggerEnter(Collider other) {
		if (!hasBeenTriggered)
        {
            GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(prompt, promptDuration);
            hasBeenTriggered = true;
        }
	}
}