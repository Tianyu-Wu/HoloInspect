using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BimData : MonoBehaviour
{
    public string objectName;
    public DateTime plannedStartTime;
    public DateTime plannedEndTime;
    public DateTime actualStartTime;
    public DateTime actualEndTime;
    public float currentProgress;
    public bool isDelayed;
    public float budget;
    public float actualExpense;
    public string projectManager;
    public int status;
}
