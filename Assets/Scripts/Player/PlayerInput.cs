using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // The character the player controls
    [SerializeField] private Character playerCharacter;

    // Update is called once per frame
    void Update()
    {
        if (CheckInteractionInput())
            return;
        CheckMovementInput();
    }

    private bool CheckInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerCharacter.Interact();
            return true;
        }
        return false;
    }

    private void CheckMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            bool sprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            
            playerCharacter.Move(sprinting);
        }
    }
}
