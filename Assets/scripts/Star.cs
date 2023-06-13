using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
namespace JellerFellers
{

    public class Star : MonoBehaviour
    {


        [SerializeField]
        AudioClip clip;
        [SerializeField]
        float rotatespeed = 10;
        private void Start()
        {
            FindObjectOfType<LevelCollisionHandler>().AddStar(this.GetComponent<ObiCollider>());
        }
        /*
         private void OnTriggerEnter(Collider other)
         {
             if (other.tag == "Player")
             {
                 CollectStar();
             }
         }*/
        public void CollectStar()
        {
            Player_Controller_Obi player = FindObjectOfType<Player_Controller_Obi>();
            FindObjectOfType<Pipe>().Open();
            player.aud.clip = clip;
            player.aud.Play();
            Destroy(this.gameObject);
        }
        private void Update()
        {
            transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
        }
    }
}