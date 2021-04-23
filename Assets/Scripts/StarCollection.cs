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

public class StarCollection : MonoBehaviour
{


    public Text nameText;
    public static int count;
    public static string name;
    private DatabaseReference reference;

    [Header("UserData")]
    public GameObject scoreElement;
    public Transform scoreboardContent;
    ArrayList nameMember = new ArrayList();
    ArrayList showButton = new ArrayList();

    private string display = "";

     [SerializeField]
    private Button[] reportBtn;
     [SerializeField]
    private Button[] starBtn;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        RaadAllData();
         //passwordList2 =AddmemberManager.nameList3;
         
        //print(passwordList2[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Users()
    {
         SceneManager.LoadScene("User");
    }
    public void ScoreboardButton()
    {        
       // StartCoroutine(LoadScoreboardData());
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
        nameMember.Clear();
        string j = snapshot.Child(key).GetRawJsonValue();
        Member u = JsonUtility.FromJson<Member>(j);
        // Debug.Log(u.no+" "+u.m_name+" "+u.m_password);
        // nameText.text=u.m_name.ToString();  
         if(!nameMember.Contains(u.m_name)&&!showButton.Contains(u.m_name)){
        nameMember.Add(u.m_name);
        showButton.Add(u.m_name);
        
       }
       ShowButtons();
        Display();      
         
    }
    public void Display(){

          foreach (string human in nameMember) 
          {
            display = display.ToString () + human.ToString() + "\n";
         }
         nameText.text = display;
         print("display "+display);
         
    }
    public void ShowButtons(){

       for(int i=0;i<showButton.Count-1;i++){
           print("showButton :"+showButton[i]);
        reportBtn[i].gameObject.SetActive(true); 
        starBtn[i].gameObject.SetActive(true); 
       }
        
        
    }

   
}
