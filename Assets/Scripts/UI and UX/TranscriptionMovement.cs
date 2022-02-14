using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptionMovement : MonoBehaviour
{
    public GameObject face;
    private Camera cam;
    private Vector3 offset;

    private void Awake()
    {
        cam = Camera.main;
        offset = new Vector3(0, 2.5f, 0);
    }

    private void Update()
    {
        // places text above head
        transform.localPosition = face.transform.position + offset;

        // face the user at all times
        transform.LookAt(cam.transform.position, transform.up);
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y - 180, 0f);
    }
}
