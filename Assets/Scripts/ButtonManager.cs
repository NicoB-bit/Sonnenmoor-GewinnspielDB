using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public int counterCorrectAnswers;
    int counterQuestionsAnswered = 0;

    string[] correctAnswers = new string[16] { "013", "3", "2", "013", "2", "0", "0", "2", "13", "0123", "1", "12", "12", "023", "2", "0123" };
    int[] answersPressed = new int[4] { 0, 0, 0, 0 };
    string[] questions = new string[16] { "Welche Bestandteile findet man im Moor?",
                                            "Wieviele wertvolle Kräutersubstanzen enthält hochwertiges Moor?",
                                            "Was sind Huminsäuren, die auch entzündungshemmend wirken?",
                                            "Welche besonderen Eigenschaften haben Huminsäuren?",
                                            "Wie alt ist Europas hochwertigstes Moor in Salzburg/Leopoldskron?",
                                            "Ist Moor vegan?", "Kann man Moor trinken?",
                                            "Wie wird hochwertiges Moor noch genannt?",
                                            "Auf welche Körperteile wirkt Moor besonders wohltuend?",
                                            "Welche Arten von Moor-Anwendungen gibt es?",
                                            "Kleine Kräuterkunde: Welche Pflanze sehen Sie hier?",
                                            "Welche besonderen Eigenschaften hat Blutwurz?",
                                            "Wie  wird  die  wilde  Malve im Volksmund noch genannt?",
                                            "Welche dieser Kräuter stärken das Immunsystem und wirken antiviral?",
                                            "Wozu verwendet man Lärchenpechsalbe?",
                                            "Welche Kräuter wirken besonders für Mund, Rachen, Hals?" };
    string[,] answers = new string[,] { { "Calcium, Magnesium", "Eisen, Zink", "Silber, Amalgam", "Harze, Aminosäuren" },
                                        { "7", "20", "100", "Über 350" },
                                        { "Art von menschlicher Magensäure.", "Bestandteil von Kräutern zur Abwehr schädlicher Organismen.", "Bestandteil von Moor zur Bindung von toxischen Substanzen.", "Ein Milchsäurebakterium." },
                                        { "Große Oberfläche", "Binden Giftstoffe ähnlich wie Aktivkohle", "Besonders kleine Oberfläche", "Sehr viele freie Bindungsflächen, also OH-Gruppen" },
                                        { "200 Jahre", "1000 Jahre", "8000-10000 Jahre", "1 Million Jahre" },
                                        { "Ja", "Nein", "", "" },
                                        { "Ja", "Nein", "", "" },
                                        { "Weißes Silber", "Braunes Wasser", "Schwarzes Gold", "" },
                                        { "Herz", "Magen", "Prostata", "Darm" },
                                        { "Moorpackungen", "Moorkissen", "Moor zum Baden", "Trinkmoor" },
                                        { "Gundelrebe", "Blutwurz", "Goldrute", "Zinnkraut" },
                                        { "Wirkt Blutungsstillend", "Wirkt in einem Kräuterauszug zur Stärkung der Schleimhäute", "Hoher Anteil an entzündungshemmenden Gerb-und Bitterstoffen.", "Wirkt aufgrund seiner hohen antioxidativen Wirkung stark abführend." },
                                        { "Frauenschuh", "Große Käsepappel", "Rosspappel", "Frauenmantel" },
                                        { "Thymian", "Sauerkraut", "Blutwurz", "Sonnenhut" },
                                        { "Zur Reduktion von Falten an den Augen.", "Zur Behandlung von Wunden.", "Zur Pflege von Muskeln und Nerven im Gesicht, Hals, Rücken.", "Zur Vorbeugung von Sonnenbrand." },
                                        { "Blutwurz", "Süßholzwurzel", "Kamille", "Käsepappel" } };
    string[] numberCorrectAS = new string[4] { "(1 Antwort ist richtig)", "(2 Antworten sind richtig)", "(3 Antworten sind richtig)", "(Mehrere Antworten sind richtig)" };

    [SerializeField]
    Text textCounter;
    [SerializeField]
    Text textQuesiton;
    [SerializeField]
    Text textNumberOfCorrectA;
    [SerializeField]
    TextMeshPro textPointsAchieved;
    [SerializeField]
    TextMeshPro textPointsAchievedPause;

    [SerializeField]
    Sprite buttonSelectedS;
    [SerializeField]
    Sprite buttonUnselectedS;
    [SerializeField]
    Sprite buttonCorrectS;
    [SerializeField]
    Sprite image13S;

    [SerializeField]
    GameObject[] buttonsList = new GameObject[4];
    [SerializeField]
    GameObject nextButtonGO;
    [SerializeField]
    GameObject pauseScreenGO;
    [SerializeField]
    GameObject finishedScreenGO;
    [SerializeField]
    GameObject quizGO;
    [SerializeField]
    GameObject catchClicksGO;
    [SerializeField]
    GameObject imagesGO;
    [SerializeField]
    GameObject imageTopLayoutGO;
    [SerializeField]
    GameObject giveAnswerButtonGO;
    [SerializeField]
    GameObject checkButtonGO;

    [SerializeField]
    SC_LoginSystem SC_LoginSystemO;

    bool secondStage;

    Color blackTextC;

    void Awake()
    {
        ColorUtility.TryParseHtmlString("#5D5D5D", out blackTextC);
    }
    public void ButtonPressed(int identifier)
    {
        var stringAnswers = string.Join("", answersPressed);
        var stringAnswersStripped = stringAnswers.Replace("0", "").ToCharArray();
        if (correctAnswers[counterQuestionsAnswered].Length == 4)
        {
            if (answersPressed[identifier] == 1)
            {
                ChangeButtonState(identifier, false);
                if (stringAnswersStripped.Length == 1)
                {
                    nextButtonGO.GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                ChangeButtonState(identifier, true);
                nextButtonGO.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (answersPressed[identifier] == 1)
            {
                ChangeButtonState(identifier, false);
                ChangeInteractable(true);
            }
            else
            {
                ChangeButtonState(identifier, true);
                if (stringAnswersStripped.Length == correctAnswers[counterQuestionsAnswered].Length - 1)
                {
                    ChangeInteractable(false);
                    nextButtonGO.GetComponent<Button>().interactable = true;
                    ChangeButtonState(identifier, true);
                }
            }
        }
    }
    void ChangeInteractable(bool isInteractable)
    {
        nextButtonGO.GetComponent<Button>().interactable = !isInteractable;
        for (int i = 0; i < 4; i++)
        {
            if (answersPressed[i] == 0)
            {
                buttonsList[i].GetComponent<Button>().interactable = isInteractable;
            }
        }
    }
    void ChangeButtonState(int identifier, bool turnOn)
    {
        if (turnOn)
        {
            answersPressed[identifier] = 1;
            buttonsList[identifier].GetComponent<Image>().sprite = buttonSelectedS;
        }
        else
        {
            answersPressed[identifier] = 0;
            buttonsList[identifier].GetComponent<Image>().sprite = buttonUnselectedS;
        }
    }
    public void CheckButton()
    {
        CountPoints();
        counterQuestionsAnswered++;
        catchClicksGO.SetActive(true);
    }
    void SetButtonColor(int identifier, bool setGreen)
    {
        if (identifier < 4 && setGreen)
        {
            buttonsList[identifier].GetComponent<Image>().sprite = buttonCorrectS;
            buttonsList[identifier].GetComponentInChildren<Text>().color = Color.white;
        }
        if (identifier < 4 && !setGreen)
        {
            if (buttonsList[identifier].activeSelf)
            {
                buttonsList[identifier].GetComponent<FadeOutButton>().FadeOut();
            }
        }
    }
    void ResetValues()
    {
        foreach (GameObject child in buttonsList)
        {
            child.GetComponent<Button>().interactable = true;
            child.GetComponent<Image>().sprite = buttonUnselectedS;
            child.GetComponent<FadeOutButton>().StopAllCoroutines();
            child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            child.GetComponentInChildren<Text>().color = new Color(blackTextC.r, blackTextC.g, blackTextC.b, 1f);
        }
        catchClicksGO.SetActive(false);
        nextButtonGO.GetComponent<Button>().interactable = false;
        answersPressed = new int[4] { 0, 0, 0, 0 };
    }
    void CountPoints()
    {
        char[] correctAnswersSubC = correctAnswers[counterQuestionsAnswered].ToCharArray();
        for (int i = 0; i < 4; i++)
        {
            if (correctAnswers[counterQuestionsAnswered].Contains(i.ToString()))
            {
                SetButtonColor(i, true);
                if (answersPressed[i] == 1)
                {
                    counterCorrectAnswers++;
                }
            }
            else
            {
                SetButtonColor(i, false);
            }
        }
    }
    public void LoadNewQuestion()
    {
        foreach (GameObject child in buttonsList)
        {
            child.GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < 0; i++)
        {
            if (answers[counterCorrectAnswers, i] == "")
            {
                buttonsList[i].SetActive(false);
            }
            else
            {
                buttonsList[i].SetActive(true);
            }
        }
        if (!secondStage)
        {
            textCounter.text = "Frage " + (counterQuestionsAnswered + 1) + "/10";
        }
        else
        {
            textCounter.text = "Frage " + ((counterQuestionsAnswered + 1) - 10) + "/6";
        }
        textQuesiton.text = questions[counterQuestionsAnswered];
        for (int i = 0; i < 4; i++)
        {
            if (answers[counterQuestionsAnswered, i] != "")
            {
                buttonsList[i].SetActive(true);
                buttonsList[i].GetComponentInChildren<Text>().text = answers[counterQuestionsAnswered, i];
            }
            else
            {
                buttonsList[i].SetActive(false);
            }
        }
        textNumberOfCorrectA.text = numberCorrectAS[correctAnswers[counterQuestionsAnswered].Length - 1];
    }
    public void NextButtonPressed()
    {
        if (counterQuestionsAnswered == 10 && secondStage || counterQuestionsAnswered == 12)
        {
            textCounter.text = "Frage " + ((counterQuestionsAnswered + 1) - 10) + "/6";
            gameObject.GetComponent<FadeTextAndImages>().enabled = true;
            if (counterQuestionsAnswered == 12)
            {
                imagesGO.GetComponentInChildren<Image>().sprite = image13S;
                imageTopLayoutGO.transform.GetChild(1).GetComponent<Image>().sprite = image13S;

            }
            imagesGO.SetActive(true);
            buttonsList[0].transform.parent.gameObject.SetActive(false);
            giveAnswerButtonGO.SetActive(true);
            checkButtonGO.SetActive(false);
        }
        if (counterQuestionsAnswered == 11 || counterQuestionsAnswered == 13)
        {
            gameObject.GetComponent<FadeTextAndImages>().StopCoroutine("Fade");
            gameObject.GetComponent<FadeTextAndImages>().Reset();
            gameObject.GetComponent<FadeTextAndImages>().enabled = false;
        }
        else if (counterQuestionsAnswered == 10 && !secondStage)
        {
            pauseScreenGO.SetActive(true);
            textPointsAchievedPause.text = counterCorrectAnswers + "/17 Punkte";
            ResetValues();
            LoadNewQuestion();
            quizGO.SetActive(false);
            secondStage = true;
        }
        else if (counterQuestionsAnswered == 16)
        {
            finishedScreenGO.SetActive(true);
            textPointsAchieved.text = counterCorrectAnswers + "/31 Punkte";
            SC_LoginSystemO.registerPoints = counterCorrectAnswers.ToString();
            quizGO.SetActive(false);
        }
        if (counterQuestionsAnswered != 10 && counterQuestionsAnswered != 16)
        {
            ResetValues();
            LoadNewQuestion();
        }
    }
    public void GiveAnswers()
    {
        gameObject.GetComponent<FadeTextAndImages>().StartCoroutine("Fade");
        imagesGO.SetActive(false);
        buttonsList[0].transform.parent.gameObject.SetActive(true);
        checkButtonGO.SetActive(true);
    }
}