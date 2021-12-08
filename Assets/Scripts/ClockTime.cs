using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    public GameObject HourHand;
    public GameObject MinuteHand;
    public GameObject SecondHand;

    //时针、秒针、分针步伐角度。
    private const float Hourfactor = 30f;
    private const float Minutefactor = 6f;
    private const float Secondfactor = 6f;

    public bool continuous = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDiscrete();
    }

    // Update is called once per frame
    void Update()
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

    // 逐步方式更新当前时间
    private void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        HourHand.transform.localRotation =
            Quaternion.Euler(time.Hour * Hourfactor,0f, 0f);

        MinuteHand.transform.localRotation =
            Quaternion.Euler(time.Minute * Minutefactor,0f, 0f);

        SecondHand.transform.localRotation =
            Quaternion.Euler(time.Second * Secondfactor,0f, 0f);
    }

    // 持续方式更新当前时间
    private void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        HourHand.transform.localRotation =
            Quaternion.Euler((float)time.TotalHours * Hourfactor,0f,0f);

        MinuteHand.transform.localRotation =
            Quaternion.Euler((float)time.TotalMinutes * Minutefactor,0f,0f);

        SecondHand.transform.localRotation =
            Quaternion.Euler((float)time.TotalSeconds * Secondfactor,0f,0f);
    }
}

