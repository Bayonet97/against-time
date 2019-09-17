using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float curSpeed;
    public GameObject CharacterPhysicalObject { private get; set; }

    public void SetSpeed(float speed)
    {
        curSpeed = speed;
    }

      void FixedUpdate()
      {
        // Move senteces
        GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f), 0,
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
        // Rotate playerObject
        if (GetComponent<Rigidbody>().velocity.x != 0 || GetComponent<Rigidbody>().velocity.z != 0)
        {
            CharacterPhysicalObject.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }

      }
}
