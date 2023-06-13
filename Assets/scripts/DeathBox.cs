using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellerFellers
{

    [ExecuteInEditMode]
    public class DeathBox : MonoBehaviour
    {
        public GameObject empty;
        [SerializeField]
        float colliderSize = 100.0f;
        BoxCollider collider;

        bool hasBeenTriggered = false;

        private void Awake()
        {
            collider = GetComponent<BoxCollider>();
        }

        public void HandleDeath()
        {
            if (hasBeenTriggered == false)
            {
                Debug.Log("handle death");
                FindObjectOfType<Player_Controller_Obi>().Die();
                GameObject temp = Instantiate(empty);

                empty.transform.position = FindObjectOfType<Player_Controller_Obi>().transform.position;

                Camera.main.GetComponent<MouseOrbitImproved>().target = temp.transform;
                hasBeenTriggered = true;
            }
        }


        /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                HandleDeath();
            }
        }*/
    }
}