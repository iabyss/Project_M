using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlaybackDebuggerController : MonoBehaviour
{
    public AudioSource audioSource; // ��ƵԴ
    public Button playPauseButton; // ����/��ͣ��ť
    public TextMeshProUGUI buttonText; // ��ť�ϵ��ı����
    public Button fastForwardButton; // �����ť
    public Button rewindButton; // ���˰�ť
    public Slider playbackSlider; // ���Ž�����
    public Text timeDisplay; // ʱ����ʾ
    public Transform Record;
    public float rotationSpeed = 50f; // ��ת�ٶȣ�����Ը�����Ҫ����
    private bool isPlaying = false; // �Ƿ����ڲ���



    void Start()
    {
        // ��ʼ����ť�¼�
        playPauseButton.onClick.AddListener(TogglePlayPause);
        fastForwardButton.onClick.AddListener(FastForward);
        rewindButton.onClick.AddListener(Rewind);

        // ��ʼ������
        playbackSlider.minValue = 0;
        playbackSlider.maxValue = audioSource.clip.length;
        playbackSlider.onValueChanged.AddListener(UpdatePlaybackPosition);

        isPlaying = true;
        audioSource.Play();
        buttonText.text = "Pause"; // ���°�ť�ı�
    }

    void UpdatePlaybackPosition(float newPosition)
    {
        audioSource.time = newPosition; // ������Ƶ����λ��
    }

    void Update()
    {
        // ���²��Ž�������ʱ����ʾ
        if (isPlaying)
        {
            playbackSlider.value = audioSource.time;
            Record.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        timeDisplay.text = $"{audioSource.time:F2} / {audioSource.clip.length:F2}";
    }

    void TogglePlayPause()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            audioSource.Play();
            buttonText.text = "Pause"; // ���°�ť�ı�
        }
        else
        {
            audioSource.Pause();
            buttonText.text = "Play"; // ���°�ť�ı�
        }
    }

    void FastForward()
    {
        audioSource.time += 5f; // ���5��
    }

    void Rewind()
    {
        audioSource.time -= 5f; // ����5��
    }
}
