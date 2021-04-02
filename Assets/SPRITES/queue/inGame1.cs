using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGame1 : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject correctUI;
    public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        questionUI.SetActive(true);
        correctUI.SetActive(false);
        incorrectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
