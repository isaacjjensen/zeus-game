//Michael Schilling
//CSci 448

//edited by Jordan Hoffman to increase default interact distance
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    private MouseLook playerMouseLook, mainMouseLook;
	private Camera playerCamera;
	public float interactDistance = 3.25f;//increased interact distance from 1.25f to 3.25f
	public LayerMask interactableLayerMask;
    public Checkpoint lastCheckpoint;
	private AudioClip TyJump;
	private AudioClip TyBreathe;
	private CharacterMotor motor;
    private GameObject lastHoveredGameObject, inventoryPanel, HUD;
    private Animator handPanelAnimator;
    private bool inventoryShowing, toolEquipped, toolSelected;
    public bool DevToggle = false;
    void Start()
    {
        mainMouseLook = Camera.main.GetComponent<MouseLook>();
        playerMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
        print(SceneManager.GetActiveScene().name);
		playerCamera = GetComponentInChildren<Camera>();
		TyJump = Resources.Load ("Sound/TyJump") as AudioClip;
		motor = GetComponent<CharacterMotor> ();
        interactableLayerMask = LayerMask.GetMask("Interactables");
        lastHoveredGameObject = null;
        HUD = GameObject.Find("HUD");
        inventoryShowing = false;
        inventoryPanel = HUD.transform.Find("InventoryPanel").gameObject;
        inventoryPanel.SetActive(false);
    }

	void Update()
	{
        RaycastHit hitInfo;
        
        // Interaction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactDistance, interactableLayerMask))
        {
            if (hitInfo.collider.gameObject != null)
            {
                hitInfo.collider.gameObject.GetComponent<Interactable>().OnHover();
            }

            if (lastHoveredGameObject != null && hitInfo.collider.gameObject != lastHoveredGameObject)
            {
                lastHoveredGameObject.GetComponent<Interactable>().OnHoverExit();
                lastHoveredGameObject = hitInfo.collider.gameObject;
            } else if (lastHoveredGameObject == null)
            {
                lastHoveredGameObject = hitInfo.collider.gameObject;
            }
            
            if (Input.GetButtonDown("Interact"))
            {
                hitInfo.transform.gameObject.GetComponent<Interactable>().Interact(this.playerCamera.GetComponentInChildren<Rigidbody>().transform);
            }
        } else if (lastHoveredGameObject != null)
        {
            lastHoveredGameObject.GetComponent<Interactable>().OnHoverExit();
            lastHoveredGameObject = null;
        }
  
        // Inventory
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventoryWindow(InventoryTabManager.InventoryTab.TOOLS);

        }
        if (Input.GetButtonDown("Collectibles"))
        {
            ToggleInventoryWindow(InventoryTabManager.InventoryTab.COLLECTIBLES);

        }
        if (Input.GetButtonDown("Notes"))
        {
            ToggleInventoryWindow(InventoryTabManager.InventoryTab.NOTES);

        }

        // Hand & Tool HUD and animation management
        if (Input.GetButtonDown("HandSwap"))
        {
            HUD.GetComponent<GUIManager>().getHandManager().toggleHoldingTool();
        }
        if (HUD.GetComponent<GUIManager>().getHandManager().isHoldingTool())
        {
            HUD.GetComponent<GUIManager>().getHandManager().getEquippedTool().updateAnimation(motor);
            if (Input.GetButtonDown("Fire1") && !inventoryShowing)// && !playerCamera.GetComponent<menuPause>().IsGamePaused())
            {
                HUD.GetComponent<GUIManager>().getHandManager().getEquippedTool().action();
            }
            if (Input.GetButtonUp("Fire1") && !inventoryShowing)// && !playerCamera.GetComponent<menuPause>().IsGamePaused())
            {
                if (HUD.GetComponent<GUIManager>().getHandManager().getEquippedTool() is HeatRay)
                {
                    ((HeatRay)HUD.GetComponent<GUIManager>().getHandManager().getEquippedTool()).stopFiring();
                }
            }
        }

        // Audio control for sprinting
		if (motor.IsSprinting () && motor.movement.velocity.magnitude >= 0.5) {
			if (!GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().Play ();
			}
		}
		else
		{
			GetComponent<AudioSource>().Stop ();
		}
		if (Input.GetButtonDown ("Jump") && motor.grounded)
		{
			AudioSource.PlayClipAtPoint (TyJump, transform.position, 0.15f);
		}

        if (Input.GetButtonDown("DevMode"))
            DevToggle = !DevToggle;

        if (DevToggle && Input.GetButtonDown("DevKill"))
        {
            DevToggle = !DevToggle;
            Kill();
            DevToggle = !DevToggle;
        }

    }

    public bool IsInventoryShowing()
    {
        return inventoryShowing;
    }

    public void ToggleInventoryWindow(InventoryTabManager.InventoryTab tab)
    {
        inventoryShowing = !inventoryShowing;
        inventoryPanel.SetActive(inventoryShowing);
        Cursor.visible = inventoryShowing;
        mainMouseLook.enabled = !inventoryShowing;
        playerMouseLook.enabled = !inventoryShowing;
        if (inventoryShowing)
        {
            HUD.GetComponent<GUIManager>().getInventoryTabManager().Load();
            HUD.GetComponent<GUIManager>().getToolInventoryManager().LoadSelectedTool();
            HUD.GetComponent<GUIManager>().getEquippedToolManager().loadEquippedTool();
            switch (tab)
            {
                case InventoryTabManager.InventoryTab.TOOLS:
                    HUD.GetComponent<GUIManager>().getInventoryTabManager().ChangeTab((int)InventoryTabManager.InventoryTab.TOOLS);
                    break;
                case InventoryTabManager.InventoryTab.COLLECTIBLES:
                    HUD.GetComponent<GUIManager>().getInventoryTabManager().ChangeTab((int)InventoryTabManager.InventoryTab.COLLECTIBLES);
                    break;
                case InventoryTabManager.InventoryTab.NOTES:
                    HUD.GetComponent<GUIManager>().getInventoryTabManager().ChangeTab((int)InventoryTabManager.InventoryTab.NOTES);
                    break;
            }
        } else
        {
            HUD.GetComponent<GUIManager>().getToolInventoryManager().UnloadSelectedTool();
        }
    }
    
    public void Reset()
    {
        transform.position = lastCheckpoint.transform.position;
    }

    public void Kill()
    {
        GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
        FindObjectOfType<menuDeath>().killPlayer();
        if (!DevToggle)
        {
            GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
            FindObjectOfType<menuDeath>().killPlayer();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.GetComponent<DeathOnContact>() != null)
        {
            Kill();
        }
    }
}
