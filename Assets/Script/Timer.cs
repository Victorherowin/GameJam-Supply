using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float TimeRemaining = 60.0f;
    public delegate void TimeEndEvt();
    public event TimeEndEvt TimeEnd;

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (TimeRemaining <= 0.0f)
        {
            if (TimeEnd != null)
                TimeEnd();
        }
        else
        {
            TimeRemaining -= Time.fixedDeltaTime;
        }
	}
}
