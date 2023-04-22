using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager3 : MonoBehaviour
{
    public Button Answer;
    public Button Exit;
    public Button moreApples;
    public Button Thanks;
    public Button tryAgain;

    public GameObject moreApplesImage;
    public GameObject answerImage;
    public GameObject thirdQuizBox;
    public GameObject answerField;
    public GameObject tpCamera;
    public GameObject thanksImage;
    public GameObject tryAgainImage;
    public GameObject quizGiver;
    public Slider tokenBar;

    public bool rightAnswer3;
    public bool attempted3 = false;
    public bool quizOpened3 = false;
    public bool respDisp3 = false;

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
        quizText = thirdQuizBox.GetComponentInChildren<Text>();
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
        if (answerField.GetComponent<inputAnswer3>().correct3 == true)
        {
            attempted3 = true;
            rightAnswer3 = true;
        }
        else
        {
            attempted3 = true;
            rightAnswer3 = false;
        }
    }

    void openQuiz()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu3 == true && !quizOpened3 && thirdQuizBox.GetComponent<QuizManager3>().attempted3 == false)

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
                quizText.text = "Wie sagt man 'carrot' auf Deutsch?";
            }


        }
    }

    public void answeredCorrectly()
    {
        if (thirdQuizBox.GetComponent<QuizManager3>().rightAnswer3 == true && respDisp3 == false)
        {
            if (thirdQuizBox.GetComponent<QuizManager3>().attempted3 == true)
            {
                quizText.text = "Gut gemacht!";
                Debug.Log("Yo 2");
                respDisp3 = true;
                answerField.SetActive(false);
                answerImage.SetActive(false);
                thanksImage.SetActive(true);
            }
        }
    }

    public void answeredInCorrectly()
    {
        if (thirdQuizBox.GetComponent<QuizManager3>().rightAnswer3 == false && respDisp3 == false)
        {
            if (thirdQuizBox.GetComponent<QuizManager3>().attempted3 == true)
            {
                quizText.text = "Bist du sicher? Try again!";
                Debug.Log("Yo 3");
                respDisp3 = true;
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
        tpCamera.GetComponent<TargetScript>().quizMenu3 = false;
        Destroy(thirdQuizBox);
    }

    public void closeQuizSuccess()
    {
        tpCamera.GetComponent<TargetScript>().quizMenu3 = false;
        Destroy(thirdQuizBox);
        quizGiver = tpCamera.GetComponent<TargetScript>().quizGiver;
        Destroy(quizGiver);
    }
}
