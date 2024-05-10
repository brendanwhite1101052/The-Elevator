using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public Text timerDisplay;
    public bool runThrough = false;
    public float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(runThrough)
        {
            timerDisplay.text = "Time: " + timer;
            timer += Time.deltaTime;
        }
    }

    void PauseTimer()
    {
        runThrough = false;
    }

    void ResumeTimer()
    {
        runThrough = true;
    }
}
