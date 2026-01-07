using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

/// <summary>
/// 
/// </summary>
public class ValueModule : MonoBehaviour
{
    [Header("Value information")]
    [SerializeField]
    string m_valueName;
    [SerializeField]
    int m_value;
    [SerializeField]
    int m_maxValue;

    [Header("UI references")]
    [SerializeField]
    TextMeshProUGUI m_valueNameTag;
    [SerializeField]
    TextMeshProUGUI m_valueDisplay;

    [Header("Unity Events")]

    [SerializeField]
    UnityEvent<string, int> m_onValueChanged= new UnityEvent<string, int>();


    public void OnValidate()
    {
        UpdateNameTagValue();
    }

    private void UpdateNameTagValue()
    {
        m_valueNameTag.text = m_valueName;
    }

    public void AddValue(bool positive)
    {
        Debug.Log("Call to add value for " + m_valueName + " is pos " + positive);
        if (positive)
        {
            m_value=Mathf.Min(++m_value,m_maxValue);
            
        }
        else
        {
            m_value= Mathf.Max(0,--m_value);
        }
        m_onValueChanged.Invoke(m_valueName, m_value);
        UpdateDisplayValue();
    }

    public void UpdateDisplayValue()
    {
        Debug.Log("Value Change for " + m_valueName + " = " + m_value);
        m_valueDisplay.text = ""+m_value;
    }

}
