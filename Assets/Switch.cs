using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool isticking = false;
    Animator anim;
    public Pipe pipeRef;

    AudioSource aud;
    
    public float TimeDelay=10.0f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
   
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("pushed");
            pipeRef.Open();
            anim.SetBool("Pushed", true);
            //initial
            aud.pitch = 0.8f;
            aud.Play();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {

       
        if (other.tag == "Player")
        {
            StartCoroutine(StartTimer(TimeDelay));
        }

    }

    IEnumerator StartTimer(float time)
    {
       
        //at half time
        yield return new WaitForSeconds(time/2);
      
        aud.pitch = 1.1f;
     
        //at quarrter time
        yield return new WaitForSeconds(time / 4);
       
        aud.pitch = 1.4f;
       
        //time up
        yield return new WaitForSeconds(time / 4);
        Debug.Log("unpushed");
        anim.SetBool("Pushed", false);
        pipeRef.Close();
        aud.Stop();
    }
}
