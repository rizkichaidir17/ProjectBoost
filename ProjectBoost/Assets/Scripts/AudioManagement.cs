using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource boostEngine;

    public void SfxBoostPlay()
    {
        if(!boostEngine.isPlaying)
        {
            boostEngine.Play();
        }
    }
    public void SfxBoostStop()
    {
        boostEngine.Stop();
    }
}
