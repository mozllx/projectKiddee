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
    public static int count;

    [SerializeField]
    private Button[] buttons;
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
    
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId) 
       // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
       .ValueChanged += HandleValueChanged;
       
        
    }
    

    public void LogoutUser()
    {
         SceneManager.LoadScene("Login");
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
      Invoke("AddButtons2", 2); 
       //SaveAndRetrieveData() ;
    }


    public void AddButtons(){
       
        
       for(int i=0;i<GetCount();i++){
        buttons[i].gameObject.SetActive(true); 
        buttons[i].GetComponentInChildren<Text>().text = ""+nameList[i]; //****** i member name ?
       
       }
       // dddddd();
       
        
    }
     public void AddButtons2(){
      
    
        // if(count==1){
        
        // buttons[0].gameObject.SetActive(true); 
        // buttons[0].GetComponentInChildren<Text>().text = ""+nameList2[0]; //****** i member name ?

        // }
        print("AddButtons2 "+count);
       for(int i=0;i<nameList2.Count;i++){
        
        buttons[count-1].gameObject.SetActive(true); 
        buttons[count-1].GetComponentInChildren<Text>().text = ""+nameList2[i]; //****** i member name ?
       
       }
        //count++;
       for(int i = 0 ; i < nameList2.Count; i++){
         Debug.Log("nameList2 "+nameList2[i] + ", ");

    }
        
    }
    public void WriteAllData()
    {
        
       // Member member = new Member();
        //Debug.Log(message:$"======================>{LoginManager.localId}");
        
   // RestClient.Put("https://project-75a5c-default-rtdb.firebaseio.com/" + LoginManager.localId + "/"+nameMember+ ".json", member);
    
    // Start is called before the first frame update
     // ทำการเขียนเขียนข้อมูลว่างๆ เพื่อนำ Key มาอ้างอิง และทำการ Update ข้อมูล
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
       // Debug.Log(u.no+" "+u.m_name+" "+u.m_password);
      // Debug.Log(key);
       getNameMember(u.m_name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void dddddd(){
    for(int i = 0 ; i < nameList.Count; i++){
         print("nameList "+nameList[i] + ", ");

    }
     }
     void getNameMember(string name)
    {

        nameList.Add(name);
        //nameMem=name;
         
      
    }
     
//       void HandleValueChanged(object sender, ValueChangedEventArgs args) {
//   if (args.DatabaseError != null) {
//     Debug.LogError(args.DatabaseError.Message);
//     return;
//   }
//   Debug.Log(args.Snapshot.Child("userName").Value);
// }
}
