using UnityEngine;

public class AudioManager : Singleton<AudioManager> 
{

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;

    public AudioClip backgroundMusicClip;
    public AudioClip[] soundEffectsClips;

    

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicClip != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffectsClips.Length)
        {
            soundEffectSource.PlayOneShot(soundEffectsClips[index]);
        }
    }

    public void PlayFootstepSound()
    {
        int footstepIndex = 0; 
        if (footstepIndex >= 0 && footstepIndex < soundEffectsClips.Length)
        {
            soundEffectSource.PlayOneShot(soundEffectsClips[footstepIndex]);
        }
    }

   
    public void PlayBulletSound()
    {
        int BulletIndex = 1;
        if (BulletIndex >= 1 && BulletIndex < soundEffectsClips.Length)
        {
            soundEffectSource.PlayOneShot(soundEffectsClips[BulletIndex]);
        }
    }

    public void PlayBombSound()
    {
        int bombIndex = 2;
        if (bombIndex >= 2 && bombIndex < soundEffectsClips.Length)
        {
            soundEffectSource.PlayOneShot(soundEffectsClips[bombIndex]);
        }
    }

    public void OpenDoorSound()
    {
        int Index = 3;
        if (Index >= 3 && Index < soundEffectsClips.Length)
        {
            soundEffectSource.PlayOneShot(soundEffectsClips[Index]);
        }
    }
    public void AdjustBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }

    public void AdjustSoundEffectsVolume(float volume)
    {
        soundEffectSource.volume = volume;
    }
}
