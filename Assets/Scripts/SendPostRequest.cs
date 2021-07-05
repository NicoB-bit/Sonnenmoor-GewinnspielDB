using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendPostRequest : MonoBehaviour
{
    int points = 0;
   
    public void SendPostRequestPressed()
    {
        points = GetComponent<ButtonManager>().counterCorrectAnswers;
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("fieldPoints", "points=" + points.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://my-json-server.typicode.com/typicode/demo/posts", form))
        {
            yield return www.SendWebRequest();
            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}