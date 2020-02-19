using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFloorController : MonoBehaviour
{
    Camera camera;
    public bool scanHorizontal = false;
    public AudioSource yellow;
    public bool isTouched = false;
    public bool scanVertical = false;
    private Vector3 position;
    public float speed = 1f;

    public float distance = 3f;

    Subscription<RecoverEvent> recover_event_subscription; 
    void Start()
    {
        position = transform.position;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        recover_event_subscription = EventBus.Subscribe<RecoverEvent>(_OnRecoverUpdated);
    }

    void _OnRecoverUpdated(RecoverEvent e)
    {   
        Debug.Log("test recover");
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().material.color = Color.yellow;
        this.gameObject.layer = 8;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(recover_event_subscription);
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
        if(other.gameObject.tag == "Player" && isTouched == false)
        {
            if (!yellow.isPlaying)
            {
                yellow.Play();
            }
            StartCoroutine(Dispear());
        }
    }

    IEnumerator Dispear()
    { 
    
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / 2.8f;
        while(progress < 1f)
        {
            progress = (Time.time - initial_time) / 2.8f;
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.yellow, Color.gray, progress);
            yield return null;
        }
        this.gameObject.layer = 9;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
