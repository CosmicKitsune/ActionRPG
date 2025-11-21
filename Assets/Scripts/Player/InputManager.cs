using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class InputManager : MonoBehaviour
{
    public bool AttackInput { get; private set; }
    public static InputManager instance;
    private PlayerInput playerInput;
    private InputAction attackAction;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();
        attackAction = playerInput.actions["Attack"];
    }

    private void Update()
    {
        AttackInput = attackAction.WasPressedThisFrame();
    }
}
