using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    [SerializeField] AudioClip engineBoost;
    [SerializeField] AudioClip succes;
    [SerializeField] AudioClip deathExplode;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SfxBoostPlay()
    {
       audioSource.PlayOneShot(engineBoost);
    }

    public void sfxSucces()
    {
        audioSource.PlayOneShot(succes);
    }

    public void sfxExplode()
    {
        audioSource.PlayOneShot(deathExplode);
    }
}
