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

public class Speaking : MonoBehaviour
{
     public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
<<<<<<< Updated upstream
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public static int history;
     public static string s;
     public static string member;
     public static string day,time;

    

    // Start is called before the first frame update
    void Start()
    
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        /*print("url member "+AddmemberManager.buttonKey);*/
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("speakingHistory").Value.ToString();
        history = Int32.Parse(s);
        history +=1;

    });  
=======
     public int countHis;
     public int score;
    private DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< Updated upstream

    public void count(){
        score += 1;
        print("score is "+score);
    }
    public void incorrect(){
        scoreIncorrect += 1;
        print("scoreIncorrect is "+scoreIncorrect);
    }
    public void save(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("speakingHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        goToMenu();
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }

=======
    public void Sum(){
        /*countHis++;
        string His = ""+"History"+countHis;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Date").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Score").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Speaking").Child(His).Child("Time").SetValueAsync("1");*/

    }
    public void count(){
        score +=1;
        print("score is "+score);
    }
    public void exit(){
        countHis++;
        string His = ""+"History"+countHis;
        reference.Child(LoginManager.localId).Child(memberURL).Child("Speaking").Child(His).Child("Date").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(memberURL).Child("Speaking").Child(His).Child("Time").SetValueAsync("1");
        reference.Child(LoginManager.localId).Child(memberURL).Child("Speaking").Child(His).Child("Score").SetValueAsync(score);
    }
>>>>>>> Stashed changes
}
