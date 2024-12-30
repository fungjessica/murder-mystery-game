using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebind : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionReference;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateBindingDisplay();
    }

    public void StartRebinding() {
        // null out rebindingOperation
        rebindingOperation?.Cancel();

        // Disable action to prevent issues
        inputActionReference.action.Disable();

        // Function to clean up resources
        void Cleanup() {
            rebindingOperation.Dispose();
            rebindingOperation = null;
        }

        // Rebind config.
        rebindingOperation = inputActionReference.action
                                    .PerformInteractiveRebinding()
                                    .WithCancelingThrough("<Keyboard>/escape")
                                    .WithControlsExcluding("<Mouse>/position")
                                    .WithControlsExcluding("<Mouse>/delta")
                                    .OnCancel(operation => {
                                        inputActionReference.action.Enable();
                                        UpdateBindingDisplay();
                                        Cleanup();
                                    })
                                    .OnComplete(operation => {
                                        inputActionReference.action.Enable();
                                        UpdateBindingDisplay();
                                        Cleanup();
                                    })
                                    .Start();
    }

    private void UpdateBindingDisplay() {
        InputBinding inputBinding = inputActionReference.action.bindings.FirstOrDefault();
        string text = (inputBinding != null) ? inputBinding.effectivePath.Substring(inputBinding.path.LastIndexOf("/") + 1) : "";
        GetComponentInChildren<TextMeshProUGUI>().SetText(text);
    }
}
