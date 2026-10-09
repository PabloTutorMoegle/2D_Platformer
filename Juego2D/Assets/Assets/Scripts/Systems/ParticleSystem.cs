using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSystem : MonoBehaviour
{
    public ParticleSystem hitParticle;
    public ParticleSystem healParticle;
    private ParticleSystem _instance;

    public void PlayHitParticle(Vector3 position)
    {
        if (hitParticle != null)
        {
            ParticleSystem particle = Instantiate(hitParticle, position, Quaternion.identity);
            particle.Play();
            Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
        }
    }

    public void PlayHealParticle(Vector3 position)
    {
        if (healParticle != null)
        {
            ParticleSystem particle = Instantiate(healParticle, position, Quaternion.identity);
            particle.Play();
            Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
        }
    }

    public void PlayBloodParticles()
    {
        _instance = Instantiate(hitParticle, transform.position, Quaternion.identity);
    }
    public void PlayHealParticles()
    {
        _instance = Instantiate(healParticle, transform.position, Quaternion.identity);
    }
}
