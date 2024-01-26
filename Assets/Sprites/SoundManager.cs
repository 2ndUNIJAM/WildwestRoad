using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }
 

    [SerializeField]
    private Sound[] _bgm = null;
    [SerializeField]
    private Sound[] _sfx = null;
    [SerializeField]
    private AudioSource _bgmPlayer = null;
    public List<AudioSource> sfxPlayers = new List<AudioSource>();

    private void Start()
    {
        // SFX 플레이어 몇 개를 초기에 생성하고 리스트에 추가
        for (int i = 0; i < 30; i++)
        {
            AudioSource sfxPlayer = gameObject.AddComponent<AudioSource>();
            sfxPlayers.Add(sfxPlayer);
        }
    }

    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < _bgm.Length; i++)
        {
            if (bgmName == _bgm[i].name)
            {
                _bgmPlayer.clip = _bgm[i].clip;
                _bgmPlayer.Play();
                return;
            }
        }
    }

    public void StopBGM()
    {
        _bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName, float volume = 1.0f)
    {
        for (int i = 0; i < _sfx.Length; i++)
        {
            if (sfxName == _sfx[i].name)
            {
                AudioSource sfxPlayer = GetAvailableSFXPlayer();
                sfxPlayer.clip = _sfx[i].clip;
                sfxPlayer.volume = volume;
                sfxPlayer.Play();
                return;
            }
        }
    }

    private AudioSource GetAvailableSFXPlayer()
    {
        for (int i = 0; i < sfxPlayers.Count; i++)
        {
            if (!sfxPlayers[i].isPlaying)
            {
                return sfxPlayers[i];
            }
        }

        // 모든 SFX 플레이어가 사용 중이므로 새 플레이어를 생성하고 리스트에 추가
        AudioSource newSFXPlayer = gameObject.AddComponent<AudioSource>();
        sfxPlayers.Add(newSFXPlayer);
        return newSFXPlayer;
    }
}
