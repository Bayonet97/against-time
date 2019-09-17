using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    public Text TimerText;
    public Image TimerImage;
    private string _timerText;
    [SerializeField] private Character _character;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = Math.Round(_character.GetTimeLeft(), 0).ToString();
        TimerText.color = new Color(0.6509434f, 0.6509434f, 0.6509434f);
        TimerImage.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (_character.GetTimeLeft() > 10)
        {
            _timerText = Math.Round(_character.GetTimeLeft(), 0).ToString();
        }
        else if (_character.GetTimeLeft() >= 0)
        {
            _timerText = Math.Round(_character.GetTimeLeft(), 1).ToString();
            if (_timerText.Length == 1)
            {
                _timerText = _timerText + ".0";
            }
        }
        else
        {
            _timerText = "Time's Up.";
            TimerText.fontSize = 50;
            TimerText.transform.localPosition = new Vector3(0, 0, 0);
            TimerText.color = Color.white;
            TimerImage.color = Color.black;
            ToMainMenu();
        }
        TimerText.text = _timerText;
    }

    private void ToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
