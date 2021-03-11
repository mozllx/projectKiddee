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

    public int count=0;
   // PlayerScores user = new PlayerScores();
    [SerializeField]
    private Button[] buttons;

    

   public void CancelButton()
    {
        // UserUI.SetActive(true);
        // AddUI.SetActive(false);
       // SceneManager.LoadScene("User");
        //dropDown.value =0;
 
    }
    public void OnSubmit()
    {
        nameMember = nameField.text;
        passwordMember = passworField.text;
        PostToDatabase();
        //test.text = "Post Data ";
       count++;
       AddButtons();
        
    }
    public void AddButtons(){
       
        buttons[count].gameObject.SetActive(true); 
        buttons[count].GetComponentInChildren<Text>().text = ""+nameMember;

    }
    private void PostToDatabase()
    {
        
        Member member = new Member();
        Debug.Log(message:$"======================>{LoginManager.localId}");
        
    RestClient.Put("https://project-75a5c-default-rtdb.firebaseio.com/" + LoginManager.localId + "/"+nameMember+ ".json", member);
    }
    // Start is called before the first frame update
    
    void Start()
    {
       // DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        // FirebaseDatabase.DefaultInstance.GetReference("mbk5bIOVI4SbzdJ7X84VCRo9qDf2").ValueChanged += HandleValueChanged;
    }

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
