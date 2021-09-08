using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    GameObject PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = FindObjectOfType<CharacterController>().gameObject;
        transform.position = PlayerTarget.transform.position;
        transform.parent = PlayerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
     
    }
}
