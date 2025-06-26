using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CalculationInteger : MonoBehaviour
{

    [Header("Current Value")]
    public int CurrentValue;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;

    int TargetInteger;
    bool StartTransfer = false;


    // Start is called before the first frame update
    void Start()
    {
        StartEvents?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEvents?.Invoke();

        if (StartTransfer)
        {
            CurrentValue += 1;
            if (CurrentValue > TargetInteger)
            {
                CurrentValue = TargetInteger;
                StartTransfer = false;
            }
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(transform.gameObject.name, CurrentValue);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            CurrentValue = PlayerPrefs.GetInt(transform.name);
        }
    }

    public void SetCurrentValue(int aValue)
    {
        CurrentValue = aValue;
        if (CurrentValue <= 0) CurrentValue = 0;
    }

    public void AddToCurrentValue(int aValue)
    {
        CurrentValue += aValue;
    }

    public void SubtractFromCurrentValue(int aValue)
    {
        CurrentValue -= aValue;
        if (CurrentValue <= 0) CurrentValue = 0;
    }
    public void WriteTo(Slider aValue)
    {
        aValue.value = CurrentValue;
    }

    public void WriteTo(InputField aValue)
    {
        aValue.text = CurrentValue.ToString();
    }

    public void WriteTo(Text aValue)
    {
        aValue.text = CurrentValue.ToString();
    }

    public void WriteTo(TextMesh aValue)
    {
        aValue.text = CurrentValue.ToString();
    }

    public void TransferToCurrentValue(int aValue)
    {
        TargetInteger = CurrentValue + aValue;
        StartTransfer = true;
        Invoke("ThreeSecond", 3);
    }
    public void ReadFrom(Slider aValue)
    {
        CurrentValue = Mathf.RoundToInt(aValue.value);
    }

    public void ReadFrom(InputField aValue)
    {
        CurrentValue = int.Parse(aValue.text);
    }
    public void ReadFrom(Text aValue)
    {
        CurrentValue = int.Parse(aValue.text);
    }

    public void ReadFrom(TextMesh aValue)
    {
        CurrentValue = int.Parse(aValue.text);
    }
    void ThreeSecond()
    {
        CurrentValue = TargetInteger;
    }
}

