using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class ShidoModule : MonoBehaviour
{
    [SerializeField]
    int m_numberOfShido;
    [SerializeField]
    int m_maxShido;
    [SerializeField]
    List<RawImage> m_imageList;
    
    [Header("Color shido")]
    [SerializeField]
    Color m_imageOriginColor;
    [SerializeField]
    Color m_shidoColor;
    [SerializeField]
    Color m_shidoMaxColor;

    
    [Header("Game Object References")]
    [SerializeField]
    GameObject m_squarePrefab;

    [SerializeField]
    Transform m_squareParent;

    [Header("Unity Events")]
    [SerializeField]
    UnityEvent m_onShidoAdded = new UnityEvent();
    [SerializeField]
    UnityEvent m_onShidoRemoved = new UnityEvent();

    [SerializeField]
    UnityEvent m_onHansoukouMake = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitShidoModule();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitShidoModule()
    {
        for(int i = 0; i < m_maxShido; i++)
        {
            GameObject g = Instantiate(m_squarePrefab, m_squareParent);
            RawImage im;
            if(g.TryGetComponent<RawImage>(out im)) 
            {
                m_imageList.Add(im);
            }
            else
            {
                Debug.LogError("Component Image not found in the prefab.\n Please Check the prefab");
            }
            
        }

    }

    public void AddShido()
    {
        Debug.Log("Add Shido call");
        m_numberOfShido++;
        m_numberOfShido= Mathf.Min(m_numberOfShido, m_maxShido);
        if (m_numberOfShido == m_maxShido)
        {
            m_imageList[m_numberOfShido - 1].color = m_shidoMaxColor;
            m_onHansoukouMake.Invoke();
        }
        else
        {
            m_imageList[m_numberOfShido - 1].color = m_shidoColor;
            m_onShidoAdded.Invoke();
        }
    }

    public void RemoveShido()
    {
        Debug.Log("Remove Shido call");
        m_numberOfShido--;
        m_numberOfShido = Mathf.Max(m_numberOfShido, 0);
        m_imageList[m_numberOfShido].color = m_imageOriginColor;
        m_onShidoRemoved.Invoke();
    }
}
