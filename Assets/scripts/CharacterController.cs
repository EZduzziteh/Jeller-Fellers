using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float jumpForce=20000;
    [SerializeField]
    float moveForce = 50.0f;
    float timeHeldJump = 0.0f;
    bool holdingjump = false;
    [SerializeField]
    float maxHeldJump = 2.5f;
    [SerializeField]
    float flexScale=0.05f;

    public int coins;
    public int Stars;
    bool isDead = false;

    public Text coinText;
    

    public AudioSource aud;
    [SerializeField]
    AudioClip Jump;
    [SerializeField]
    AudioClip Death;
    [SerializeField]
    AudioClip CollectStar;
    [SerializeField]
    AudioClip CollectCoin;
    // Start is called before the first frame update
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {

            if (Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<FlexSoftActor>().ApplyImpulse(Vector3.up * jumpForce * timeHeldJump);
                holdingjump = false;
                timeHeldJump = 0.0f;
                if (!aud.isPlaying)
                {
                    aud.clip = Jump;
                    aud.Play();
                }
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
                    GetComponent<FlexSoftActor>().ApplyImpulse(Vector3.up * jumpForce * timeHeldJump);
                    holdingjump = false;
                    timeHeldJump = 0.0f;

                }
                else
                {
                    timeHeldJump += Time.deltaTime;
                    GetComponent<FlexSoftActor>().ApplyImpulse(Vector3.up * -jumpForce * flexScale * timeHeldJump);
                }

            }


            if (Input.GetKey(KeyCode.W))
            {

                GetComponent<FlexSoftActor>().ApplyImpulse(Camera.main.transform.forward * moveForce);

            }

            if (Input.GetKey(KeyCode.S))
            {

                GetComponent<FlexSoftActor>().ApplyImpulse(-Camera.main.transform.forward * moveForce);

            }
            if (Input.GetKey(KeyCode.A))
            {

                GetComponent<FlexSoftActor>().ApplyImpulse(-Camera.main.transform.right * moveForce);

            }
            if (Input.GetKey(KeyCode.D))
            {

                GetComponent<FlexSoftActor>().ApplyImpulse(Camera.main.transform.right * moveForce);

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
