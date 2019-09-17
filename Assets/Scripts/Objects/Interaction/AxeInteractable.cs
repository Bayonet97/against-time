using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInteractable : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
    }
}
