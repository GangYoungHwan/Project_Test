using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public static HitEffect instance;
    public ParticleSystem _bloodhitEffect;
    public ParticleSystem _firehitEffect;
    void Start()
    {
        instance = this;
        //_firehitEffect.Stop();
        //_bloodhitEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hitFireEffect()
    {
        SoundManager.Instance.PlaySFXSound("FireHit", 1);
        _firehitEffect.Play();
    }
    public void hitbloodEffect()
    {
        SoundManager.Instance.PlaySFXSound("BloodHit", 1);
        _bloodhitEffect.Play();
    }
}
