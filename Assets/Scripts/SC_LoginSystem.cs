using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SC_LoginSystem : MonoBehaviour
{

    string registerEmail = "";
    string registerUsername = "";
    string registerPoints = "8";
    string errorMessage = "";

    //Logged-in user data
    string userName = "";
    string userEmail = "";

    string rootURL = "https://sonnenmoor.000webhostapp.com/"; //Path where php files are located
    bool registrationCompleted;

    [SerializeField]
    GameObject pointsGO;
    [SerializeField]
    GameObject emailGO;
    [SerializeField]
    GameObject nameGO;
    public void RegisterPressed()
    {
        registerEmail = emailGO.GetComponent<InputField>().text;
        registerUsername = nameGO.GetComponent<InputField>().text;
        StartCoroutine("RegisterEnumerator");
    }

    IEnumerator RegisterEnumerator()
    {
        registrationCompleted = false;
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
                Debug.Log(errorMessage.ToString());
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
                {
                    Debug.Log("Succesfully registrated!");
                    ResetValues();
                    registrationCompleted = true;
                }
                else
                {
                    errorMessage = responseText;
                    Debug.Log(errorMessage.ToString());
                }
            }
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
