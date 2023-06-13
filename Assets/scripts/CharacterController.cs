using NVIDIA.Flex;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JellerFellers
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        float jumpForce = 20000;
        [SerializeField]
        float moveForce = 50.0f;

        public float airControl = 15.0f;
        float timeHeldJump = 0.0f;
        bool holdingjump = false;
        [SerializeField]
        float maxHeldJump = 2.5f;
        [SerializeField]
        float flexScale = 0.05f;

        public int coins;
        public int Stars;
        bool isDead = false;

        public Text coinText;
        public bool isGrounded = true;

        public AudioSource aud;
        [SerializeField]
        AudioClip Jump;
        [SerializeField]
        AudioClip Death;
        [SerializeField]
        AudioClip CollectStar;
        [SerializeField]
        AudioClip CollectCoin;
        FlexSoftActor flexActor;
        // Start is called before the first frame update
        private void Start()
        {
            aud = GetComponent<AudioSource>();
            flexActor = GetComponent<FlexSoftActor>();


        }




        // Update is called once per frame
        void Update()
        {
            if (isDead)
            {

                if (Input.anyKey)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    isGrounded = true;
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    HandleJump();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    holdingjump = true;
                    timeHeldJump = 0.0f;
                }

                if (holdingjump)
                {
                    if (timeHeldJump > maxHeldJump)
                    {
                        HandleJump();

                        holdingjump = false;
                        timeHeldJump = 0.0f;


                    }
                    else
                    {
                        timeHeldJump += Time.deltaTime;
                        flexActor.ApplyImpulse(Vector3.up * -jumpForce * flexScale * timeHeldJump);
                    }

                }


                if (Input.GetKey(KeyCode.W))
                {
                    float totalMoveForce = moveForce;

                    //if not grounded, apply air control
                    if (!isGrounded)
                    {
                        totalMoveForce *= airControl;
                    }

                    Vector3 forwardVector = Camera.main.transform.forward;
                    flexActor.ApplyImpulse(forwardVector * totalMoveForce * Time.deltaTime);


                }

                if (Input.GetKey(KeyCode.S))
                {
                    float totalMoveForce = moveForce;

                    //if not grounded, apply air control
                    if (!isGrounded)
                    {
                        totalMoveForce *= airControl;
                    }
                    flexActor.ApplyImpulse(-Camera.main.transform.forward * totalMoveForce * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.A))
                {
                    float totalMoveForce = moveForce;

                    //if not grounded, apply air control
                    if (!isGrounded)
                    {
                        totalMoveForce *= airControl;
                    }
                    flexActor.ApplyImpulse(-Camera.main.transform.right * totalMoveForce * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.D))
                {
                    float totalMoveForce = moveForce;

                    //if not grounded, apply air control
                    if (!isGrounded)
                    {
                        totalMoveForce *= airControl;
                    }
                    flexActor.ApplyImpulse(Camera.main.transform.right * totalMoveForce * Time.deltaTime);

                }
            }
        }


        private void HandleJump()
        {
            if (isGrounded)
            {
                isGrounded = false;
                flexActor.ApplyImpulse(Vector3.up * jumpForce * timeHeldJump);
                holdingjump = false;
                timeHeldJump = 0.0f;
                if (!aud.isPlaying)
                {
                    aud.clip = Jump;
                    aud.Play();
                }
            }
        }

        public void Die()
        {
            isDead = true;
            aud.clip = Death;
            aud.Play();

        }



    }
    


}
