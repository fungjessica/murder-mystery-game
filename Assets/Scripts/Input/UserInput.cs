using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    public bool upPressed { get; private set; }
    public bool downPressed { get; private set; }
    public bool leftPressed { get; private set; }
    public bool rightPressed { get; private set; }
    public bool upReleased { get; private set; }
    public bool downReleased { get; private set; }
    public bool leftReleased { get; private set; }
    public bool rightReleased { get; private set; }

    private PlayerInput playerInput;
    private InputAction upAction;
    private InputAction downAction;
    private InputAction leftAction;
    private InputAction rightAction;

    // Called before Start()
    private void Awake() {
        if (instance == null)
            instance = this;
        
        playerInput = GetComponent<PlayerInput>();

        // Set up input actions
        upAction = playerInput.actions["Up"];
        downAction = playerInput.actions["Down"];
        leftAction = playerInput.actions["Left"];
        rightAction = playerInput.actions["Right"];
    }

    // Update is called once per frame
    private void Update()
    {
        upPressed = upAction.WasPressedThisFrame();
        downPressed = downAction.WasPressedThisFrame();
        leftPressed = leftAction.WasPressedThisFrame();
        rightPressed = rightAction.WasPressedThisFrame();
        upReleased = upAction.WasReleasedThisFrame();
        downReleased = downAction.WasReleasedThisFrame();
        leftReleased = leftAction.WasReleasedThisFrame();
        rightReleased = rightAction.WasReleasedThisFrame();
    }
}
