using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameObject empty;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<CharacterController>().Die();
            GameObject temp=Instantiate(empty);
            empty.transform.position = Camera.main.GetComponent<MouseOrbitImproved>().target.position;
            Destroy(GetComponent<Collider>());
            Camera.main.GetComponent<MouseOrbitImproved>().target = temp.transform;
        }
    }
}
