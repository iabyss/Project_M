using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    public AudioSource audioSource; // ���ֲ������
    public float[] beatTimes; // �������ֵ�ʱ���
    private int nextBeatIndex = 0; // ��һ������������
    private float score = 0; // ��ҵ÷�

    void Start()
    {
        audioSource.Play(); // ��ʼ��������
    }

    void Update()
    {
        // �����ҵ�������磬ʹ����������
        if (Input.GetButtonDown("Fire1"))
        {
            CheckBeat();
        }
    }

    void CheckBeat()
    {
        float currentTime = audioSource.time; // ��ǰ���ֲ���ʱ��

        // �����ʱ��������ʱ��Ľӽ��̶�
        float timeDifference = Mathf.Abs(currentTime - beatTimes[nextBeatIndex]);

        // ����ʱ������÷֣�����ֻ��һ���򵥵����ӣ�
        if (timeDifference < 0.1f)
        {
            score += 100;
        }
        else if (timeDifference < 0.2f)
        {
            score += 50;
        }

        // �ƶ�����һ������
        nextBeatIndex++;
    }
}
