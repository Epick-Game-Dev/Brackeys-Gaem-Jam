using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Do, Re, Mi, Fa, Sol, La, Ti;
    public static AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        Do = Resources.Load<AudioClip>("Sounds/Do");
        Re = Resources.Load<AudioClip>("Sounds/Re");
        Mi = Resources.Load<AudioClip>("Sounds/Mi");
        Fa = Resources.Load<AudioClip>("Sounds/Fa");
        Sol = Resources.Load<AudioClip>("Sounds/So");
        La = Resources.Load<AudioClip>("Sounds/La");
        Ti = Resources.Load<AudioClip>("Sounds/Ti");

        source = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Do":
                source.Stop();
                source.PlayOneShot(Do);
                break;
            case "Re":
                source.Stop();
                source.PlayOneShot(Re);
                break;
            case "Mi":
                source.Stop();
                source.PlayOneShot(Mi);
                break;
            case "Fa":
                source.Stop();
                source.PlayOneShot(Fa);
                break;
            case "So":
                source.Stop();
                source.PlayOneShot(Sol);
                break;
            case "La":
                source.Stop();
                source.PlayOneShot(La);
                break;
            case "Ti":
                source.Stop();
                source.PlayOneShot(Ti);
                break;
        }
    }
}
