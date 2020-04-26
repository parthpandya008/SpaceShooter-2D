using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticle : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private ParticleSystem particleSystem;


    public void OnObjectSpawn()
    {
        particleSystem.Play(true);
        float time = particleSystem.duration;
        Invoke("DisableObject", time);
    }

    private void DisableObject()
    {
        particleSystem.gameObject.SetActive(false);
    }
}
