using UnityEngine;
using System.Collections.Generic;

public class AudioAnalyzer : MonoBehaviour
{
    public AudioSource audioSource; // ���ֲ������
    public float threshold = 0.1f; // ������ֵ���������ֵ��Ϊ��һ�������
    public List<float> beatTimes = new List<float>(); // �洢������ʱ��

    private float[] samples = new float[1024]; // �洢Ƶ�����ݵ�����

    void Start()
    {
        audioSource.Play(); // ��ʼ��������
    }

    void Update()
    {
        //Debug.Log("11111");
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris); // ��ȡƵ������
 
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
            beatTimes.Add(audioSource.time); // ��¼�����ʱ��
            // �ı�ĳ��GameObject������Ϊ"Visualizer"������ɫ
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
            beatTimes.Add(beatTime); // ��¼�����ʱ��
            Debug.Log("Beat detected at time: " + beatTime);
        }

    }
}
