using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{ 
    
    [SerializeField]
    public GameObject winText1;
    public GameObject winText2;
    public GameObject winText3;


    // Start is called before the first frame update
    void Start()
    {
         winText1.SetActive(false);
         winText2.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(DragCarrot1.locked&&DragCarrot2.locked && DragCarrot3.locked && DragCarrot4.locked && DragCarrot4.locked){
            winText2.SetActive(true);
        }
        if(hamburger.locked && watermalon.locked && unicon.locked && tomato.locked){
            winText1.SetActive(true);
        }
        if(trash.locked && trash2.locked && trash3.locked && trash4.locked && trash5.locked&& trash6.locked){
            winText3.SetActive(true);
        }
        
    }
}
