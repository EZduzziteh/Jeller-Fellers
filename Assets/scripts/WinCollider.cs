using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellerFellers
{

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



        private void OnTriggerEnter(Collider other)
        {


            if (other.tag == "Player")
            {
                HandleWin();
            }
        }

        public void HandleWin()
        {
            aud.Play();
            Invoke("WinLevel", aud.clip.length + 0.3f);

        }

        void WinLevel()
        {
            // PlayerPrefs.SetInt()
            levelMan.LoadNextLevel();
        }
    }
}
