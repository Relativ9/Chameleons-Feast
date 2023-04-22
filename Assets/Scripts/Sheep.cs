using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheep : MonoBehaviour
{

    public GameObject tpCamera;

    public GameObject firstQuizBoxPrefab;

    public Transform Canvas;

    public bool quizOpened;

    // Start is called before the first frame update
    void Start()
    {
        quizOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        openQuiz();
        if (tpCamera.GetComponent<TargetScript>().quizMenu == false)
        {
            quizOpened = false;
        }
    }

    void openQuiz ()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu == true && !quizOpened)
        {
            quizOpened = true;
            GameObject firstQuizBox = Instantiate(firstQuizBoxPrefab) as GameObject;
            firstQuizBox.transform.SetParent(Canvas, worldPositionStays: false);

        }
    }
}
