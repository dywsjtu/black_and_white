using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    Vector3 hidden_pos;
    Vector3 visible_pos;

    public RectTransform toast_panel;
    public Text toast_text;

    // These inspector-accessible variables control how the toast UI panel moves between the hidden and visible positions.
    public AnimationCurve ease;
    public AnimationCurve ease_out;

    // Duration controls.
    public float ease_duration = 0.5f;
    public float show_duration = 1.5f;

    Subscription<ToastEvent> toast_event_subscription; 

    void Awake() {
        hidden_pos = new Vector3(0, 40, 0);
        visible_pos = new Vector3(0, -40, 0);
    }
    public void SetUpSubscription()
    {
        toast_event_subscription = EventBus.Subscribe<ToastEvent>(_OnToastUpdated);
    }

    void _OnToastUpdated(ToastEvent e)
    {
        toast_text.text = e.message;
        StartCoroutine(Toast(ease_duration, show_duration));
    }
    
    private void OnDestroy()
    {
        EventBus.Unsubscribe(toast_event_subscription);
    }

    IEnumerator Toast(float duration_ease_sec, float duration_show_sec)
    {
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration_ease_sec;

        while(progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration_ease_sec;
            float eased_progress = ease.Evaluate(progress);
            toast_panel.anchoredPosition = Vector3.LerpUnclamped(hidden_pos, visible_pos, eased_progress);

            yield return null;
        }
        yield return new WaitForSeconds(duration_show_sec);
        initial_time = Time.time;
        progress = 0.0f;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration_ease_sec;
            float eased_progress = ease_out.Evaluate(progress);
            toast_panel.anchoredPosition = Vector3.LerpUnclamped(hidden_pos, visible_pos, 1.0f - eased_progress);

            yield return null;
        }
    }
}
