using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceFrame : MonoBehaviour
{
    [SerializeField]
    Transform rotationTarget;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(rotationTarget.rotation.x, rotationTarget.rotation.y, rotationTarget.rotation.z, 1);
    }
}
