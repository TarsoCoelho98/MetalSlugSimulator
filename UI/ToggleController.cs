using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle Tg1;
    public Text Txt;


    // Start is called before the first frame update
    void Start()
    {
        Txt = FindObjectOfType<Text>();     
    }

    public void ChangeText()
    {
        Txt.text = Tg1.GetComponentInChildren<Text>().text;
    }
}
