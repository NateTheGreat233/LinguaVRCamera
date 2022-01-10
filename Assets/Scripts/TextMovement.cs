using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMovement : MonoBehaviour
{
    public GameObject face;
    private Camera cam;
    private Vector3 offset;

    private void Awake()
    {
        cam = Camera.main;
        offset = new Vector3(0, 1f, 0);
    }

    private void Update()
    {
        // places text above head
        transform.position = face.transform.position + offset;

        // face the user at all times
        transform.LookAt(cam.transform.position, transform.up);
        transform.Rotate(0, 180, 0);
    }
}
