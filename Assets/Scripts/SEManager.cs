using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager 
{
    AudioSource audio_source;
    public AudioSource AudioSource { get { return audio_source; } set { audio_source = value; } }
    public enum Status
    {
        None,
        EnemyDestory,
        EnemyDamage,
    }
    Status status_se;

    public void Ini()
    {
        var obj = new GameObject();
        audio_source = obj.AddComponent<AudioSource>();
    }

    public void PlaySe(Status status = Status.None)
    {
        if(status == status_se )
        {
            audio_source.Play();
            return;
        }
        switch(status)
        {
            case Status.None:
                break;
            case Status.EnemyDamage:
                audio_source.clip = Resources.Load<AudioClip>(ResourcesAudio.SE_DIRECTORY + ResourcesAudio.ENEMY_DAMAGE);
                break;
            case Status.EnemyDestory:
                audio_source.clip = Resources.Load<AudioClip>(ResourcesAudio.SE_DIRECTORY + ResourcesAudio.ENEMY_DESTORY);
                break;
        }
        status_se = status;
        audio_source.Play();
    }
}
