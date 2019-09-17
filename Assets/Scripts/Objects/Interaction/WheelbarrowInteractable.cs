﻿using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelbarrowInteractable : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
    }
}