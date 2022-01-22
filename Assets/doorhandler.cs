using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorhandler : MonoBehaviour
{
    public Vector3 doorExitPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = doorExitPos;
            camerafollow.instance.transform.position = doorExitPos + transform.forward * -13.5f;
        }
    }
}
