using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Q2 : MonoBehaviour
{
    public GameObject correctUI;
    public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        correctUI.SetActive(false);
        inCorrectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Q2DragS2.locked)
        {
            correctUI.SetActive(true);
        }
        if (Q2DragS1.locked || Q2DragS3.locked || Q2DragS4.locked)
        {
            correctUI.SetActive(false);
            inCorrectUI.SetActive(true);
        }
        /*if (hamburger.locked && watermalon.locked && unicon.locked && tomato.locked)
        {
            winText1.SetActive(true);
        }
        if (trash.locked && trash2.locked && trash3.locked && trash4.locked && trash5.locked && trash6.locked)
        {
            winText3.SetActive(true);
        }*/

    }
    /*public void goToQ2()
    {
        SceneManager.LoadScene("Q2");
    }*/
}
