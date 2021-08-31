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

    string rootURL = "https://sonnenmoor.000webhostapp.com/"; //Path where php files are located

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

    string[] errorMessages = new string[3] { "", "Leider hat etwas nicht funktioniert! Bitte versuchen Sie es später erneut!", "Diese Email-Adresse ist bereits registriert!" };

    [DllImport("__Internal")]
    private static extern void DestroyDivs();

    public void DestroyDivsButton()
    {
        DestroyDivs();
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
#if UNITY_WEBGL && !UNITY_EDITOR
        DestroyDivs();
#endif
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

            yield return www.SendWebRequest();
            if (www.isHttpError || www.isNetworkError)
            {
                errorMessage = www.error;
                Success(1);
                Debug.Log(errorMessage.ToString());
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
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
        if (errorMessage != 0)
        {
            successGO.GetComponentInChildren<Text>().text = errorMessages[errorMessage];
        }
        emailGO.transform.parent.gameObject.SetActive(false);

    }

    void ResetValues()
    {
        errorMessage = "";
        registerEmail = "";
        registerUsername = "";
        registerPoints = "";
    }
}
