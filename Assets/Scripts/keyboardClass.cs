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
    private static extern void createRect(string x, string y, string height, string width);

    void Start()
    {
        Rect rectPixel = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), transform.parent.parent.parent.GetComponent<Canvas>());
        string x = rectPixel.x.ToString() + "px";
        string y = rectPixel.y.ToString() + "px";
        string height = rectPixel.height.ToString() + "px";
        string width = rectPixel.width.ToString() + "px";
        createRect(x, y, height, width);
    }

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
