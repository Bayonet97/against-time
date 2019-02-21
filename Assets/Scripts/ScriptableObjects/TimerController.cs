using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float deathTimer = 60f;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        timerText.text = deathTimer.ToString();
        if (deathTimer < 0)
        {
            timerText.text = "Time's up.";
        }
    }
}
