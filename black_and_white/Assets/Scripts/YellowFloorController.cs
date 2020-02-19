using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFloorController : MonoBehaviour
{
    Camera camera;
    public bool scanHorizontal = false;

    public bool scanVertical = false;
    private Vector3 position;
    public float speed = 1f;

    public float distance = 3f;
    void Start()
    {
        position = transform.position;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
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
        while (true)
        {
            float initial_time = Time.time;
            float progress = (Time.time - initial_time) / 3f;
            while(progress < 1f)
            {
                progress = (Time.time - initial_time) / 3f;
                GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.yellow, Color.gray, progress);
                yield return null;
            }
            gameObject.SetActive(false);
            yield return null;
        }
    }
}
