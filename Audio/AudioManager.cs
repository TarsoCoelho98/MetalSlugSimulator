using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource Audio;
    public bool isStoped = false;

    public Sprite OnPlay;
    public Sprite Mute;
    public Button BtnAudio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = Camera.main.GetComponent<AudioSource>();
        BtnAudio.image.sprite = Mute;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopAndPlayMusic()
    {
        if (isStoped)
        {
            Audio.mute = false;
            BtnAudio.image.sprite = Mute;
            isStoped = false;
        }
        else
        {
            Audio.mute = true;
            isStoped = true;
            BtnAudio.image.sprite = OnPlay;
        }
    }
}
