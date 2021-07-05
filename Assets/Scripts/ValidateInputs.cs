using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ValidateInputs : MonoBehaviour
{
    [SerializeField]
    InputField nameIF;
    [SerializeField]
    InputField emailIF;

    [SerializeField]
    Button registerButton;

    bool nameValid;
    bool emailValid;

    bool result;

    public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    public const string MatchName =
           @"([a-zA-Z])";
    public void StringChanged()
    {
        string name = nameIF.text;
        string email = emailIF.text;
        if (VerifyName(name))
        {
            nameValid = true;
        }
        else nameValid = false;
        if (VerifyEmailAddress(email))
        {
            emailValid = true;
        }
        else emailValid = false;
        if (emailValid && nameValid)
        {
            registerButton.interactable = true;
        }
        else registerButton.interactable = false;
    }
    bool VerifyEmailAddress(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }
    bool VerifyName(string name)
    {
        if (name != null && name.Length >= 4) return Regex.IsMatch(name, MatchName);
        else return false;
    }
}
