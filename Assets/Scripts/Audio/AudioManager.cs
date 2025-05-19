using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource backgroundAudioSorce;
    [SerializeField] private AudioSource effectAudioSorce;
    [SerializeField] private AudioClip JumpAudioClip;
    [SerializeField] private AudioClip coinAudioClip;
    [SerializeField] private AudioClip backgroundAudioClip;

    void Awake()
    {
        // Đảm bảo chỉ có 1 AudioManager duy nhất tồn tại
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Xoá bản duplicate
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Giữ lại qua các scene
    }

    void Start()
    {
        HandleBackgroundAudio();
    }

    public void HandleBackgroundAudio()
    {
        backgroundAudioSorce.clip = backgroundAudioClip;
        backgroundAudioSorce.loop = true;
        backgroundAudioSorce.Play();
    }

    public void HandleJumpAudio()
    {
        effectAudioSorce.PlayOneShot(JumpAudioClip);
    }

    public void HandleCoinAudio()
    {
        effectAudioSorce.PlayOneShot(coinAudioClip);
    }
}
