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
    public void ReceiveInputDataWebGL(string value)
    {
        emailGO.GetComponent<InputField>().text = value;
        if (value.StartsWith("1"))
        {
            forenameGO.GetComponent<InputField>().text = value;
        }
        else if (value.StartsWith("2"))
        {
            surnameGO.GetComponent<InputField>().text = value;
        }
        else
        {
            emailGO.GetComponent<InputField>().text = value;
        }
    }
}
