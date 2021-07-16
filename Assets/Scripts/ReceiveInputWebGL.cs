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

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    public void ReceiveInputDataWebGL(string value)
    {
        if (value.StartsWith("0"))
        {
            forenameGO.GetComponent<InputField>().text = value.Substring(1);
            SetCaretPosition(forenameGO.GetComponent<InputField>());
        }
        else if (value.StartsWith("1"))
        {
            surnameGO.GetComponent<InputField>().text = value.Substring(1);
            SetCaretPosition(surnameGO.GetComponent<InputField>());
        }
        else
        {
            emailGO.GetComponent<InputField>().text = value.Substring(1);
            SetCaretPosition(emailGO.GetComponent<InputField>());
        }
    }
    void SetCaretPosition(InputField ifO)
    {
        int caretIndex = ifO.text.Length;
        StartCoroutine(SetPosition());
        IEnumerator SetPosition()

        {
            int width = ifO.caretWidth;
            ifO.caretWidth = 0;
            yield return new WaitForEndOfFrame();
            ifO.caretWidth = width;
            ifO.caretPosition = caretIndex;
        }
    }
}
