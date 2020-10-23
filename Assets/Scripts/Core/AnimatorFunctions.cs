using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private int emitAmount1;
    [SerializeField] private ParticleSystem particleSystem2;
    [SerializeField] private int emitAmount2;
    [SerializeField] private ParticleSystem particleSystem3;
    [SerializeField] private int emitAmount3;
    [SerializeField] private ParticleSystem particleSystem4;
    [SerializeField] private int emitAmount4;

    [Header("Sound Bank")]
    [SerializeField] private AudioClip [] sound1;
    [SerializeField] private float sound1Volume = 1;
    [SerializeField] private AudioClip [] sound2;
    [SerializeField] private float sound2Volume = 1;
    [SerializeField] private AudioClip [] sound3;
    [SerializeField] private float sound3Volume = 1;
    [SerializeField] private AudioClip [] sound4;
    [SerializeField] private float sound4Volume = 1;
    [SerializeField] private AudioClip [] sound5;
    [SerializeField] private float sound5Volume = 1;
    [SerializeField] private AudioClip [] sound6;
    [SerializeField] private float sound6Volume = 1;
    [SerializeField] private AudioClip [] sound7;
    [SerializeField] private float sound7Volume = 1;
    [SerializeField] private AudioClip [] sound8;
    [SerializeField] private float sound8Volume = 1;
    [SerializeField] private AudioClip [] sound9;
    [SerializeField] private float sound9Volume = 1;
    [SerializeField] private AudioClip [] sound10;
    [SerializeField] private float sound10Volume = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySound1()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound1[Random.Range(0, sound1.Length)], sound1Volume);
    }

    void PlaySound2()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound2[Random.Range(0, sound2.Length)], sound2Volume);
    }

    void PlaySound3()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound3[Random.Range(0, sound3.Length)], sound3Volume);
    }

    void PlaySound4()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound4[Random.Range(0, sound4.Length)], sound4Volume);
    }

    void PlaySound5()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound5[Random.Range(0,sound5.Length)], sound5Volume);
    }

    void PlaySound6()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound6[Random.Range(0, sound6.Length)], sound6Volume);
    }

    void PlaySound7()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound7[Random.Range(0, sound7.Length)], sound7Volume);
    }

    void PlaySound8()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound8[Random.Range(0, sound8.Length)], sound8Volume);
    }

    void PlaySound9()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound9[Random.Range(0, sound9.Length)], sound9Volume);
    }

    void PlaySound10()
    {
        NewPlayer.Instance.sfxAudioSource.PlayOneShot(sound10[Random.Range(0, sound10.Length)], sound5Volume);
    }

    public void EmitParticles1()
    {
        particleSystem1.Emit(emitAmount1);
    }

    public void EmitParticles2()
    {
        particleSystem2.Emit(emitAmount2);
    }

    public void EmitParticles3()
    {
        particleSystem3.Emit(emitAmount3);
    }

    public void EmitParticles4()
    {
        particleSystem4.Emit(emitAmount4);
    }
}
