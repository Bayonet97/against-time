using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Character Components 
    [SerializeField] private GameObject _characterPhysicalObject;
    [SerializeField] private float _interactionRange = 0.5f;
    private CharacterMovement _characterMovement;
    private CharacterTimer _characterTimer;
    private CharacterInteraction _characterInteraction;
    private CharacterInventory _characterInventory;
    private CharacterDialogue _characterDialogue;

    public bool AllowSprinting = false;

    // Normal Movements Variables
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
                     private float _curSpeed;
    // Start time for death timer
    [SerializeField] private float _startTime;

    void Start()
    {
        // Add components to character
        _characterMovement = gameObject.AddComponent<CharacterMovement>() as CharacterMovement;
        _characterTimer = gameObject.AddComponent<CharacterTimer>() as CharacterTimer;
        _characterInteraction = gameObject.AddComponent<CharacterInteraction>() as CharacterInteraction;
        _characterInventory = gameObject.AddComponent<CharacterInventory>() as CharacterInventory;
        _characterDialogue = gameObject.AddComponent<CharacterDialogue>() as CharacterDialogue;
        // Assign default values
        _characterMovement.CharacterPhysicalObject = _characterPhysicalObject;
        _characterTimer.StartTime = _startTime;
    }

    public decimal GetTimeLeft()
    {
        if(_characterTimer == null)
            _characterTimer = gameObject.AddComponent<CharacterTimer>() as CharacterTimer;

        return (decimal)_characterTimer.TimeLeft;
    }
    public void ChangePausedState(bool paused)
    {
        if(_characterTimer == null)
            _characterTimer = gameObject.AddComponent<CharacterTimer>() as CharacterTimer;
        if(_characterMovement == null)
            _characterMovement = gameObject.AddComponent<CharacterMovement>() as CharacterMovement;

        if (paused)
        {
            _characterMovement.enabled = false;
            _characterMovement.SetSpeed(0);
            _characterTimer.PauseTimer();
        }
        else if(!paused)
        {
            _characterMovement.enabled = true;
            _characterTimer.ResumeTimer();
        }

    }

    public void Interact()
    {
        if(_characterDialogue == null)
            _characterDialogue = gameObject.AddComponent<CharacterDialogue>() as CharacterDialogue;

        if (_characterDialogue.GetDialogueState() != DialogueState.Disabled)
        {
            _characterDialogue.NextState();
        }
        else
        {
            RaycastHit objectInRange;
            if (Physics.Raycast(transform.position, _characterPhysicalObject.transform.forward, out objectInRange, _interactionRange))
            {
                if (objectInRange.collider.gameObject.GetComponent<InteractableObject>())
                    _characterInteraction.InteractWithObject(objectInRange.collider.gameObject.GetComponent<InteractableObject>());
            }
        }
          
    }

    public void Move(bool sprinting)
    {
        if(_characterMovement == null)
            _characterMovement = gameObject.AddComponent<CharacterMovement>() as CharacterMovement;

        if (AllowSprinting) // With Sprinting
        {           
            if (sprinting)
                _characterMovement.SetSpeed(_sprintSpeed);
            else
                _characterMovement.SetSpeed(_walkSpeed);
        }
        else // Without Sprinting
        {
            _characterMovement.SetSpeed(_walkSpeed);
        }
    }

    public void ShowDialogue(string newDialogueText)
    {
        if(_characterDialogue == null)
        {
            _characterDialogue = gameObject.AddComponent<CharacterDialogue>() as CharacterDialogue;
        }
        _characterDialogue.OpenDialogue(newDialogueText);
    }
 
}
