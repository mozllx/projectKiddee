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

public class ProfileMember : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject image1;
      public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Button button;
     public Button button2;
    public static int count=0;
 
     void Start()
    {
        button.onClick.AddListener(delegate{Addcount();});
        button2.onClick.AddListener(delegate{Removecount();});
    }

    // Update is called once per frame
     private void ChangeImg()
    {
        if(count==1){

            //image1.GetComponent<Image>().sprite=sprite1;
        }
        
    }
     private void Addcount()
    {
       count++;
         if(count==1)
        {
            image1.GetComponent<Image>().sprite=sprite1;
        }
        else  if(count==2)
        {
            image1.GetComponent<Image>().sprite=sprite2;
        }
        else  if(count==3)
        {
            image1.GetComponent<Image>().sprite=sprite3;
        }
        else  if(count==4)
        {
            count--;
        }

    }
    private void Removecount()
    {  
       count--;
       if(count==0){

            image1.GetComponent<Image>().sprite=sprite0;
        }
        else  if(count==1)
        {
            image1.GetComponent<Image>().sprite=sprite1;
        }   
        else  if(count==2)
        {
            image1.GetComponent<Image>().sprite=sprite2;
        }
        else  if(count==3)
        {
            image1.GetComponent<Image>().sprite=sprite3;
        }
        else  if(count==-1)
        {
            count++;
        }
    }
    void Update()
    {
        
    }
}
