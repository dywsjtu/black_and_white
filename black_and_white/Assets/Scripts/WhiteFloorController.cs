using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFloorController : MonoBehaviour
{
    Subscription<ChangeColorEvent> color_event_subscription; 
    void Start()
    {
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
}
