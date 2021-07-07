using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using System;

public class keyboardClass : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    string inputValue;

    [DllImport("__Internal")]
    private static extern void focusHandleAction(string _name, string _str, string _inputValue);

    public void ReceiveInputData(string value)
    {
        gameObject.GetComponent<InputField>().text = value;
    }

    public void OnSelect(BaseEventData data)
    {
#if UNITY_WEBGL
        try
        {
            focusHandleAction(gameObject.name, gameObject.GetComponent<InputField>().text, inputValue);
        }
        catch (Exception error) { }
#endif
    }
}
