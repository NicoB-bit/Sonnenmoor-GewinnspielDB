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
        // bottom left -> top left -> top right -> bottom right
        Vector3[] v = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(v);
        Vector3 screenPosbl = Camera.main.WorldToScreenPoint(v[0]);
        Vector3 screenPostl = Camera.main.WorldToScreenPoint(v[1]);
        Vector3 screenPostr = Camera.main.WorldToScreenPoint(v[2]);
        Vector3 screenPosbr = Camera.main.WorldToScreenPoint(v[3]);
        /*Rect rectPixel = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), transform.parent.parent.parent.GetComponent<Canvas>());
        string x = rectPixel.left.ToString() + "px";
        string y = rectPixel.top.ToString() + "px";
        string height = rectPixel.height.ToString() + "px";
        string width = rectPixel.width.ToString() + "px";*/
        string x = screenPostl.x.ToString() + "px";
        string y = (Screen.height - screenPostr.y).ToString() + "px";
        string height = (screenPostr.y - screenPosbr.y).ToString() + "px";
        string width = (screenPostr.x - screenPostl.x).ToString() + "px";
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
