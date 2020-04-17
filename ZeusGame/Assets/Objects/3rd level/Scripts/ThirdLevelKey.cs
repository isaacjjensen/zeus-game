using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdLevelKey : Interactable
{
    public string text;
    public float textDuration;
    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
    }

    public override void Interact(Transform interactor)
    {
        CollectKey();
    }

    private void CollectKey()
    {
        this.GetComponent<Renderer>().enabled = false;
        GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(text, textDuration);
        Invoke("TeleportToHub", textDuration);

        switch (levelName)
        {
            case "TimeTrialLevel":
            case "Timeworn":
                KeyManager.timeKeyCollected = true;
                break;
            case "iceCave":
                KeyManager.iceKeyCollected = true;
                break;
            case "TeleportPuzzle":
                KeyManager.teleKeyCollected = true;
                break;
        }
    }
    
    private void TeleportToHub()
    {
        SceneManager.LoadScene("ForestClearing");
    }
}
