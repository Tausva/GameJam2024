using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip)
    {
        Instance.audioSource.PlayOneShot(clip);
    }

    public static void StopPlaying()
    {
        Instance.audioSource.Stop();
    }

}
