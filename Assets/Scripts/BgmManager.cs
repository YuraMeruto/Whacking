using UnityEngine;

public class BgmManager
{
    AudioSource audio_source;
    public AudioSource AudioSource { get { return audio_source; } set { audio_source = value; } }
    public enum Status
    {
        None,
        Game,
    }

    public void Ini()
    {
        var obj = new GameObject();
        audio_source = obj.AddComponent<AudioSource>();
    }

    public void BgmPlay(Status status = Status.None)
    {
        switch(status)
        {
            case Status.Game:
                audio_source.clip = Resources.Load<AudioClip>(ResourcesAudio.BGM_DIRECTORY + ResourcesAudio.BGM_GAME);
                break;
        }
        audio_source.Play();
    }

    public void Stop()
    {
        audio_source.Stop();
    }
}
