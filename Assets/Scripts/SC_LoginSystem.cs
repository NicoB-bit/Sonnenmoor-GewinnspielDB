using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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
    GameObject nameGO;
    [SerializeField]
    GameObject successGO;

    string[] errorMessages = new string[3] { "", "Leider hat etwas nicht funktioniert! Bitte versuchen Sie es später erneut!", "Diese Email-Adresse ist bereits registriert!" };
    public void RegisterPressed()
    {
        registerEmail = emailGO.GetComponent<InputField>().text;
        registerUsername = nameGO.GetComponent<InputField>().text;
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
                    if (errorMessage.ToString() == "User with this name already exist.")
                    {
                        Success(2);
                    }
                    if (errorMessage.ToString().Contains("Points are empty"))
                    {
                        Success(1);
                    }
                }
            }
        }
    }

    void Success(int errorMessage)
    {
        if (errorMessage == 0)
        {
            successGO.SetActive(true);
            nameGO.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            successGO.SetActive(true);
            successGO.GetComponentInChildren<Text>().text = errorMessages[errorMessage];
            nameGO.transform.parent.gameObject.SetActive(false);
        }
    }

    void ResetValues()
    {
        errorMessage = "";
        registerEmail = "";
        registerUsername = "";
        registerPoints = "";
    }
}
