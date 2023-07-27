using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private StopWatch stopwatch;
    public TimeSpan timeElapsed { get; private set; }
    
    void Start()
    {
        stopwatch = new StopWatch();
        stopwatch.Start();
    }

    
    void Update()
    {
        timeElapsed = stopwatch.ElapsedMilliseconds;
    }
}
