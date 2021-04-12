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
public class profileUser : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite0;
    public Sprite sprite1;

    public GameObject image;
    public Button button;
    public int gender;
    // Start is called before the first frame update
    void Start()
    {
    //       FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    // {  
    //     DataSnapshot snapshot = task.Result;
    //    string s = snapshot.Child("User").Child("gender").Value.ToString();
    //    gender=Int32.Parse(s);
    // });  
        

       // button.onClick.AddListener(delegate{ChangeImg();});
    }
    public void ChangeImg()
    {
        gender=AddmemberManager.gender;
        if(gender==0){
            print("gender 0");
        image.GetComponent<Image>().sprite=sprite0;
        }else if(gender==1){
           image.GetComponent<Image>().sprite=sprite1;
            print("gender 1");
        }
       // image.GetComponent<Image>().sprite=sprite1;
    }
}
