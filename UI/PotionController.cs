using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionController : MonoBehaviour
{
    public Image img;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reduce()
    {
        img.fillAmount -= 0.25f;
    }

    public void Debug()
    {
        print("yes");
    }
}
