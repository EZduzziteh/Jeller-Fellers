using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace JellerFellers
{
    public class Timer : MonoBehaviour
    {

        float time;
        public Text text;
        // Start is called before the first frame update
        void Start()
        {
            time = 0.0f;
            text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;

            text.text = time.ToString();
        }
    }
}

