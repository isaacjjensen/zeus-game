//Randall Howatt
//CSci 448
//Modified by Christian Sandtveit to show the crouch prompt
//Modified by Jordan Hoffman. Added a few more information prompts.
using UnityEngine;
using System.Collections;

public class Promptpoint : MonoBehaviour {

	public string promptType = "";
	private bool shownInteract = false;
    private bool shownCrouch = false;
	private bool shownSprint = false;
	private bool shownJump = false;
	private bool shownKey = false;
	private bool shownTrap = false;
	private bool shownSensitivity = false;
	private bool shownPillars = false;
	private bool shownObjandSwitches = false;
	private bool shownResetRocks = false;
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			if (promptType.Equals ("Interact") && shownInteract == false) {
				shownInteract = true;
				FindObjectOfType<guiPrompt>().ActivateInteractPrompt ();
			}
			else if (promptType.Equals ("Sprint") && shownSprint == false) {
				shownSprint = true;
				FindObjectOfType<guiPrompt>().ActivateSprintPrompt();
			}
			else if (promptType.Equals ("Jump") && shownJump == false) {
				shownJump = true;
				FindObjectOfType<guiPrompt>().ActivateJumpPrompt();
			}
            else if (promptType.Equals("Crouch") && shownCrouch == false)
            {
                shownCrouch = true;
                FindObjectOfType<guiPrompt>().ActivateCrouchPrompt();
            }
			else if (promptType.Equals ("Key") && shownKey == false) {
				shownKey = true;
				FindObjectOfType<guiPrompt>().ActivateKeyPrompt();
			}else if (promptType.Equals ("Traps") && shownTrap == false){
				shownTrap = true;
				FindObjectOfType<guiPrompt>().ActivateTrapPrompt();
			}else if (promptType.Equals ("Sensitivity") && shownSensitivity == false){
				shownSensitivity = true;
				FindObjectOfType<guiPrompt>().ActivateSensitivityPrompt();
			}else if (promptType.Equals ("Pillars") && shownPillars == false){
				shownPillars = true;
				FindObjectOfType<guiPrompt>().ActivatePillarsPrompt();
			}else if (promptType.Equals ("ObjandSwitches") && shownObjandSwitches == false){
				shownObjandSwitches = true;
				FindObjectOfType<guiPrompt>().ActivateObjandSwitchesPrompt();
			}else if (promptType.Equals ("ResetRocks") && shownResetRocks == false){
				shownResetRocks = true;
				FindObjectOfType<guiPrompt>().ActivateResetRocksPrompt();
			}
		}
	}
}