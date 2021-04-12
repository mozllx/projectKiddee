using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite sprite1;
    public GameObject image;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(delegate{ChangeImg();});
    }
    private void ChangeImg()
    {
        image.GetComponent<Image>().sprite=sprite1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
