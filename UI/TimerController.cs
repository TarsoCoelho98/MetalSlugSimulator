using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text txt;
    float InitialTime = 10f;
    public float CurrentTime;
    public float otherTime;
    public Image image;
    public Animator AnimHandler;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = InitialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime >= 5)
        {
            otherTime = Time.time;
            CurrentTime = InitialTime - otherTime;
            txt.text = CurrentTime.ToString("f2", System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            AnimHandler.enabled = true;
        }
    }
}
