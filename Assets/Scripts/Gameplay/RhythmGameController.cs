using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    public AudioSource audioSource; // 音乐播放组件
    public float[] beatTimes; // 音符出现的时间点
    private int nextBeatIndex = 0; // 下一个音符的索引
    private float score = 0; // 玩家得分

    void Start()
    {
        audioSource.Play(); // 开始播放音乐
    }

    void Update()
    {
        // 检测玩家点击（例如，使用鼠标左键）
        if (Input.GetButtonDown("Fire1"))
        {
            CheckBeat();
        }
    }

    void CheckBeat()
    {
        float currentTime = audioSource.time; // 当前音乐播放时间

        // 检查点击时间与音符时间的接近程度
        float timeDifference = Mathf.Abs(currentTime - beatTimes[nextBeatIndex]);

        // 根据时间差计算得分（这里只是一个简单的例子）
        if (timeDifference < 0.1f)
        {
            score += 100;
        }
        else if (timeDifference < 0.2f)
        {
            score += 50;
        }

        // 移动到下一个音符
        nextBeatIndex++;
    }
}
