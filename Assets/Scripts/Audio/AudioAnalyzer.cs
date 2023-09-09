using UnityEngine;
using System.Collections.Generic;

public class AudioAnalyzer : MonoBehaviour
{
    public AudioSource audioSource; // 音乐播放组件
    public float threshold = 0.1f; // 音量阈值，超过这个值认为是一个节奏点
    public List<float> beatTimes = new List<float>(); // 存储节奏点的时间

    private float[] samples = new float[1024]; // 存储频谱数据的数组

    void Start()
    {
        audioSource.Play(); // 开始播放音乐
    }

    void Update()
    {
        //Debug.Log("11111");
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris); // 获取频谱数据
 
        float sum = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i];
            //Debug.Log(samples[i]);
        }

        float average = sum / samples.Length;
        Debug.Log(average);
        if (average > threshold)
        {
            beatTimes.Add(audioSource.time); // 记录节奏点时间
            // 改变某个GameObject（如名为"Visualizer"）的颜色
            GameObject.Find("Visualizer").GetComponent<Renderer>().material.color = Color.red;
            //Debug.Log("222222");
            //Debug.Log("Beat detected at time: " + beatTime);
        }
        else
        {
            //Debug.Log("33333");
            GameObject.Find("Visualizer").GetComponent<Renderer>().material.color = Color.white;
        }

        if (average > threshold)
        {
            float beatTime = audioSource.time;
            beatTimes.Add(beatTime); // 记录节奏点时间
            Debug.Log("Beat detected at time: " + beatTime);
        }

    }
}
