using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownController : MonoBehaviour
{
    public Dropdown dd;
    public Text txt;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeTextImage()
    {
        txt.text = dd.captionText.text;
        image.sprite = dd.captionImage.sprite;
    }
}
