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

public class CilckProfile : MonoBehaviour
{
    public GameObject image1;
   
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
     public Sprite sprite4;
     public Sprite sprite5;
     public Sprite sprite6;
     public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate{Profile1();});
        button2.onClick.AddListener(delegate{Profile2();});
        button3.onClick.AddListener(delegate{Profile3();});
        button4.onClick.AddListener(delegate{Profile4();});
        button5.onClick.AddListener(delegate{Profile5();});
        button6.onClick.AddListener(delegate{Profile6();});
        button7.onClick.AddListener(delegate{Profile7();});
        button8.onClick.AddListener(delegate{Profile8();});
        button9.onClick.AddListener(delegate{Profile9();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Profile1()
    {
        image1.GetComponent<Image>().sprite=sprite1;
    }

    private void Profile2()
    {
        image1.GetComponent<Image>().sprite=sprite2;

    }
    private void Profile3()
    {
        image1.GetComponent<Image>().sprite=sprite3;

    }
    private void Profile4()
    {
        image1.GetComponent<Image>().sprite=sprite4;

    }
    private void Profile5()
    {
        image1.GetComponent<Image>().sprite=sprite5;

    }
    private void Profile6()
    {
        image1.GetComponent<Image>().sprite=sprite6;

    }
    private void Profile7()
    {
        image1.GetComponent<Image>().sprite=sprite7;

    }
    private void Profile8()
    {
        image1.GetComponent<Image>().sprite=sprite8;

    }
    private void Profile9()
    {
        image1.GetComponent<Image>().sprite=sprite9;

    }
}
