using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static AudioManager Instance;
    [SerializeField] private List<AudioClip> audioSources;

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

    public static void PlaySound(int musicNumber)
    {
        Instance.audioSource.PlayOneShot(Instance.audioSources[musicNumber]);
    }

    public static void StopPlaying()
    {
        Instance.audioSource.Stop();
    }

}
