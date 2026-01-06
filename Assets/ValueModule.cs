using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;
using Unity.Mathematics;

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
        if (positive)
        {
            m_value++;
        }
        else
        {
            m_value= math.max(0,m_value--);
        }
        m_onValueChanged.Invoke(m_valueName, m_value);
    }

    public void UpdateDisplayValue()
    {
        m_valueDisplay.text = m_value.ToString();
    }

}
