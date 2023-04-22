using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Button Answer;
    public Button Exit;
    public Button moreApples;
    public Button Thanks;
    public Button tryAgain;

    public GameObject moreApplesImage;
    public GameObject answerImage;
    public GameObject firstQuizBox;
    public GameObject answerField;
    public GameObject tpCamera;
    public GameObject thanksImage;
    public GameObject tryAgainImage;
    public GameObject quizGiver;
    public Slider tokenBar;

    public bool rightAnswer;
    public bool attempted = false;
    public bool quizOpened = false;
    public bool respDisp = false; 

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
        quizText = firstQuizBox.GetComponentInChildren<Text>();
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
        if(answerField.GetComponent<inputAnswer>().correct == true)
        {
            attempted = true;
            rightAnswer = true;
        } else
        {
            attempted = true;
            rightAnswer = false;
        }
    }

    void openQuiz()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu == true && !quizOpened && firstQuizBox.GetComponent<QuizManager>().attempted == false)
            
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
                quizText.text = "Wie sagt man 'apple' auf Deutsch?";
            }


        }
    }

    public void answeredCorrectly()
    {
        if (firstQuizBox.GetComponent<QuizManager>().rightAnswer == true && respDisp == false)
        {
            if (firstQuizBox.GetComponent<QuizManager>().attempted == true)
            {
                quizText.text = "Gut gemacht!";
                Debug.Log("Yo 2");
                respDisp = true;
                answerField.SetActive(false);
                answerImage.SetActive(false);
                thanksImage.SetActive(true);
            }
        }
    }

    public void answeredInCorrectly()
    {
        if (firstQuizBox.GetComponent<QuizManager>().rightAnswer == false && respDisp == false)
        {
            if (firstQuizBox.GetComponent<QuizManager>().attempted == true)
            {
                quizText.text = "Bist du sicher? Try again!";
                Debug.Log("Yo 3");
                respDisp = true;
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
        tpCamera.GetComponent<TargetScript>().quizMenu = false;
        Destroy(firstQuizBox);

    }

    public void closeQuizSuccess()
    {
        tpCamera.GetComponent<TargetScript>().quizMenu = false;
        Destroy(firstQuizBox);
        quizGiver = tpCamera.GetComponent<TargetScript>().quizGiver;
        Destroy(quizGiver);
    }
}
