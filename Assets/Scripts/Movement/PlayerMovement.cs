using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerObject;

    // Normal Movements Variables
    public float walkSpeed;
    private float curSpeed;
    private float maxSpeed;

    // private CharacterStat plStat;

    void Start()
    {
        //  plStat = GetComponent<CharacterStat>();

        // walkSpeed = (float)(plStat.Speed + (plStat.Agility / 5));
        //  sprintSpeed = walkSpeed + (walkSpeed / 2);
        walkSpeed = 0.5f;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        //    rotatePlayerObjectY(0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        //    rotatePlayerObjectY(270);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
        //    rotatePlayerObjectY(180);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        //    rotatePlayerObjectY(90);
        //}
        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        //{
        //    rotatePlayerObjectY(315);
        //}
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        //{
        //    rotatePlayerObjectY(45);
        //}
        //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        //{
        //    rotatePlayerObjectY(135);
        //}
        //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        //{
        //    rotatePlayerObjectY(225);
        //}
        if (Input.GetKey(KeyCode.LeftShift))
            walkSpeed = 3f;
        else
            walkSpeed = 1f;
    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f), 0,
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

        // Rotate playerObject
        playerObject.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
