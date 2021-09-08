using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    AudioClip clip;
    [SerializeField]
    float rotatespeed=10;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.tag == "Player")
        {
            Debug.Log(other.transform.parent.name);
            CharacterController player = FindObjectOfType<CharacterController>();
            player.coins++;
            player.coinText.text = (player.coins.ToString());
            player.aud.clip = clip;
            player.aud.Play();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0,rotatespeed*Time.deltaTime,0);
    }
}
