using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Q1 : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject correctUI;
    public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        questionUI.SetActive(true);
        correctUI.SetActive(false);
        inCorrectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Q1DragS1.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if(Q1DragS2.locked || Q1DragS3.locked || Q1DragS4.locked)
        { 
            questionUI.SetActive(false);
            inCorrectUI.SetActive(true);
        }

    }
    public void goToQ2()
    {
        SceneManager.LoadScene("Q2");
    }
}
