using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JellerFellers
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        float speed = 100;
        [SerializeField]
        float maxHeight;
        [SerializeField]
        float minHeight;


        // Start is called before the first frame update
        void Start()
        {



        }
        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > maxHeight || transform.position.y < minHeight)
            {
                SwitchDirection();
            }

            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        private void SwitchDirection()
        {
            speed = -speed;
        }
    }
}