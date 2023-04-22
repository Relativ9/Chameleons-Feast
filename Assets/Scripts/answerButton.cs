//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class answerButton : MonoBehaviour
//{
//    public Button answer;
//    public GameObject inputAnswer;
//    public GameObject firstQuizBox;

//    private Text quizText;

//    // Start is called before the first frame update
//    void Start()
//    {

//        answer.onClick.AddListener(checkAnswer);
//        quizText = firstQuizBox.GetComponentInChildren<Text>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void checkAnswer()
//    {
//        if (inputAnswer.GetComponent<inputAnswer>().correct == true)
//        {
//            quizText.text = "Yey well done amigo!"; 

//        } else
//        {
//            quizText.text = "Sorry, that wasn't quite right, try again!";
//        }
//    }

//}
