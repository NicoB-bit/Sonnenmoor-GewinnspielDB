using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using System;

public class KeyboardClass : MonoBehaviour, ISelectHandler
{
    [DllImport("__Internal")]
    private static extern void createRect(string _name, string x, string y, string height, string width);

#if UNITY_WEBGL && !UNITY_EDITOR
    void Start()
    {
        // bottom left -> top left -> top right -> bottom right
        Vector3[] v = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(v);
        Vector3 screenPosbl = Camera.main.WorldToScreenPoint(v[0]);
        Vector3 screenPostl = Camera.main.WorldToScreenPoint(v[1]);
        Vector3 screenPostr = Camera.main.WorldToScreenPoint(v[2]);
        Vector3 screenPosbr = Camera.main.WorldToScreenPoint(v[3]);
        string x = screenPostl.x.ToString() + "px";
        string y = (Screen.height - screenPostr.y).ToString() + "px";
        string height = (screenPostr.y - screenPosbr.y).ToString() + "px";
        string width = (screenPostr.x - screenPostl.x).ToString() + "px";
        //createRect(gameObject.name, x, y, height, width);
    }
#endif
    public void ReceiveInputData(string value)
    {
        gameObject.GetComponent<InputField>().text = value;
    }
    [DllImport("__Internal")]
    private static extern void focusHandleAction(string _name, string _str);
    public void OnSelect(BaseEventData data)
    {
#if UNITY_WEBGL
        try
        {
            focusHandleAction(gameObject.name, gameObject.GetComponent<InputField>().text);
        }
        catch (Exception error) { }
#endif
    }
}
