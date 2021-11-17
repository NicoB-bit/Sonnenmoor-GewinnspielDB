using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class SC_LoginSystem : MonoBehaviour
{
    public string registerPoints = "";

    private void Awake()
    {
        WebGLInput.captureAllKeyboardInput = false;
    }

    [DllImport("__Internal")]
    private static extern bool ActivateHTML(string points);
    public void ActivateHTMLPressed()
    {
        ActivateHTML(registerPoints);
    }
}
