using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{

    public InputField TextField;
    public GameObject EngLayoutBig, SymbLayout;


    public void alphabetFunction(string alphabet)
    {
        if (TextField.name == "InputFieldEmail")
        {
            alphabet = alphabet.ToLower();
        }
        TextField.text = TextField.text + alphabet;
        UpdateChild();
    }


    public void BackSpace()
    {
        if (TextField.text.Length > 0) TextField.text = TextField.text.Remove(TextField.text.Length - 1);
        UpdateChild();
    }

    public void CloseAllLayouts()
    {
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
    }

    public void ShowLayout(GameObject SetLayout)
    {
        CloseAllLayouts();
        SetLayout.SetActive(true);
    }
    void UpdateChild()
    {
        TextField.gameObject.transform.GetChild(3).GetComponent<Text>().text = TextField.text;
    }
}
