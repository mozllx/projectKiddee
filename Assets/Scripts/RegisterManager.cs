﻿using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{


    //Register variables
    [Header("Register")]
    public InputField nameRegisterField;
    public InputField surnameRegisterField;
    public InputField emailRegisterField;
    public InputField usernameRegisterField;
    public InputField passwordRegisterField;
    public InputField passwordRegisterVerifyField;
    public Dropdown dropDown;
   // public Text test;

    public static string u_name;
    public static string u_lastname;
    public static string u_email;
    public static int u_gender;
    public static string u_username;
    public static string u_password;

    private System.Random random = new System.Random(); 

    //User user = new User();

    private string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com"; 
    private string AuthKey = "AIzaSyBdvdw8w_v66y96r7ndXpKRs39lMiZwABY";
    
    public static fsSerializer serializer = new fsSerializer();
    
    
    public static int playerScore;
    public static string playerName;

    private string idToken;
    
   public static string localId;



    private FirebaseAuth auth;
    public Text ErrorText;
    public DatabaseReference reference;
   
void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
       
        //SignupButton.onClick.AddListener(() => Signup(nameText.text, surnameText.text, emailText.text, usernameText.text, passwordText.text));
       // SignupButton.onClick.AddListener(() => StartCoroutine(Register(emailText.text, passwordText.text, usernameText.text)));
       // SigninButton.onClick.AddListener(() => LoginAction(emailText.text, passwordText.text));
       FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    
}
 public void OnSubmit()
    {
        u_name = nameRegisterField.text;
        u_lastname = surnameRegisterField.text;
        u_email = emailRegisterField.text;
        u_username = usernameRegisterField.text;
        u_password = passwordRegisterField.text;
       // PostToDatabase();
      //  test.text = "Post Data ";
      
    }
    public void PostToDatabase(bool emptyScore = false, string idTokenTemp = "")
    {
        
        User user = new User();
       
       
        Debug.Log(message:$"======================>{user.userName}");
        // user.userName = "test";
       // RestClient.Post("https://project-75a5c-default-rtdb.firebaseio.com/" + uemail + ".json", user);
        u_name = nameRegisterField.text;
        u_lastname = surnameRegisterField.text;
        u_email = emailRegisterField.text;
        u_username = usernameRegisterField.text;
        u_password = passwordRegisterField.text;
       // u_gender= dropDown.value;
       // ugender=HandleGenderInput();
        
         if (idTokenTemp == "")
        {
            idTokenTemp = idToken;
        }
        

         RestClient.Put(databaseURL + "/" + localId +  "/"+u_username+ ".json?auth=" + idTokenTemp, user);
    }
    
    

    
    // private void RetrieveFromDatabase()
    // {
    //     RestClient.Get<User>(databaseURL + "/" + getLocalId + ".json?auth=" + idToken).Then(response =>
    //         {
    //             user = response;
                
    //         });
    // }
    
    public void HandleGenderInput(int val){
        if(val==0)
        {
            u_gender=0;
        }
        if(val==1)
        {
             u_gender=1;
        }
        if(val==2)
        {
             u_gender=2;
        }
    }
   
    public void CancelButton()
    {
        SceneManager.LoadScene("Login");
       
    }
    public void SignUpUserButton()
    {
        if(!passwordRegisterField.text.Equals(passwordRegisterVerifyField.text)){
            UpdateErrorMessage("password !!!");
            
        
        }else{
        SignUpUser(emailRegisterField.text, usernameRegisterField.text, passwordRegisterField.text,nameRegisterField.text,surnameRegisterField.text);
        }
    }
    private void SignUpUser(string email, string username, string password, string firstname, string lastname)
    
    {
        if(username == ""){
            UpdateErrorMessage("Missing Username");
        }else if(email == ""){
            UpdateErrorMessage("Missing email");
        }else if(password == ""){
            UpdateErrorMessage("Missing password");
        }else{


        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
        RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=" + AuthKey, userData).Then(
            response =>
            {
                string emailVerification = "{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + response.idToken + "\"}";
                RestClient.Post(
                    "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getOobConfirmationCode?key=" + AuthKey,
                    emailVerification);
                
                localId = response.localId;
                u_email = email;
                u_username = username;
                u_name=firstname;
                u_lastname=lastname;
                //u_gender=gender;
                u_password=password;
              // User user = new User();
             
                PostToDatabase(true, response.idToken);
                UpdateErrorMessage("Success");
                CancelButton();
                
            }).Catch(error =>
        {

            Debug.Log($"===================>{error}");
            UpdateErrorMessage("Email is Exise");
        });}
    }
     private void UpdateErrorMessage(string message)
    {
        ErrorText.text = message;
        Invoke("ClearErrorMessage", 8);
    }

    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }
    
    //    public void SignInUserButton()
    // {
    //     SignInUser(emailLoginField.text, passwordLoginField.text);
         
    // }
    
    // private void SignInUser(string email, string password)
    // {   
    //     string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
    //     RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + AuthKey, userData).Then(
    //         response =>
    //         {
    //             string emailVerification = "{\"idToken\":\"" + response.idToken + "\"}";
    //             RestClient.Post(
    //                 "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getAccountInfo?key=" + AuthKey,
    //                 emailVerification).Then(
    //                 emailResponse =>
    //                 {

    //                     fsData emailVerificationData = fsJsonParser.Parse(emailResponse.Text);
    //                     EmailConfirmationInfo emailConfirmationInfo = new EmailConfirmationInfo();
    //                     serializer.TryDeserialize(emailVerificationData, ref emailConfirmationInfo).AssertSuccessWithoutWarnings();
                        
    //                     if (emailConfirmationInfo.users[0].emailVerified)
    //                     {
    //                         idToken = response.idToken;
    //                         localId = response.localId;
    //                         GetUsername();
    //                         testLogin.text ="Login";
    //                         SceneManager.LoadScene("User");
    //                     }
    //                     else
    //                     {
    //                         testLogin.text ="Verify your email";
    //                        // Debug.Log("You are stupid, you need to verify your email dumb");
    //                     }
    //                 });
                
    //         }).Catch(error =>
    //     {
    //         testLogin.text ="Email or Password is incorrect";
    //         Debug.Log(error);
    //     });
    // }

    
    // private void GetUsername()
    // {
    //     RestClient.Get<User>(databaseURL + "/" + localId + ".json?auth=" + idToken).Then(response =>
    //     {
    //        // testLogin.text = response.userName;
    //         Debug.Log("GetUsername");
            
    //     });
    // }
    
    // private void GetLocalId(){
    //     RestClient.Get(databaseURL + ".json?auth=" + idToken).Then(response =>
    //     {
    //         var username = getScoreText.text;
            
    //         fsData userData = fsJsonParser.Parse(response.Text);
    //         Dictionary<string, User> users = null;
    //         serializer.TryDeserialize(userData, ref users);

    //         foreach (var user in users.Values)
    //         {
    //             if (user.userName == username)
    //             {
    //                 getLocalId = user.localId;
    //                 RetrieveFromDatabase();
    //                 break;
    //             }
    //         }
    //     }).Catch(error =>
    //     {
    //         Debug.Log(error);
    //     });
    // }
}
