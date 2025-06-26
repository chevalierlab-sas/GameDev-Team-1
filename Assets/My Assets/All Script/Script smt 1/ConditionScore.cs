using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConditionScore : MonoBehaviour
{

    [Header("Variable Settings")]
    public CalculationScore CurrentVariable;
    public bool Activated;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;

    [Header("Condition Settings")]
    public bool ifLessThan;
    public float LessThanCondition;
    public UnityEvent LessThanEvents;

    public bool ifEqual;
    public float EqualCondition;
    public UnityEvent EqualEvents;

    public bool ifBiggerThan;
    public float BiggerThanCondition;
    public UnityEvent BiggerThanEvents;

    public void StartChecking()
    {
        Activated = true;
    }

    public void StopChecking()
    {
        Activated = false;
    }

    void ConditionChecking()
    {
        if (Activated)
        {
            if (ifLessThan)
            {
                if (CurrentVariable.CurrentValue < LessThanCondition)
                {
                    LessThanEvents?.Invoke();
                }
            }
            if (ifEqual)
            {
                if (CurrentVariable.CurrentValue == EqualCondition)
                {
                    EqualEvents?.Invoke();
                }
            }
            if (ifBiggerThan)
            {
                if (CurrentVariable.CurrentValue > BiggerThanCondition)
                {
                    BiggerThanEvents?.Invoke();
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartEvents?.Invoke();
        if (Activated)
        {
            StartChecking();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEvents?.Invoke();
        ConditionChecking();
    }
}

