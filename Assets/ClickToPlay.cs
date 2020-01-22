using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickToPlay : MonoBehaviour
{
    public AudioClip sound;

    private Button button {  get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private bool continue_playing = false;
    private float single_duration = 0.17241f;
    private float next_start_time;
    private float next_end_time;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        next_start_time = getRandomStartTime();
        next_end_time = next_start_time + single_duration;
        source.time = next_start_time;

        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        //on button down
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => FnOnDown());
        trigger.triggers.Add(pointerDown);

        //on button up
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => FnOnUp());
        trigger.triggers.Add(pointerUp);
    }
    float getRandomStartTime()
    {
        return (float) Random.value * (sound.length - single_duration);
    }
    void FnOnDown()
    {
        continue_playing = true;
        source.time = next_start_time;
        source.Play();
    }
    void FnOnUp()
    {
        continue_playing = false;
        source.Stop();
        next_start_time = getRandomStartTime();
        next_end_time = next_start_time + single_duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (continue_playing && source.time > next_end_time)
        {
            //source.time = next_start_time;
        }
    }
}
