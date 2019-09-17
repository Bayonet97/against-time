using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private Character _character;
    private CharacterInventory _characterInventory;

    public void Start()
    {
        _character = this.GetComponent<Character>();
        _characterInventory = this.GetComponent<CharacterInventory>();
    }

    internal void InteractWithObject(InteractableObject objectOfInteraction)
    {
        CheckSpecificObjectToInteractWith(objectOfInteraction);

        if(objectOfInteraction.TextToShow != "" && objectOfInteraction != null)
            _character.ShowDialogue(objectOfInteraction.TextToShow);
    }

    // TO DO: Change the way the character checks for a specific object to not rely on their name.
    private void CheckSpecificObjectToInteractWith(InteractableObject objectOfInteraction)
    {
        switch (objectOfInteraction)
        {
            case DefaultInteractable di:
                di.Interact();
                break;
            case AxeInteractable ai:
                ai.Interact();
                _characterInventory.ObtainAxe();
                break;
            case KeyInteractable ki:
                ki.Interact();
                _characterInventory.ObtainKey();
                break;
            case TreeInteractable ti:
                ti.Interact(_characterInventory.HasAxe);
                break;
            case WheelbarrowInteractable wbi:
                wbi.Interact();
                _characterInventory.ObtainWheelbarrow();
                break;
            case GateInteractable gi:
                gi.Interact(_characterInventory.HasKey);
                break;
            case BridgeInteractable bi:
                bi.Interact(_characterInventory.WoodAmount);
                if (_characterInventory.WoodAmount > 0)
                    _characterInventory.DeleteWood();
                break;
            case WoodInteractable wi:
                wi.Interact(_characterInventory.HasWheelbarrow);
                if (_characterInventory.HasWheelbarrow)
                    _characterInventory.AddWood();
                break;
            default:
                throw new ArgumentException(
                message: "object interaction is not implemented yet: ", paramName: objectOfInteraction.name);
        }

    }
}
