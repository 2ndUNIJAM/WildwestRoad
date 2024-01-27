using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{


    [System.Serializable]
    public class Sound
    {
        public SoundType SoundType;
        public AudioClip clip;
    }
    [SerializeField]
    private List<Sound> _bgms;
    [SerializeField]
    private List<Sound> _sfxs = null;
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

    public void PlayBGM(SoundType soundType)
    {
        var bgm = _bgms.First(b => b.SoundType == soundType);
        _bgmPlayer.clip = bgm.clip;
        _bgmPlayer.Play();
        return;
    }

    public void StopBGM()
    {
        _bgmPlayer.Stop();
    }

    public void PlaySFX(SoundType soundType, float volume = 1.0f)
    {
        for (int i = 0; i < _sfxs.Count; i++)
        {
            if (soundType == _sfxs[i].SoundType)
            {
                AudioSource sfxPlayer = GetAvailableSFXPlayer();
                sfxPlayer.clip = _sfxs[i].clip;
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
public enum SoundType
{
   MenuBGM=0,
   BGM2=1,
   CharSelectSfx=2,
   HeartHit=3,
   BulletSfx=4,
   BulletSfx2=5,
   BulletSfx3=6,
   FallingBullet=7,
   RevolvingSfx =8,
   ReloadingSfx=9,
   AvoidBullet=10,
   NadeshikoHit1 = 11,
   NadeshikoHit2 = 12,
   NadeshikoSfx=13,
   RestCharSfx=14,
   RangerHit=15,
   RockyHit=16,
   MaxHit=17,
   WinGame=18,
   DrawGame=19,
   SwallowSfx=20,
   CountGame=21,
   BtnMove=22

}
