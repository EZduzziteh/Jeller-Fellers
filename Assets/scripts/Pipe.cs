using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        open = true;
        GetComponent<Animator>().SetBool("Open", true);
        
    }

    internal void Close()
    {
        open = false;
        GetComponent<Animator>().SetBool("Open", false);
    }
}
