using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
public class UserManager : MonoBehaviour
{
    private string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com"; 
    private string AuthKey = "AIzaSyBdvdw8w_v66y96r7ndXpKRs39lMiZwABY";
    // Start is called before the first frame update
    void Start()
    {
         FirebaseDatabase.DefaultInstance.GetReference("mbk5bIOVI4SbzdJ7X84VCRo9qDf2").ValueChanged += HandleValueChanged;
    }
   


    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
  if (args.DatabaseError != null) {
    Debug.LogError(args.DatabaseError.Message);
    return;
  }
  Debug.Log(args.Snapshot.Child("min").Value);
}
    // Update is called once per frame
    void Update()
    {
        
    }
      
}
