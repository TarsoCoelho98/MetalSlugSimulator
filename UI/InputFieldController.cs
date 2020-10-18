using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public Text Text1, Text2;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValueRuntime()
    {
        Text1.text = input.text;
    }

    public void SaveValue()
    {
        Text2.text = input.text;
        input.readOnly = true;
    }
}
