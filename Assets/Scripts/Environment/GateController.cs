using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Collider gateCollider;
    public bool isOpen = false;
    int rotationAngle;
    int closedAngle;
    int openAngle;
    bool playerInRange = false;

    private void Start()
    {
        closedAngle = (int)this.gameObject.transform.eulerAngles.y;
        openAngle = closedAngle + 100;
        if (!isOpen)
            rotationAngle = closedAngle;
        else
            rotationAngle = openAngle;
    }

    private void Update()
    {
        if (isOpen)
        {
            if (rotationAngle < openAngle)
            {
                rotationAngle++;
            }
        }
        else if (!isOpen)
        {
            if (rotationAngle > closedAngle)
            {
                rotationAngle--;
            }
        }
        this.gameObject.transform.eulerAngles = new Vector3(0, rotationAngle, 0);

        if (playerInRange == true && Input.GetKey(KeyCode.E))
        {
            openGate();
        }
    }

    public void openGate()
    {
        isOpen = true;
    }
    public void closeGate()
    {
        isOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something entered");
        if (other.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("Player in range of the gate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("Player left the range of the gate");
        }
    }
}
