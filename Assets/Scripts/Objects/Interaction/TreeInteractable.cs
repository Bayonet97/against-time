using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : InteractableObject
{
    public override void Interact(bool hasAxe)
    {
        base.Interact(hasAxe);
        if (hasAxe)
        {
       //     UpdateTextToShow("You chop down the tree, that wasn't that hard.");
            TreeAnimatorController treeAnimatorController = this.GetComponent<TreeAnimatorController>();
            treeAnimatorController.Fall();
        }
    }
}
