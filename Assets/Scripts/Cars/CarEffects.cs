using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    public ParticleSystem  GasParticles;
    public ParticleSystem  BoostParticles;

    public ParticleSystem[] gasParticles;
    public ParticleSystem[] boostParticles;
    private CarController CarController;

    // Start is called before the first frame update
    void Start()
    {
        CarController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (ParticleSystem gasParticle in gasParticles)
        {
            gasParticle.Play();
            ParticleSystem.EmissionModule em = gasParticle.emission;
            em.rateOverTime = Mathf.Lerp(em.rateOverTime.constant, Mathf.Clamp(150.0f * CarController.GetNormalizedSpeed(), 30.0f, 100.0f), 0.1f);
        }

        if (CarController.IsBoosting)
        {
            if (boostParticles.Length > 0 && !boostParticles[0].isPlaying)
            {
                foreach (ParticleSystem boostParticle in boostParticles)
                {
                    boostParticle.Play();
                }
            }
        }
        else if (boostParticles.Length > 0 && boostParticles[0].isPlaying)
        {
            foreach (ParticleSystem boostParticle in boostParticles)
            {
                boostParticle.Stop();
            }
        }
    }
}