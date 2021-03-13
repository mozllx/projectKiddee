using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System;
using Firebase;
using Firebase.Database;
public class AddmemberManager : MonoBehaviour
{
    public InputField nameField;
    public InputField passworField;
    public Text test;
    public static string nameMember;
    public static string passwordMember;
    public Dropdown dropDown;

    public static int count=0;
   // PlayerScores user = new PlayerScores();
    [SerializeField]
    private Button[] buttons;
 DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    void Start()
    {
          //reference.Child(LoginManager.localId).Child("m_count").SetValueAsync(count);
       
     SaveAndRetrieveData();
        //  DatabaseReference mRootRef = FirebaseDatabase.getInstance().getReference();
        //DatabaseReference mUsersRef = mRootRef.child("users");
        // DatabaseReference mMessagesRef = mRootRef.child("messages");
        // mUsersRef.child("id-12345").setValue("Jirawatee");
       // 
        // FirebaseDatabase.DefaultInstance.GetReference("mbk5bIOVI4SbzdJ7X84VCRo9qDf2").ValueChanged += HandleValueChanged;
    }


   public void CancelButton()
    {
        // UserUI.SetActive(true);
        // AddUI.SetActive(false);
       // SceneManager.LoadScene("User");
        //dropDown.value =0;
 
    }

    public void SaveAndRetrieveData() //from the database (server)...
    {
    //store the data to the server...
    
    //Retrieve the data and convert it to string...
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
        print(ss);
        print("data retrieved");
        count=Int32.Parse(ss);
    });  
}
  public int GetCount() //from the database (server)...
    {
    //store the data to the server...
    
    //Retrieve the data and convert it to string...
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
        print(ss);
        print("data retrieved");
        count=Int32.Parse(ss);

    });  
    return count;
}
   
    public void OnSubmit()
    { 
        
        // DatabaseReference mRootRef = FirebaseDatabase.getInstance().getReference();
        // DatabaseReference mUsersRef = mRootRef.child("users");
        // DatabaseReference mMessagesRef = mRootRef.child("messages");
        // mUsersRef.child("id-12345").setValue("Jirawatee");
 FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
        print(ss);
        print("data retrieved");
        count=Int32.Parse(ss);
    });  
    
    nameMember = nameField.text;
    passwordMember = passworField.text;
    PostToDatabase();
    test.text = "Post Data ";
    count++;
      reference.Child(LoginManager.localId).Child("m_count").SetValueAsync(count);
    AddButtons();
       //SaveAndRetrieveData() ;
    }


    public void AddButtons(){
       

       for(int i=0;i<GetCount();i++){
        buttons[i].gameObject.SetActive(true); 
        buttons[i].GetComponentInChildren<Text>().text = ""+i; //****** i member name ?
       }
    }
    private void PostToDatabase()
    {
        
        Member member = new Member();
        Debug.Log(message:$"======================>{LoginManager.localId}");
        
    RestClient.Put("https://project-75a5c-default-rtdb.firebaseio.com/" + LoginManager.localId + "/"+nameMember+ ".json", member);
    }
    // Start is called before the first frame update
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
     
//       void HandleValueChanged(object sender, ValueChangedEventArgs args) {
//   if (args.DatabaseError != null) {
//     Debug.LogError(args.DatabaseError.Message);
//     return;
//   }
//   Debug.Log(args.Snapshot.Child("userName").Value);
// }
}
