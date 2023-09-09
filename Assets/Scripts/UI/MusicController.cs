using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playButton;
    public Button pauseButton;
    public Button fastForwardButton;
    public Button rewindButton;
    public Slider progressBar;

    private void Start()
    {
        // ��ʼ����ť�ͽ��������¼�
        playButton.onClick.AddListener(PlayMusic);
        pauseButton.onClick.AddListener(PauseMusic);
        fastForwardButton.onClick.AddListener(FastForward);
        rewindButton.onClick.AddListener(Rewind);
        progressBar.onValueChanged.AddListener(UpdateMusicTime);
    }

    private void Update()
    {
        // ���½�����
        progressBar.value = audioSource.time / audioSource.clip.length;
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void FastForward()
    {
        audioSource.time += 5f;  // ���5��
    }

    public void Rewind()
    {
        audioSource.time -= 5f;  // ����5��
    }

    public void UpdateMusicTime(float value)
    {
        audioSource.time = value * audioSource.clip.length;
    }
}
