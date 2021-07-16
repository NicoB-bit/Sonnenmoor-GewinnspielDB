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

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    public void ReceiveInputDataWebGL(string value)
    {
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
}
