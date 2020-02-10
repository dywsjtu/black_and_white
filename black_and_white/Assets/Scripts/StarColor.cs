using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColor : MonoBehaviour
{
     // Start is called before the first frame update

    public Sprite black;
    public Sprite white;

    Subscription<ChangeColorEvent> color_event_subscription; 
    void Start()
    {
        color_event_subscription = EventBus.Subscribe<ChangeColorEvent>(_OnColorUpdated);
    }

    // Update is called once per frame
    void _OnColorUpdated(ChangeColorEvent e)
    {
        if (e.white2Black) {
            GetComponent<SpriteRenderer>().sprite = black;
        }
        else 
        {
            GetComponent<SpriteRenderer>().sprite = white;
        }
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(color_event_subscription);
    }
}
