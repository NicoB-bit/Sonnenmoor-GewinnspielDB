using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
{
    [SerializeField]
    GameObject imageGO;
    [SerializeField]
    GameObject managerGO;
    [SerializeField]
    GameObject panelGO;

    [SerializeField]
    Sprite scaleS;
    [SerializeField]
    Sprite unscaleS;

    [SerializeField]
    AnimationClip scaleDownImgAnimC;
    [SerializeField]
    AnimationClip scaleUpImgAnimC;

    [SerializeField]
    AnimationClip scaleDownPanelAnimC;
    [SerializeField]
    AnimationClip scaleUpPanelAnimC;

    bool scaledUp;
    public void ScaleImageGO()
    {
        managerGO.GetComponent<FadeTextAndImages>().imageScaledUp = !scaledUp;
        if (!scaledUp)
        {
            imageGO.GetComponent<Animation>().clip = scaleUpImgAnimC;
            imageGO.GetComponent<Animation>().Play();
            imageGO.transform.GetChild(0).GetComponentInChildren<Image>().sprite = unscaleS;
            Debug.Log(panelGO.GetComponent<Animation>().clip.name);
            panelGO.GetComponent<Animation>().clip = scaleUpPanelAnimC;
            panelGO.GetComponent<Animation>().Play();
            managerGO.GetComponent<FadeTextAndImages>().StopAllCoroutines();
        }
        else
        {
            imageGO.GetComponent<Animation>().clip = scaleDownImgAnimC;
            imageGO.GetComponent<Animation>().Play();
            imageGO.transform.GetChild(0).GetComponentInChildren<Image>().sprite = scaleS;
            managerGO.GetComponent<FadeTextAndImages>().StartCoroutine("FadeOutImg");
            panelGO.GetComponent<Animation>().clip = scaleDownPanelAnimC;
            panelGO.GetComponent<Animation>().Play();
        }
        scaledUp = !scaledUp;
    }
}