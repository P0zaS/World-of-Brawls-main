using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class CheckSchemas : MonoBehaviour
{
   
    void Start()
    {
        var player1 = PlayerInput.all[0];
        var player2 = PlayerInput.all[1];

        // Discard existing assignments.
        player1.user.UnpairDevices();
        player2.user.UnpairDevices();

        // Assign devices and control schemes.
        var gamepadCount = Gamepad.all.Count;
        if (gamepadCount >= 2)
        {
            InputUser.PerformPairingWithDevice(Gamepad.all[0], user: player1.user);
            InputUser.PerformPairingWithDevice(Gamepad.all[1], user: player2.user);

            player1.user.ActivateControlScheme("Gamepad");
            player2.user.ActivateControlScheme("Gamepad");
        }
        else if (gamepadCount == 1)
        {
            InputUser.PerformPairingWithDevice(Gamepad.all[0], user: player1.user);
            InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);

            player1.user.ActivateControlScheme("KeyboardLeft");
            player2.user.ActivateControlScheme("Gamepad");
        }
        else
        {
            InputUser.PerformPairingWithDevice(Keyboard.current, user: player1.user);
            InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);

            player1.user.ActivateControlScheme("KeyboardLeft");
            player2.user.ActivateControlScheme("KeyboardRigth");
        }
    }
}
