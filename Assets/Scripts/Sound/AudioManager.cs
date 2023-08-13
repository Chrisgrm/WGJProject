using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Referencia al AudioMixer

    public AudioSource backgroundMusicSource; // AudioSource para la música de fondo
    public AudioSource startScreenMusicSource; // AudioSource para la música de la pantalla de inicio
    public AudioSource victoryMusicSource; // AudioSource para la música de victoria
    public AudioSource defeatMusicSource; // AudioSource para la música de derrota

    // AudioSource para efectos de sonido 3D
    public AudioSource footstepsSource;
    public AudioSource playerEffectsSource;
    public AudioSource enemyEffectsSource;
    public AudioSource interactionEffectsSource;

    // AudioClips para efectos de sonido
    public AudioClip[] footstepsClips;
    public AudioClip[] playerEffectsClips;
    public AudioClip[] enemyEffectsClips;
    public AudioClip[] interactionEffectsClips;

    public void PlayStartScreenMusic()
    {
        startScreenMusicSource.loop = true;
        startScreenMusicSource.Play();
    }

    public void StopStartScreenMusic()
    {
        startScreenMusicSource.Stop();
    }

    public void PlayVictoryMusic()
    {
        victoryMusicSource.loop = false; // Asume que no deseas repetir la música de victoria
        victoryMusicSource.Play();
    }

    public void PlayDefeatMusic()
    {
        defeatMusicSource.loop = false; // Asume que no deseas repetir la música de derrota
        defeatMusicSource.Play();
    }

    // Iniciar la reproducción de la música de fondo
    public void PlayBackgroundMusic(AudioClip backgroundMusicClip)
    {
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    // Detener la reproducción de la música de fondo
    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    // Reproducir sonido de pasos
    public void PlayFootstepSound()
    {
        int clipIndex = UnityEngine.Random.Range(0, footstepsClips.Length);
        PlaySound(footstepsSource, footstepsClips, clipIndex);
    }

    // Reproducir efectos de sonido del personaje
    public void PlayPlayerEffect(int clipIndex)
    {
        PlaySound(playerEffectsSource, playerEffectsClips, clipIndex);
    }

    // Reproducir efectos de sonido de los enemigos
    public void PlayEnemyEffect(int clipIndex)
    {
        PlaySound(enemyEffectsSource, enemyEffectsClips, clipIndex);
    }

    // Reproducir efectos de sonido de las interacciones
    public void PlayInteractionEffect(int clipIndex)
    {
        PlaySound(interactionEffectsSource, interactionEffectsClips, clipIndex);
    }

    private void PlaySound(AudioSource source, AudioClip[] clips, int clipIndex)
    {
        if (clipIndex < clips.Length)
        {
            source.clip = clips[clipIndex];
            source.Play();
        }
        else
        {
            Debug.LogWarning("Índice de efecto de sonido fuera de rango.");
        }
    }
}
