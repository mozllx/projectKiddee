using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Member 

{  
     public string userName;
    public string password;
    // Start is called before the first frame update
   public Member()
    {
       // userName = PlayerScores.playerName;
       // userScore = PlayerScores.playerScore;
       
        userName = AddmemberManager.nameMember;
        
        password = AddmemberManager.passwordMember;
    }
}
