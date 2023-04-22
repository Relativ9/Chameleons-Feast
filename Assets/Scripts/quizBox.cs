//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class quizBox : MonoBehaviour
////{
////    [SerializeField]
////    private InputField answerInput;

////    public GameObject quizGiver;
////    public GameObject quizBoxText;
////    public GameObject cameraBase;
////    public GameObject tpCamera;
////    public GameObject firstQuizBox;
////    public GameObject moreApplesPrefab;
////    public GameObject firstQuizBoxPrefab;

////    public Button Exit;
////    public Button Answer;

////    public Text quizText;

////    public bool correctAnswer;
////    public bool quizOpen;

////    public Transform Canvas;

////    private void Start()
////    {
////        quizOpen = false;
////        correctAnswer = false;
////        quizBoxText = GameObject.Find("quizText");
////        cameraBase = GameObject.Find("Camera Base");
////        tpCamera = GameObject.Find("Main Camera");
////        quizGiver = GameObject.Find("Sheep");
////        quizText = quizBoxText.GetComponent<Text>();
////        firstQuizBox = GameObject.Find("firstQuizBox");

////        Exit.onClick.AddListener(closeUI);
////        //Answer.onClick.AddListener(checkAnswer);

////        moreTokens();

////    }
////    void Update()
////    {


////    }

////    private void Awake()
////    {
////        //answerInput = GameObject.Find("Quizanswer").GetComponent<InputField>();
////    }


////    public void getInput(string guess)
////    {
////        Debug.Log("You Entered " + guess);
////        answerInput.text = "";
        
////        if(guess == "Apfel")
////        {
////            correctAnswer = true;
////            Debug.Log("Correct Answer!");
////            quizText.text = "Bine, ați ghicit corect și acum puteți continua!";
////        } else
////        {
////            correctAnswer = false;
////        }
////    }

////    public void closeUI()
////    {
////        Object.Destroy(firstQuizBox);
////    }


////    public void moreTokens()
////    {
////        if (tpCamera.GetComponent<TargetScript>().quizMenu == true)
////        { 
////            if (tpCamera.GetComponent<TargetScript>().tokensCollected <= 3) 
////        {
            
////            GameObject firstQuizBox = Instantiate(firstQuizBoxPrefab);
////            firstQuizBox.transform.SetParent(Canvas, worldPositionStays: false);
////            GameObject moreApples = Instantiate(moreApplesPrefab);
////            moreApples.transform.SetParent(Canvas, worldPositionStays: false);
////            quizText.text = "Bună Aventurier, îmi pare rău, dar nu mâncați destule mere, mâncați mai mult și reveniți!";

////            } else
////        {
////                GameObject firstQuizBox = Instantiate(firstQuizBoxPrefab);
////                firstQuizBox.transform.SetParent(Canvas, worldPositionStays: false);
////                quizText.text = "Bună Aventurier, să mă treci insistă să mă înveți ce înseamnă cuvântul german despre măr!";
////        }
////        }
////    }
////}
