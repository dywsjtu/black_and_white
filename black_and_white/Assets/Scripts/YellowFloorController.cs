using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFloorController : MonoBehaviour
{
   public bool scanHorizontal = false;

    public bool scanVertical = false;
    private Vector3 position;
    public float speed = 1f;

    public float distance = 3f;
    void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        if (scanHorizontal)
        {
            transform.position = new Vector3(position.x + Mathf.PingPong(Time.time / speed, distance), position.y, position.z);
        }
        if (scanVertical)
        {
            transform.position = new Vector3(position.x, Mathf.PingPong(Time.time / speed, distance) + position.y, position.z);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Dispear());
        }
    }

    IEnumerator Dispear()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
