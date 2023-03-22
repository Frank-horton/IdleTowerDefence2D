using UnityEngine;

public class MusicValue : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _musicValue = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.volume = _musicValue;
    }

    public void SetMusic(float Vol)
    {
        _musicValue = Vol;
    }
}