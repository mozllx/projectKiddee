﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public InputField mainInputField;

    // Activate the main input field when the Scene starts.
    void Start()
    {
        mainInputField.ActivateInputField();
    }
}