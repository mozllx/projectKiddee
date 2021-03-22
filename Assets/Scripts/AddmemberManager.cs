﻿using System.Collections;
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
// using UnityEngine.object;
public class AddmemberManager : MonoBehaviour
{
    public InputField nameField;
    public InputField passworField;
    public Text test;
    public static string nameMember;
    public static string passwordMember;
    
     ArrayList nameList = new ArrayList();
     ArrayList nameList2 = new ArrayList();
     ArrayList nameList3 = new ArrayList();

    ArrayList keyList = new ArrayList();

    public static int count;
    public string buttonKey;
    public int buttonName;


    [SerializeField]
    private Button[] buttons;
    private Button[] remove;
    private DatabaseReference reference;
    
    private void Awake()
    {

    
    }
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        GetCount();
        print(count+"Start");
        Invoke("AddButtons", 2); 

         // AddButtons();
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId) 
       // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
       .ValueChanged += HandleValueChanged;
       
    }

    

    public void LogoutUser()
    {
         SceneManager.LoadScene("Login");
    }
      public void StarCollections()
    {
         SceneManager.LoadScene("StarCollection");
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
       // print(ss);
        print(ss+"SaveAndRetrieveData");
        count=Int32.Parse(ss);
    });  
}
  public int GetCount() 
    {
    
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
       // print(ss);
        //print(ss+" GetCount");
        count=Int32.Parse(ss);

    });  
    return count;
}
   
    public void OnSubmit()
    { 
        
    nameMember = nameField.text;
    passwordMember = passworField.text;
    WriteAllData();
   // test.text = "Post Data ";
    count++;
      reference.Child(LoginManager.localId).Child("m_count").SetValueAsync(count);
      //StartCoroutine("Wait");
      //AddButtons2();
     Invoke("AddButtons2", 2); 
       //SaveAndRetrieveData() ;
    }


    public void AddButtons(){
       
     //StartCoroutine("Wait");
       for(int i=0;i<count;i++){
        buttons[i].gameObject.SetActive(true); 
        buttons[i].GetComponentInChildren<Text>().text = ""+nameList[i]; //****** i member name ?
       
       }
       // dddddd();
       
        
    }
   public void AddButtons2(){
     //   StartCoroutine("Wait");
         // Wait();
        print("AddButtons2 "+count);
       for(int i=0;i<nameList2.Count;i++){
        
        buttons[count-1].gameObject.SetActive(true); 
        buttons[count-1].GetComponentInChildren<Text>().text = ""+nameList2[i]; //****** i member name ?
       
       }

       
        //count++;
//        for(int i = 0 ; i < nameList2.Count; i++){
//          Debug.Log("nameList2 "+nameList2[i] + ", ");

//     }
        
    }
 public void ChangeButtons(){
       
    // StartCoroutine("Wait");
       
        
         for(int i=0;i<GetCount();i++){
         buttons[i].gameObject.SetActive(true); 
          buttons[i].GetComponentInChildren<Text>().text = ""+nameList3[i]; //****** i member name ?
       
       }
      
    }
     public void Remove()
     {
        //     nameList.Clear();
        //  RaadAllData();
          nameList3.RemoveAt(buttonName);
          for(int i = 0 ; i < nameList3.Count; i++){
         print("nameList3 "+nameList3[i] + ", ");

    }
       
         for(int i=0;i<GetCount();i++){
        buttons[i].gameObject.SetActive(false); 
       // buttons[i].GetComponentInChildren<Text>().text = ""+nameList[i]; //****** i member name ?
       
       }
       
        
              
         Invoke("ChangeButtons", 2); 
              
         
       
            
     }
    IEnumerator Wait(){

          yield return new WaitForSeconds(2f);


    }
    public void WriteAllData()
    {
        
       
        string key = reference.Child(LoginManager.localId).Push().Key;
        Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
        // เขียนข้อมูลลง Model
        Member mData = new Member();
        // mData.m_name = Random.Range(0f, 5f);
        mData.m_password = passworField.text;
        mData.no = count;
        mData.m_name = nameField.text;
          nameList2.Add(nameField.text);
        string json = JsonUtility.ToJson(mData);
        // เขียนข้อมูลลง Firebase
        reference.Child(LoginManager.localId).Child(key).SetRawJsonValueAsync(json);
        
      
      
}

 public void RaadAllData()
    {
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId)
        // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
        .ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // อ่าน Key เพื่อใช้แสดงผล
        List<string> keys = args.Snapshot.Children.Select(s => s.Key).ToList();
        foreach (var key in keys)
        {
            DisplayData(args.Snapshot, key);
        }
    }
    // ใช้สำหรับ แสดงข้อมูลที่โหลดครับ
    void DisplayData(DataSnapshot snapshot, string key)
    {
        string j = snapshot.Child(key).GetRawJsonValue();
        Member u = JsonUtility.FromJson<Member>(j);
          Debug.Log(u.no+" "+u.m_name+" "+u.m_password);
        //Debug.Log("key "+key);
       getNameMember(u.m_name);
       if(!keyList.Contains(key)&&!key.Contains("User")){
        getKeyMember(key);
       }
       
    }
    // Update is called once per frame
    void Update()
    {
        GetCount();
    }
    public void dddddd(){
    for(int i = 0 ; i < nameList.Count; i++){
         print("nameList "+nameList[i]);

    }
     }
     void getNameMember(string name)
    {

        nameList.Add(name);
        nameList3.Add(name);
        //nameMem=name;
         
      
    }
    void getKeyMember(string key)
    {

        keyList.Add(key);
        
         
    }
   
    public void OnClicked(Button button)
    {
        nameList3.Clear();
      RaadAllData();
        if(button.name=="0"){
             buttonName=0;   
             buttonKey =""+keyList[0];
           
        }else if(button.name=="1"){
             buttonName=1;   
            buttonKey =""+keyList[1];
           
        }else if(button.name=="2"){
             buttonName=2;   
            buttonKey =""+keyList[2];
           
        }else if(button.name=="3"){
             buttonName=3;   
             buttonKey =""+keyList[3];
           
        }else if(button.name=="4"){
             buttonName=4;   
             buttonKey =""+keyList[4];
           
        }
        
   

    }


}
