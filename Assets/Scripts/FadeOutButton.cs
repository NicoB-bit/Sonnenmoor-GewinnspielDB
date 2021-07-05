using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutButton : MonoBehaviour
{
    Image imageButton;
    Text textText;
    float fadeTime = 0.5f;
    private void Start()
    {
        imageButton = GetComponent<Image>();
        textText = GetComponentInChildren<Text>();
    }
    public void FadeOut()
    {
        StartCoroutine("FadeOutButtonGO");
        StartCoroutine("FadeOutText");
    }
    private YieldInstruction fadeInstruction = new YieldInstruction();
    private YieldInstruction fadeInstructionButton = new YieldInstruction();

    IEnumerator FadeOutText()
    {
        float elapsedTime = 0.0f;
        Color c = textText.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            textText.color = c;
        }
    }
    IEnumerator FadeOutButtonGO()
    {
        float elapsedTime = 0.0f;
        Color c = imageButton.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstructionButton;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            imageButton.color = c;
        }
    }
}
