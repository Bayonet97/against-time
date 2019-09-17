using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _dialogueMusic;
    [SerializeField] private AudioClip _infiltration;
    [SerializeField] private AudioClip _exfiltration;

    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceDialogue;
    [SerializeField] private AudioSource _audioSourceInteraction;

    private CharacterTimer _characterTimer;
    private CharacterDialogue _characterDialogue;

    private void Start()
    {
        _audioSourceMusic.Play();
    }


    private void OnEnable()
    {
        if (_characterTimer == null)
            _characterTimer = _character.GetComponent<CharacterTimer>();
        if (_characterDialogue == null)
            _characterDialogue = _character.GetComponent<CharacterDialogue>();
        CharacterTimer.OnMileStoneReached += ChangeMusic;
        CharacterDialogue.OnDialogueStateChanged += PlayInteractionSound;
    }
    void OnDisable()
    {
        CharacterTimer.OnMileStoneReached -= ChangeMusic;
        CharacterDialogue.OnDialogueStateChanged -= PlayInteractionSound;
    }
    private void PlayInteractionSound(DialogueState dialogueState)
    {
        _audioSourceInteraction.Play();
    }

    private void ChangeMusic(float time)
    {
        if (time == 1000)
        {
        
            _audioSourceDialogue.Pause();
            _audioSourceMusic.UnPause();
        }
        else if (time == 999)
        {
            _audioSourceMusic.Pause();
            _audioSourceDialogue.Play();
        }
        else if(time == 60)
        {
           // FadeOut(_audioSourceMusic, 2f);

            _audioSourceMusic.clip = _exfiltration;
            _audioSourceMusic.Play();

        //  FadeIn(_audioSourceMusic, 1f);
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
