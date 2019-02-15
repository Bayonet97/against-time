using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Normal Movements Variables
    private float walkSpeed;
    private float curSpeed;
    private float maxSpeed;

   // private CharacterStat plStat;

    void Start()
    {
        //  plStat = GetComponent<CharacterStat>();

        // walkSpeed = (float)(plStat.Speed + (plStat.Agility / 5));
        //  sprintSpeed = walkSpeed + (walkSpeed / 2);
        walkSpeed = 5;
    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}
