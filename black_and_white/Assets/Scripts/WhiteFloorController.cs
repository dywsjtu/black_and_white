using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFloorController : MonoBehaviour
{
    public bool move = false;
    private Vector3 position;
    Subscription<ChangeColorEvent> color_event_subscription; 
    void Start()
    {
        position = transform.position;
        color_event_subscription = EventBus.Subscribe<ChangeColorEvent>(_OnColorUpdated);
    }

    // Update is called once per frame
    void _OnColorUpdated(ChangeColorEvent e)
    {
        if (e.white2Black) {
            // black floor need to be change from gray to black
            // from invisible to visible
            GetComponent<SpriteRenderer>().material.color = Color.gray;
            this.gameObject.layer = 9;
        }
        else 
        {
            // black floor need to be change from black to gray
            // from visible to invisible
            GetComponent<SpriteRenderer>().material.color = Color.white;
            this.gameObject.layer = 8;
        }
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(color_event_subscription);
    }

    void Update()
    {
        if (move)
        {
            transform.position = new Vector3(position.x, Mathf.Sin(Time.time) * 3, position.z);
        }
    }
}
