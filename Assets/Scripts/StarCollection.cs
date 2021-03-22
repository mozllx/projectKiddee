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

public class StarCollection : MonoBehaviour
{


    public Text nameText;
    public static int count;
    public static string name;
    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        RaadAllData();
    }

    // Update is called once per frame
    void Update()
    {
        
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
         nameText.text=u.m_name.ToString();  


         
        //Debug.Log("key "+key);
      // getNameMember(u.m_name);
      // if(!keyList.Contains(key)&&!key.Contains("User")){
       // getKeyMember(key);
       //}
       
    }
    // Update is called once per frame
   
    // public void dddddd(){
    // for(int i = 0 ; i < nameList.Count; i++){
    //      print("nameList "+nameList[i] + ", ");

    // }
    //  }
    //  void getNameMember(string name)
    // {

    //     nameList.Add(name);
    //     //nameMem=name;
         
      
    // }
    // void getKeyMember(string key)
    // {

    //     keyList.Add(key);
        
         
    // }
}
