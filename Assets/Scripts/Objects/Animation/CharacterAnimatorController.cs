using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    private Rigidbody _characterRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _characterRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterRigidBody.IsSleeping())
        {
            m_Animator.Play("IdleAnimation");
        }
        else
        {
            m_Animator.Play("WalkingAnimation");
        }
    }
}
