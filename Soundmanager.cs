using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
  public  static   AudioClip jump, coin,hurt;
    static AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        jump= Resources.Load<AudioClip>("jump");
        coin = Resources.Load<AudioClip>("coin");
        hurt = Resources.Load<AudioClip>("hurt");
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                sound.PlayOneShot(jump);
                break;
            case "coin":
                sound.PlayOneShot(coin);
                break;
            case "hurt":
                sound.PlayOneShot(hurt);
                break;
        }
    }
}
