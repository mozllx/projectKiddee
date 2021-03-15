using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
public class FirebaseControlle : MonoBehaviour
{
    private DatabaseReference reference;

    void Start()
    {
        // ใช้สำหรับอ้างอิง Firebase Project
        
reference = FirebaseDatabase.DefaultInstance.RootReference;
 FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        
    }

    public void WriteToniData()
    {
        // ทำการเขียนเขียนข้อมูลว่างๆ เพื่อนำ Key มาอ้างอิง และทำการ Update ข้อมูล
        string key = reference.Child("toni-test").Push().Key;
        Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
        // เขียนข้อมูลลง Model
        ToniData tData = new ToniData();
        tData.body = Random.Range(0f, 5f);
        tData.uid = "Tony";
        string json = JsonUtility.ToJson(tData);
        // เขียนข้อมูลลง Firebase
        reference.Child("toni-test").Child(key).SetRawJsonValueAsync(json);

    }

    public void RaadAllData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("toni-test")
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
        ToniData u = JsonUtility.FromJson<ToniData>(j);
        Debug.Log(u.uid + " " + u.body);
    }
}