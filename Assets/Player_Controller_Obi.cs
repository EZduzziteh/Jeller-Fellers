using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace JellerFellers
{

    public class Player_Controller_Obi : MonoBehaviour
    {
        [SerializeField]
        public Transform referenceFrame;
        [SerializeField]
        public float acceleration = 80;
        [Range(0, 1)]
        public float airControl = 0.5f;
        [SerializeField]
        float jumpPower = 5.0f;
        [SerializeField]
        float jumpHeldPushDownPower = 1.0f;
        float timeHeldJump = 0.0f;
        [SerializeField]
        float maxHeldJump = 3.0f;
        bool isJumpHeld = false;
        ObiSoftbody softbody;
        bool onGround = false;
        public float offGroundThreshold = 0.4f;

        public float forwardBoost=1.5f;
        public float sidewaysBoost=1.0f;


        public int coins;
        public int Stars;
        bool isDead = false;
        public Text coinText;
        public AudioSource aud;
        [SerializeField]
        AudioClip jumpSoundEffect;
        [SerializeField]
        AudioClip deathSoundEffect;
        [SerializeField]
        AudioClip collectStar;
        [SerializeField]
        AudioClip collectCoin;




        float timeSinceLeftGround;
        // Start is called before the first frame update
        void Start()
        {
            aud = GetComponent<AudioSource>();
            softbody = GetComponent<ObiSoftbody>();
            softbody.solver.OnCollision += Solver_OnCollision;

        }

        private void Update()
        {

            if (isDead)
            {

                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                }

                return;
            }

            if (onGround)
            {

            }
            else
            {
                
                timeSinceLeftGround += Time.deltaTime;
                
            }

            HandleMovement();
            HandleJumping();

           
        }

        private void HandleJumping()
        {
            if (timeSinceLeftGround<=offGroundThreshold)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    jumpLaunch();

                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        isJumpHeld = true;
                        timeHeldJump = 0.0f;
                    }

                    if (isJumpHeld)
                    {
                        if (timeHeldJump > maxHeldJump)
                        {
                            jumpLaunch();

                        }


                    }
                }
            }
          
            
        }

        private void HandleMovement()
        {
            if (referenceFrame != null)
            {
                Vector3 direction = Vector3.zero;

                // Determine movement direction:
                if (Input.GetKey(KeyCode.W))
                {
                    direction += referenceFrame.forward * acceleration*forwardBoost;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    direction += -referenceFrame.right * acceleration*sidewaysBoost;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    direction += -referenceFrame.forward * acceleration*forwardBoost;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    direction += referenceFrame.right * acceleration*sidewaysBoost;
                }
                direction.y = 0;
                float effectiveAcceleration = acceleration;

                if (timeSinceLeftGround > offGroundThreshold)
                    effectiveAcceleration *= airControl;

                softbody.AddForce(direction.normalized * effectiveAcceleration * Time.deltaTime, ForceMode.Acceleration);
            }
        }

        public void jumpLaunch()
        {
            aud.clip = jumpSoundEffect;
            aud.Play();
            isJumpHeld = false;

            softbody.AddForce(Vector3.up * jumpPower * timeHeldJump, ForceMode.Impulse);
        }

        // Update is called once per frame
        void FixedUpdate()
        {


            if (!isDead)
            {




                if (onGround)
                {
                    if (isJumpHeld)
                    {
                        timeHeldJump += Time.deltaTime;
                        softbody.AddForce(Vector3.down * timeHeldJump * jumpHeldPushDownPower, ForceMode.Impulse);
                    }

                }



            }
        }

        public void Die()
        {
            isDead = true;
            aud.clip = deathSoundEffect;
            aud.Play();

        }
        private void Solver_OnCollision(ObiSolver solver, ObiSolver.ObiCollisionEventArgs e)
        {

            onGround = false;


            timeSinceLeftGround = 0.0f;
            var world = ObiColliderWorld.GetInstance();
            foreach (Oni.Contact contact in e.contacts)
            {
                // look for actual contacts only:
                if (contact.distance > 0.01)
                {
                    var col = world.colliderHandles[contact.bodyB].owner;
                    if (col != null)
                    {
                        onGround = true;
                        Debug.Log("grounded");
                        return;
                    }
                }
            }
        }

    }
}