using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ValidateInputs : MonoBehaviour
{
    [SerializeField]
    InputField forenameIF;
    [SerializeField]
    InputField surnameIF;
    [SerializeField]
    InputField emailIF;

    [SerializeField]
    Button registerButton;

    bool forenameValid;
    bool surnameValid;
    bool emailValid;

    bool conditionsOfParticipation;
    public bool newsletter;

    public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    public const string MatchName =
           @"([a-zA-Z])";


    public void StringChanged(int identifier)
    {
        if (identifier == 2)
        {
            string email = emailIF.text;
            if (VerifyEmailAddress(email))
            {
                emailValid = true;
            }
            else emailValid = false;
        }
        else
        {
            if (identifier == 0)
            {
                string forename = forenameIF.text;
                if (VerifyName(forename))
                {
                    forenameValid = true;
                }
                else forenameValid = false;

            }
            else
            {
                string surname = surnameIF.text;
                if (VerifyName(surname))
                {
                    surnameValid = true;
                }
                else surnameValid = false;
            }
        }
        CheckIfFinished();
    }
    bool VerifyEmailAddress(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }
    bool VerifyName(string name)
    {
        if (name != null && name.Length >= 3) return Regex.IsMatch(name, MatchName);
        else return false;
    }

    public void CheckboxChanged(bool isNewsletter)
    {
        if (isNewsletter)
            newsletter = !newsletter;
        else
            conditionsOfParticipation = !conditionsOfParticipation;
        CheckIfFinished();
    }

    void CheckIfFinished()
    {
        if (emailValid && forenameValid && surnameValid && conditionsOfParticipation)
        {
            registerButton.interactable = true;
        }
        else registerButton.interactable = false;
    }

}
