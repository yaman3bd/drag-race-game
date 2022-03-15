using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{

    public AudioClip EngineSound;
    public AudioClip BoostSound;

    public float MaxRolloffDistance = 500;
    public float DopplerLevel = 1;
    public bool UseDoppler = true;

    public float step;
    private AudioSource EngineSource;
    private AudioSource BoostSource;

    private CarController CarController;

    private void StartSound()
    {
        CarController = GetComponent<CarController>();

        EngineSource = SetUpEngineAudioSource(EngineSound);
        BoostSource = SetUpEngineAudioSource(BoostSound);
    }

    private void Start()
    {
        StartSound();
    }

    // sets up and adds new audio source to the gane object
    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.loop = true;

        // start the clip from a random point
        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.maxDistance = MaxRolloffDistance;
        source.dopplerLevel = 0;
        return source;
    }

    // Update is called once per frame
    private void Update()
    {

        float pitch = CarController.KPH / CarController.CarMaxSpeedPerGear[CarController.CurrentGear];
        EngineSource.pitch = pitch;

        float accFade = pitch;

        float highFade = Mathf.InverseLerp(0.2f, 0.8f, pitch);

        highFade = 1 - ((1 - highFade) * (1 - highFade));

        EngineSource.volume = (highFade * accFade) - step;

        EngineSource.dopplerLevel = UseDoppler ? DopplerLevel : 0;


        if (CarController.IsBoosting && !BoostSource.isPlaying)
        {
            BoostSource.Play();
        }
        else if (BoostSource.isPlaying)

        {
            BoostSource.Stop();

        }
    }
}