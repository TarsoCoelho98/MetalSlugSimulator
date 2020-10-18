using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public int Jumps = 0;
    public Text JumpsText;
    public Image Image;
    public RawImage Scrolling;
    public RawImage Moon;
    public float NaturalDistance;
    public Camera MainCamera;

    public Transform Player;



    public void InstanceVerify()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        InstanceVerify();
        NaturalDistance = Vector2.Distance(transform.position, Player.transform.position);
        //JumpsText.text = Jumps.ToString();
        
        //Image.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        //Scrolling.uvRect = new Rect(Scrolling.uvRect.x + (0.1f * Time.deltaTime), Scrolling.uvRect.y, Scrolling.uvRect.width, Scrolling.uvRect.height);   
        //Rect rect = Scrolling.uvRect;

        //rect.x += 0.1f * Time.deltaTime;
        //Scrolling.uvRect = rect;       
    }

    public void TranslateBackground(bool rightTranslate, float speed)
    {
        //if (rightTranslate)
        //{
        //    //Scrolling.transform.Translate(Vector2.right * speed * Time.deltaTime);
        //    //Moon.transform.Translate(Vector2.right * speed * Time.deltaTime);
        //    MainCamera.transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}
        //else
        //{
        //    //Scrolling.transform.Translate(Vector2.left * speed * Time.deltaTime);
        //    //Moon.transform.Translate(Vector2.left * speed * Time.deltaTime);
        //    MainCamera.transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}
    }


    public void IncreaseJump()
    {
        ++Jumps;
        JumpsText.text = Jumps.ToString();
    }
}
