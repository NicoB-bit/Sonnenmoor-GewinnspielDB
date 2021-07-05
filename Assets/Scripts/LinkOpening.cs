using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LinkOpening : MonoBehaviour
{
    public void OpenLink()
    {

        // Application.OpenURL("https://www.sonnenmoor.at/");
        // Application.ExternalEval("window.open('" + "https://www.sonnenmoor.at/" + "', '_blank')");
        OpenLinkJS("https://www.sonnenmoor.at/");
    }
    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);
    public void OpenLinkJS(string url)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             OpenNewTab(url);
#endif
    }
}
