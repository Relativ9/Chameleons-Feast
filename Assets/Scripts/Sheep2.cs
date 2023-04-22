using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheep2 : MonoBehaviour
{
    public GameObject tpCamera;

    public GameObject secondQuizBoxPrefab;

    public Transform Canvas;

    public bool quizOpened2;

    // Start is called before the first frame update
    void Start()
    {
        quizOpened2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        openQuiz();
        if (tpCamera.GetComponent<TargetScript>().quizMenu2 == false)
        {
            quizOpened2 = false;
        }
    }

    void openQuiz()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu2 == true && !quizOpened2)
        {
            quizOpened2 = true;
            GameObject secondQuizBox = Instantiate(secondQuizBoxPrefab) as GameObject;
            secondQuizBox.transform.SetParent(Canvas, worldPositionStays: false);

        }
    }
}
