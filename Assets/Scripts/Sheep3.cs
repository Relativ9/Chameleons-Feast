using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep3 : MonoBehaviour
{
    public GameObject tpCamera;

    public GameObject thirdQuizBoxPrefab;

    public Transform Canvas;

    public bool quizOpened3;

    // Start is called before the first frame update
    void Start()
    {
        quizOpened3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        openQuiz();
        if (tpCamera.GetComponent<TargetScript>().quizMenu3 == false)
        {
            quizOpened3 = false;
        }
    }

    void openQuiz()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu3 == true && !quizOpened3)
        {
            quizOpened3 = true;
            GameObject secondQuizBox = Instantiate(thirdQuizBoxPrefab) as GameObject;
            secondQuizBox.transform.SetParent(Canvas, worldPositionStays: false);

        }
    }
}
