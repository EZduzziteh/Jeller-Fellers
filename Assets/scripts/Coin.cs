using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
namespace JellerFellers
{
    public class Coin : MonoBehaviour
    {

        [SerializeField]
        AudioClip clip;
        [SerializeField]
        float rotatespeed = 10;
        /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                CollectCoin();  
            }
        }*/

        public void Start()
        {

            FindObjectOfType<LevelCollisionHandler>().AddCoin(this.GetComponent<ObiCollider>());

        }

        public void CollectCoin()
        {
            Player_Controller_Obi player = FindObjectOfType<Player_Controller_Obi>();
            player.coins++;
            player.coinText.text = (player.coins.ToString());
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
