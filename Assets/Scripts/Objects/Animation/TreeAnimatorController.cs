using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimatorController : MonoBehaviour
{
    [SerializeField]
    private GameObject fallenLog;

    Animator m_Animator;

    void Start()
    {
        fallenLog.SetActive(false);
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
        m_Animator.GetComponent<Animator>().enabled = true;
        m_Animator.Play("MovingTreeAnimation");
    }

    public void Fall()
    {
        m_Animator.GetComponent<Animator>().enabled = false;
        m_Animator.GetComponent<Animator>().enabled = true;
        m_Animator.Play("FallingTreeAnimation");
    }

    public void DeleteTree()
    {
        this.gameObject.SetActive(false);
        fallenLog.SetActive(true);
    }
}
