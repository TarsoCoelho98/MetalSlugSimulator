using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthController : MonoBehaviour
{
    public Image image;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        // image.GetComponent<Image>();

        image.fillAmount -= 0.25f;
        text.text = (image.fillAmount * 100).ToString();
    }
}
