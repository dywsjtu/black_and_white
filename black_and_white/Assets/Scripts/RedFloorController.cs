using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFloorController : MonoBehaviour
{
    public bool scan = false;
    private Vector3 position;
    public float speed = 1f;

    public float distance = 3f;
    void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        if (scan)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time / speed, distance), transform.position.y, transform.position.z);
        }
    }
}
