using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ5 : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject correctUI;
    //public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        questionUI.SetActive(true);
        correctUI.SetActive(false);
        //inCorrectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Q5DragS4.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q5DragS1.locked || Q5DragS2.locked || Q5DragS3.locked)
        {
            GotoinCorrectUI();
            Q5DragS1.locked = false;
            Q5DragS2.locked = false;
            Q5DragS3.locked = false;

        }

    }
    public void goToMain()
    {
        SceneManager.LoadScene("Q5");
    }
    public void tryQ4Again()
    {
        SceneManager.LoadScene("Q4");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q4Incorrect");
    }
}
