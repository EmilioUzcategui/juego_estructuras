using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject john;

    // Update is called once per frame
    void Update()
    {
      Vector3 position = transform.position;
      position.x = john.transform.position.x;
      transform.position = position;  
    }
}
