using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField]
    GameObject keyboardGO;
    public void ClickedInputField()
    {
        keyboardGO.SetActive(true);
        keyboardGO.GetComponent<KeyboardScript>().TextField = GetComponent<InputField>();
    }
}