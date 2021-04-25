using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
     public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
     public int countHis;
    private DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sum(){

        countHis++;
        string His = ""+"History"+countHis;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Date").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Score").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Time").SetValueAsync("1");

    }
}
