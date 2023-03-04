using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    private PlayerInputs playerInputs;

    private void Awake()
    {
        if(_instance!= null && _instance!= this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        playerInputs = new PlayerInputs();
        Cursor.visible = false;
        playerInputs.CharacterControl.Movement.performed += ctx => CheckKeyPress();
        playerInputs.CharacterControl.Interact.performed += interactCtx => Interact();

    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        UnbindKeyboardEvent();
        UnbindCollectEvent();
        playerInputs.Disable();
    }

    public Vector2 GetPlayerInputs()
    {
        return playerInputs.CharacterControl.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInputs.CharacterControl.CameraMovement.ReadValue<Vector2>();
    }
    public void CheckKeyPress()
    {
        if(TutorialManager.Instance.IsTutorialActive())
        {
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().y > 0.0f)
            {
                TutorialManager.Instance.PressW();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().y < 0.0f)
            {
                TutorialManager.Instance.PressS();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().x > 0.0f)
            {
                TutorialManager.Instance.PressD();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().x < 0.0f)
            {
                TutorialManager.Instance.PressA();
            }
        }
    }

    public void UnbindKeyboardEvent()
    {
        playerInputs.CharacterControl.Movement.performed -= cnt => CheckKeyPress();
    }

    private void UnbindCollectEvent()
    {
        playerInputs.CharacterControl.Interact.performed -= interactCtx => Interact();

    }

    public void Interact()
    {
        if (!DialogueManager.Instance.isDialoguePlaying)
        {
            if (CameraRaycast.Instance.isHitCollectable)
            {
                PlayerInteraction.Instance.CollectObject();
            }
            else if (CameraRaycast.Instance.isHitNPC)
            {
                if (QuestManager.Instance.activeQuest==null|| QuestManager.Instance.activeQuest.Name.Equals(""))
                {
                    DialogueManager.Instance.EnterDialogueMode(CameraRaycast.Instance.objectHit.GetComponent<NPCDialog>().GetNPCDialog());
                }
                else
                {
                    DialogueManager.Instance.EvaluateDialog(CameraRaycast.Instance.objectHit.transform);
                }

            }
        }
        else DialogueManager.Instance.ContinueStory();

    }

}
