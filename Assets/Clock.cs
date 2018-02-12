using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour {

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool continuous;

    const float degreesPerHour = 30f;
    const float degreesPerMin = 6f;
    const float degreesPerSec = 6f;

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;

        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMin, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSec, 0f);
    }

    // Update is called once per frame
    void UpdateContinuous () {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMin, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSec, 0f);
    }

    private void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }
}
