﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseManu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisciplineDailyManu()
    {
         SceneManager.LoadScene("DisciplineDaily");
         
    }
     public void backToMain()
    {
         SceneManager.LoadScene("User");   
    }
     public void gotoSpeaking()
    {
         SceneManager.LoadScene("Speaking");   
    }
    public void gotoQueue()
    {
         SceneManager.LoadScene("queue");   
    }
     public void gotoHelpOthers()
    {
         SceneManager.LoadScene("HelpOthers");   
    }
         public void gotoKeepInOrder()
    {
         SceneManager.LoadScene("KeepInOrder");   
    }
}
