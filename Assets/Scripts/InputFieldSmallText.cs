using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldSmallText : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    GameObject smallTextGO;
    GameObject placeholderTextGO;
    private void Awake()
    {
        smallTextGO = transform.Find("TextSmall").gameObject;
        placeholderTextGO = transform.Find("Placeholder").gameObject;
    }
    public void Deselect()
    {
        if (placeholderTextGO.GetComponent<Text>().enabled)
        {
            smallTextGO.SetActive(false);
        }
    }
    public void Select()
    {
        smallTextGO.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (placeholderTextGO.GetComponent<Text>().enabled)
        {
            smallTextGO.SetActive(false);
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        smallTextGO.SetActive(true);
    }
}
