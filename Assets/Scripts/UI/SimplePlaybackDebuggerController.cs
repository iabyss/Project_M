using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlaybackDebuggerController : MonoBehaviour
{
    public AudioSource audioSource; // 音频源
    public Button playPauseButton; // 播放/暂停按钮
    public TextMeshProUGUI buttonText; // 按钮上的文本组件
    public Button fastForwardButton; // 快进按钮
    public Button rewindButton; // 倒退按钮
    public Slider playbackSlider; // 播放进度条
    public Text timeDisplay; // 时间显示
    public Transform Record;
    public float rotationSpeed = 50f; // 旋转速度，你可以根据需要调整
    private bool isPlaying = false; // 是否正在播放



    void Start()
    {
        // 初始化按钮事件
        playPauseButton.onClick.AddListener(TogglePlayPause);
        fastForwardButton.onClick.AddListener(FastForward);
        rewindButton.onClick.AddListener(Rewind);

        // 初始化滑块
        playbackSlider.minValue = 0;
        playbackSlider.maxValue = audioSource.clip.length;
        playbackSlider.onValueChanged.AddListener(UpdatePlaybackPosition);

        isPlaying = true;
        audioSource.Play();
        buttonText.text = "Pause"; // 更新按钮文本
    }

    void UpdatePlaybackPosition(float newPosition)
    {
        audioSource.time = newPosition; // 更新音频播放位置
    }

    void Update()
    {
        // 更新播放进度条和时间显示
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
            buttonText.text = "Pause"; // 更新按钮文本
        }
        else
        {
            audioSource.Pause();
            buttonText.text = "Play"; // 更新按钮文本
        }
    }

    void FastForward()
    {
        audioSource.time += 5f; // 快进5秒
    }

    void Rewind()
    {
        audioSource.time -= 5f; // 倒退5秒
    }
}
