using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveInputWebGL : MonoBehaviour
{
    [SerializeField]
    GameObject forenameGO;
    [SerializeField]
    GameObject surnameGO;
    [SerializeField]
    GameObject emailGO;

    [SerializeField]
    GameObject[] goArray = new GameObject[3];

    [System.Runtime.InteropServices.DllImport("__Internal")]
    static extern bool IsMobile();

#if UNITY_WEBGL && !UNITY_EDITOR
    void Start()
    {
        WebGLInput.captureAllKeyboardInput = false;
        if(IsMobile())
        {
            //WebGLInput.captureAllKeyboardInput = false;
        }
    }
#endif

    public void ReceiveInputDataWebGL(string value)
    {
        // 3 -> select
        // 4 -> unselect
        if (value.StartsWith("3") || value.StartsWith("4"))
        {
            if (value.StartsWith("3"))
            {
                goArray[int.Parse(value.Substring(1))].GetComponent<InputFieldSmallText>().Select();
            }
            else
            {
                goArray[int.Parse(value.Substring(1))].GetComponent<InputFieldSmallText>().Deselect();
            }
        }
        else
        {
            if (value.StartsWith("0"))
            {
                forenameGO.GetComponent<InputField>().text = value.Substring(1);
            }
            else if (value.StartsWith("1"))
            {
                surnameGO.GetComponent<InputField>().text = value.Substring(1);
            }
            else if (value.StartsWith("2"))
            {
                emailGO.GetComponent<InputField>().text = value.Substring(1);
            }
        }
    }

    public void CreateDivs()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        foreach (GameObject div in goArray)
        {
            div.GetComponent<KeyboardClass>().CreateDiv();
        }
#endif
    }
}
