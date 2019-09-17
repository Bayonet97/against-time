using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimatorController : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
    }

    // Update is called once per frame
    public void Open()
    {
        m_Animator.enabled = false;
        m_Animator.enabled = true;
        m_Animator.Play("OpenGateAnimation");
    }
}
