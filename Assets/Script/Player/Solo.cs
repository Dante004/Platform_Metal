using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solo : MonoBehaviour {

    public AudioClip[] soundFile;
    public AudioClip[] wzorzec ;
    public int i=0;
    AudioSource play;
    public GameObject fivelines;  // tworzenie obiektu klasy Gameobjest fivelines- nazwa obiektu
    public bool klikniecie = false;
    PlayerManager soul; // tworzenie obiektu klasy

    void Start() // uruchamia sie przy uruchomieniu gry
    {
        play = GetComponent<AudioSource>();

        soul = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>(); // znalezienie game objectu o danym tagu i nadanie komponentu
    }


    void CheckSoul ()
    {
        
        if(klikniecie)
        {
            fivelines.SetActive(true);
            PlaySolo();
        }
        else
        {
            fivelines.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && soul.currentSpirit == 100 )
        {
            klikniecie = !klikniecie;
            Debug.Log(klikniecie); // debugowanie logu
        }

    }

    private void Update() // uruchamia sie co klatke 
    {
        CheckSoul();
    }

    void PlaySolo ()
    {
        if(Input.GetKeyDown(KeyCode.Z)) // getkeydown klikniecie getkey przytrzymanie getkeyup puszczenie
        {
           Game1(soundFile[0]);
           play.PlayOneShot(soundFile[0],1f);
            // 1f głośnośc od 0-1
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Game1(soundFile[1]);
            play.PlayOneShot(soundFile[1], 1f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Game1(soundFile[2]);
            play.PlayOneShot(soundFile[2], 1f);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Game1(soundFile[3]);
            play.PlayOneShot(soundFile[3], 1f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Game1(soundFile[4]);
            play.PlayOneShot(soundFile[4], 1f);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Game1(soundFile[5]);
            play.PlayOneShot(soundFile[5], 1f);
        }
        if(i == 5)
        {
            Debug.Log("Zagrałeś dobrze");
        }
    }

    void Game1(AudioClip sound)
    { 
            if (wzorzec[i] == sound)
             {
                i++;
                if (i > 5)
                    i = 0;
             }
            else
             {
                i = 0;
             }

    }


}
