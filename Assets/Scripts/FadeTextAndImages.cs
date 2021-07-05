using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTextAndImages : MonoBehaviour
{
    [SerializeField]
    GameObject topLayoutTextGO;
    [SerializeField]
    GameObject topLayoutImgGO;

    [SerializeField]
    AnimationClip scaleDownAnimC;
    [SerializeField]
    AnimationClip scaleUpAnimC;

    public bool imageScaledUp;

    private void Update()
    {
        if (imageScaledUp)
        {
            StopCoroutine("Fade");
        }
    }
    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(4f);
        topLayoutTextGO.GetComponent<Animation>().clip = scaleDownAnimC;
        topLayoutImgGO.GetComponent<Animation>().clip = scaleUpAnimC;
        topLayoutTextGO.GetComponent<Animation>().Play();
        topLayoutImgGO.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(4f);
        topLayoutTextGO.GetComponent<Animation>().clip = scaleUpAnimC;
        topLayoutImgGO.GetComponent<Animation>().clip = scaleDownAnimC;
        topLayoutTextGO.GetComponent<Animation>().Play();
        topLayoutImgGO.GetComponent<Animation>().Play();
        StartCoroutine("Fade");

    }
    public IEnumerator FadeOutImg()
    {
        yield return new WaitForSeconds(4f);
        topLayoutTextGO.GetComponent<Animation>().clip = scaleUpAnimC;
        topLayoutImgGO.GetComponent<Animation>().clip = scaleDownAnimC;
        topLayoutTextGO.GetComponent<Animation>().Play();
        topLayoutImgGO.GetComponent<Animation>().Play();
        StartCoroutine("Fade");
    }
    public void Reset()
    {
        topLayoutTextGO.transform.localScale = new Vector3(1f, 1f, 1f);
        topLayoutImgGO.transform.localScale = new Vector3(0f, 0f, 0f);
        topLayoutTextGO.GetComponent<Animation>().Stop();
        topLayoutImgGO.GetComponent<Animation>().Stop();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
