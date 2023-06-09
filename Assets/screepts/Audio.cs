using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioClip button_click;
    private AudioSource Button;

    public void Click_Paw()
    {
    Button.PlayOneShot(button_click);
    }


}
