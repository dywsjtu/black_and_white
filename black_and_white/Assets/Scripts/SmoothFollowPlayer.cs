using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowPlayer : MonoBehaviour
{
    public GameObject objectToFollow;

    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        // float interpolation = speed * Time.deltaTime;
        // Vector3 position = this.transform.position;
        // position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        // position.x = objectToFollow.transform.position.x;
        // this.transform.position = position;
    }
}
