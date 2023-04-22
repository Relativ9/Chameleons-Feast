using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager2 : MonoBehaviour
{
    public Button Answer;
    public Button Exit;
    public Button moreApples;
    public Button Thanks;
    public Button tryAgain;

    public GameObject moreApplesImage;
    public GameObject answerImage;
    public GameObject secondQuizBox;
    public GameObject answerField;
    public GameObject tpCamera;
    public GameObject thanksImage;
    public GameObject tryAgainImage;
    public GameObject quizGiver;
    public Slider tokenBar;

    public bool rightAnswer2;
    public bool attempted2 = false;
    public bool quizOpened2 = false;
    public bool respDisp2 = false;

    private Text quizText;
    private Text successText;


    // Start is called before the first frame update
    void Start()
    {
        moreApples.onClick.AddListener(closeQuiz);
        tryAgain.onClick.AddListener(closeQuiz);
        Thanks.onClick.AddListener(closeQuizSuccess);
        Exit.onClick.AddListener(closeQuiz);
        Answer.onClick.AddListener(checkAnswer);
        tpCamera = GameObject.Find("Main Camera");
        tokenBar = FindObjectOfType<Slider>();
        quizText = secondQuizBox.GetComponentInChildren<Text>();
        answerField.SetActive(false);
        answerImage.SetActive(false);
        moreApplesImage.SetActive(false);
        thanksImage.SetActive(false);
        tryAgainImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        openQuiz();
        answeredCorrectly();
        answeredInCorrectly();
    }

    public void checkAnswer()
    {
        if (answerField.GetComponent<inputAnswer2>().correct2 == true)
        {
            attempted2 = true;
            rightAnswer2 = true;
        }
        else
        {
            attempted2 = true;
            rightAnswer2 = false;
        }
    }

    void openQuiz()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu2 == true && !quizOpened2 && secondQuizBox.GetComponent<QuizManager2>().attempted2 == false)

        {
            if (tpCamera.GetComponent<TargetScript>().tokensCollected < 3)
            {
                moreApplesImage.SetActive(true);
                quizText.text = "Hallo Abenteurer! You don't have enough fruits or vegetables! Go collect more!";
            }
            else if (tpCamera.GetComponent<TargetScript>().tokensCollected >= 3)
            {
                answerField.SetActive(true);
                answerImage.SetActive(true);
                quizText.text = "Wie sagt man 'pear' auf Deutsch?";
            }


        }
    }

    public void answeredCorrectly()
    {
        if (secondQuizBox.GetComponent<QuizManager2>().rightAnswer2 == true && respDisp2 == false)
        {
            if (secondQuizBox.GetComponent<QuizManager2>().attempted2 == true)
            {
                quizText.text = "Gut gemacht!";
                Debug.Log("Yo 2");
                respDisp2 = true;
                answerField.SetActive(false);
                answerImage.SetActive(false);
                thanksImage.SetActive(true);
            }
        }
    }

    public void answeredInCorrectly()
    {
        if (secondQuizBox.GetComponent<QuizManager2>().rightAnswer2 == false && respDisp2 == false)
        {
            if (secondQuizBox.GetComponent<QuizManager2>().attempted2 == true)
            {
                quizText.text = "Bist du sicher? Try again!";
                Debug.Log("Yo 3");
                respDisp2 = true;
                answerField.SetActive(false);
                answerImage.SetActive(false);
                tryAgainImage.SetActive(true);
                tpCamera.GetComponent<TargetScript>().tokensCollected = tpCamera.GetComponent<TargetScript>().tokensCollected - 3;
                tokenBar.value = tpCamera.GetComponent<TargetScript>().tokensCollected;

            }

        }
    }

    public void closeQuiz()
    {
        tpCamera.GetComponent<TargetScript>().quizMenu2 = false;
        Destroy(secondQuizBox);
    }

    public void closeQuizSuccess()
    {
        tpCamera.GetComponent<TargetScript>().quizMenu2 = false;
        Destroy(secondQuizBox);
        quizGiver = tpCamera.GetComponent<TargetScript>().quizGiver;
        Destroy(quizGiver);
    }
}
