using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTimer : MonoBehaviour
{
    public delegate void TimerReachedMilestone(float timeLeft);
    public static event TimerReachedMilestone OnMileStoneReached;
    public float TimeLeft { get; private set; }
    public float StartTime { private get; set; }

    private bool _paused = false;

    private bool _sixtyReached = false;
    private void Start()
    {
        TimeLeft = StartTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (TimeLeft >= 0 && !_paused)
            TimeLeft -= Time.deltaTime;

        if (TimeLeft <= 60 && !_sixtyReached)
        {
            _sixtyReached = true;
            OnMileStoneReached(60);
        }
    }

    public void PauseTimer()
    {
        OnMileStoneReached(999); // 999 for paused
        _paused = true;
    }

    public void ResumeTimer()
    {
        OnMileStoneReached(1000); // 1000 for unpaused
        _paused = false;
    }
}
