using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.XInput;

public class InputSystemManager : MonoBehaviour
{
    public static InputSystemManager Instance { get; private set; }

    public PlayerInput pInput;

    private void Awake()
    {
        Instance = this;
    }

    public void DeviceLost(PlayerInput playerInput)
    {
        /// Saltar pantalla diciendo que presione cualquier boton de algun control
        Debug.LogWarning("DeviceLost");
    }

    public void ControlsChanged(PlayerInput playerInput)
    {
        Debug.LogWarning("-- ControlsChanged to: --");

        switch (playerInput.currentControlScheme)
        {
            case "Keyboard&Mouse":
                Debug.LogWarning("Keyboard & Mouse");
                break;

            case "Gamepad":
                Debug.LogWarning("Gamepad:");

                switch (playerInput.devices[0])
                {
                    case DualSenseGamepadHID:
                        Debug.LogWarning("° PS5 - DualSenseGamepadHID °");
                        break;

                    case DualShock4GamepadHID:
                        Debug.LogWarning("° PS4 - DualShock4GamepadHID °");
                        break;

                    case DualShock3GamepadHID:
                        Debug.LogWarning("° PS3 - DualShock3GamepadHID °");
                        break;

                    case DualShockGamepad:
                        Debug.LogWarning("° PSx - DualShockGamepad °");
                        break;

                    case SwitchProControllerHID:
                        // Falta por testear
                        Debug.LogWarning("° Switch - Pro Controller °");
                        break;

                    case XInputController:
                        Debug.LogWarning("° Xbox Controller - XInputController °");
                        break;

                    default:
                        Debug.LogWarning("Gamepad no listado");
                        Debug.LogWarning(playerInput.devices[0].name);
                        Debug.LogWarning(playerInput.devices[0].displayName);
                        break;
                }
                break;

            case "Joystick":
                Debug.LogWarning("Joystick:");
                Debug.LogWarning(playerInput.devices[0].displayName);
                /// Joysticks genericos, los botones seran numeros con colores en vez de las letras
                break;

            default:
                break;
        }
    }

    private void Update()
    {
        switch (pInput.currentControlScheme)
        {
            case "Keyboard&Mouse":
                if (Keyboard.current.anyKey.wasPressedThisFrame)
                {
                    for (int i = 0; i < Keyboard.current.allKeys.Count; i++)
                    {
                        if (Keyboard.current.allKeys[i].IsActuated())
                        {
                            Debug.LogWarning(Keyboard.current.allKeys[i].name);
                        }
                    }
                }
                //for (int i = 0; i < Mouse.current.allControls.Count; i++)
                //{
                //    if (Mouse.current.allControls[i].tr())
                //    {
                //        Debug.LogWarning(Mouse.current.allControls[i].displayName);
                //    }
                //}
                break;

            case "Gamepad":
                for (int i = 0; i < Gamepad.current.allControls.Count; i++)
                {
                    if (Gamepad.current.allControls[i].IsActuated())
                    {
                        Debug.LogWarning(Gamepad.current.allControls[i].name);
                    }
                }
                break;

            case "Joystick":
                for (int i = 0; i < Joystick.current.allControls.Count; i++)
                {
                    if (Joystick.current.allControls[i].IsActuated())
                    {
                        Debug.LogWarning(Joystick.current.allControls[i].name);
                    }
                }
                break;
        }
    }
}