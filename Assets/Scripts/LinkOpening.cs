using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LinkOpening : MonoBehaviour
{
    public void OpenLink()
    {
        Application.OpenURL("https://www.sonnenmoor.at/");
    }
}
