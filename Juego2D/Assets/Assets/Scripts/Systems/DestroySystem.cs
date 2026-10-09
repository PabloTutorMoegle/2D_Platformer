using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroySystem : MonoBehaviour
{
    public GameObject FX;
    public event Action OnDestroy = delegate { };
    
    public void DestroyObj()
    {
        if (FX != null){
            if (FX.TryGetComponent<ParticleSystem>(out ParticleSystem p))
                p.Play();
            else{
                if (FX.TryGetComponent<AudioSource>(out AudioSource s))
                    s.Play();
            }
        }
        OnDestroy.Invoke();
        Destroy(this.gameObject);
    }

    void OnEnable()
    {
        if(TryGetComponent<HealthSystem>(out HealthSystem hs))
            hs.OnZeroLifes.AddListener(DestroyObj);
    }

    void OnDisable()
    {
        if(TryGetComponent<HealthSystem>(out HealthSystem hs))
            hs.OnZeroLifes.RemoveListener(DestroyObj);
    }

}
