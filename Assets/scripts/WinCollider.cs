using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    LevelManager levelMan;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        levelMan = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            aud.Play();
            Invoke("WinLevel", aud.clip.length + 0.3f);
           
        }
    }

    void WinLevel()
    {
       // PlayerPrefs.SetInt()
        levelMan.LoadNextLevel();
    }
}
