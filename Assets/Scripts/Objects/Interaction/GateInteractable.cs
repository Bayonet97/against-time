using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInteractable : InteractableObject
{
    //public Collider gateCollider;
    //public bool isOpen = false;
    //int rotationAngle;
    //int closedAngle;
    //int openAngle;

    private void Start()
    {
        /*closedAngle = (int)this.gameObject.transform.eulerAngles.y;
        openAngle = closedAngle + 100;
        if (!isOpen)
            rotationAngle = closedAngle;
        else
            rotationAngle = openAngle;*/
    }

    public override void Interact(bool hasItem)
    {
        base.Interact(hasItem);
        if (hasItem)
        {  
            GateAnimatorController gateAnimatorController = this.GetComponent<GateAnimatorController>();
            gateAnimatorController.Open();
        }

    }
}
