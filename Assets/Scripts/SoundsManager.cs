using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource backgroundAudioSource;

    public AudioClip Alarm_1;
    public AudioClip Alarm_2;
    public AudioClip Alarm_3;
    public AudioClip Alarm_4;
    public AudioClip NewBall;
    public AudioClip BallLoss;
    public AudioClip Bonus_1;
    public AudioClip Bonus_2;
    public AudioClip Bumper_1;
    public AudioClip Bumper_2;
    public AudioClip FlipperUp;
    public AudioClip FlipperDown;
    public AudioClip MapStart;
    public AudioClip Launcher;
    public AudioClip ButtonHover;
    public AudioClip ButtonClick;
    public AudioClip RickAndMortyTheme;

    private void Start()
    {
        backgroundAudioSource.priority = 255;
        backgroundAudioSource.spatialBlend = 0.55f;
        audioSource.priority = 0;
    }

    public void PlayRickAndMortyTheme()
    {
        backgroundAudioSource.loop = true;
        backgroundAudioSource.clip = RickAndMortyTheme;
        backgroundAudioSource.volume = 0.5f;
        backgroundAudioSource.Play();
    }

    public void PlayAlarm1 ()
    {
        audioSource.PlayOneShot(Alarm_1);
    }

    public void PlayAlarm2 ()
    {
        audioSource.PlayOneShot(Alarm_2);
    }

    public void PlayAlarm3 ()
    {
        audioSource.PlayOneShot(Alarm_3);
    }

    public void PlayAlarm4 ()
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(Alarm_4);
        audioSource.volume = 1;
    }

    public void PlayBonus1 ()
    {
        audioSource.PlayOneShot(Bonus_1);
    }

    public void PlayBonus2 ()
    {
        audioSource.PlayOneShot(Bonus_2);
    }

    public void PlayBallLoss ()
    {
        audioSource.PlayOneShot(BallLoss);
    }

    public void PlayNewBall ()
    {
        audioSource.PlayOneShot(NewBall);
    }

    public void PlayBumper1()
    {
        audioSource.PlayOneShot(Bumper_1);
    }

    public void PlayBumper2()
    {
        audioSource.PlayOneShot(Bumper_2);
    }

    public void PlayFlipperDown()
    {
        audioSource.PlayOneShot(FlipperDown);
    }

    public void PlayFlipperUp()
    {
        audioSource.PlayOneShot(FlipperUp);
    }

    public void PlayMapStart()
    {
        audioSource.PlayOneShot(MapStart);
    }

    public void PlayLauncher()
    {
        audioSource.PlayOneShot(Launcher);
    }

    public void PlayButtonHover()
    {
        audioSource.PlayOneShot(ButtonHover);
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(ButtonClick);
    }
}
