using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    public Scrollbar Scrolling;


    // Start is called before the first frame update
    void Start()
    {
        Scrolling = FindObjectOfType<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Scrolling.value == 1)
        {
            Debug.Log("Total");
        }
    }
}
