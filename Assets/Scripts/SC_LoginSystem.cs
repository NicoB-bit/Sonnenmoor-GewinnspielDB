using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class SC_LoginSystem : MonoBehaviour
{

    string registerEmail = "";
    string registerUsername = "";
    public string registerPoints = "";
    string errorMessage = "";

    //string rootURL = "https://sonnenmoor.000webhostapp.com/"; //Path where php files are located
    string rootURL = "https://gewinnspiel.sonnenmoor.at/Register/"; //Path where php files are located

    [SerializeField]
    GameObject emailGO;
    [SerializeField]
    GameObject forenameGO;
    [SerializeField]
    GameObject surnameGO;
    [SerializeField]
    GameObject newsletterGO;
    [SerializeField]
    GameObject successGO;
    [SerializeField]
    GameObject websiteButtonGO;

    string[] errorMessages = new string[5] { "Herzlichen Glückwunsch! Sie nehmen am Gewinnspiel teil!", "Leider hat etwas nicht funktioniert! Bitte versuchen Sie es später erneut!", "Diese Email-Adresse ist bereits registriert!", "Bitte überprüfen Sie Ihre Internetverbindung und versuchen Sie es später erneut!", "Bitte warten Sie einen Moment..." };

    [DllImport("__Internal")]
    private static extern void DestroyDivs();

    [DllImport("__Internal")]
    private static extern bool IsMobile();
    public void DestroyDivsButton()
    {
#if !UNITY_EDITOR
        bool isMobile = IsMobile();
        if(isMobile)
        {
            DestroyDivs();
        }
#endif
    }

    private void Start()
    {
        WebGLInput.captureAllKeyboardInput = false;
    }

    public void RegisterPressed()
    {
        registerEmail = emailGO.GetComponent<InputField>().text;
        if (newsletterGO.GetComponent<Toggle>().isOn)
        {
            registerEmail += "*";
        }
        registerUsername = forenameGO.GetComponent<InputField>().text + " " + surnameGO.GetComponent<InputField>().text;
        StartCoroutine("RegisterEnumerator");
    }

    IEnumerator RegisterEnumerator()
    {
        errorMessage = "";

        WWWForm form = new WWWForm();
        form.AddField("email", registerEmail);
        form.AddField("username", registerUsername);
        form.AddField("points", registerPoints);

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "register.php", form))
        {
            www.timeout = 10;
            Success(4);

            yield return www.SendWebRequest();
            if (www.isHttpError || www.isNetworkError)
            {
                errorMessage = www.error;
                Success(1);
                Debug.Log(errorMessage.ToString());
                if (errorMessage.ToString() == "Request timeout")
                {
                    Success(3);
                }
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.Contains("Success"))
                {
                    Debug.Log("Succesfully registrated!");
                    Success(0);
                    ResetValues();
                }
                else
                {
                    errorMessage = responseText;
                    Debug.Log(errorMessage.ToString());
                    if (errorMessage.ToString() == "User with this email already exist.")
                    {
                        Success(2);
                    }
                    else
                    {
                        Success(1);
                    }
                }
            }
        }
    }

    void Success(int errorMessage)
    {
        successGO.SetActive(true);
        if (errorMessage != 4)
        {
            websiteButtonGO.GetComponent<Button>().interactable = true;
        }
        successGO.GetComponentInChildren<Text>().text = errorMessages[errorMessage];
        emailGO.transform.parent.gameObject.SetActive(false);

    }

    void ResetValues()
    {
        errorMessage = "";
        registerEmail = "";
        registerUsername = "";
        registerPoints = "";
    }


    [DllImport("__Internal")]
    private static extern bool ActivateHTML(string points);
    public void ActivateHTMLPressed()
    {
        ActivateHTML(registerPoints);
    }
}
