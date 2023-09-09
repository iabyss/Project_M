using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    public int numberOfSamples = 64; // 通常为2的幂
    public float spacing = 0.2f;
    public float scale = 10;

    private GameObject[] sampleCubes;
    private AudioSource audioSource;

    void Start()
    {
        // 初始化音频源
        audioSource = GetComponent<AudioSource>();

        // 初始化柱状图
        sampleCubes = new GameObject[numberOfSamples];
        for (int i = 0; i < numberOfSamples; i++)
        {
            GameObject cube = Instantiate(sampleCubePrefab);
            cube.transform.position = new Vector3(i * spacing, 0, 0);
            cube.transform.parent = transform;
            sampleCubes[i] = cube;
        }
    }

    void Update()
    {
        // 获取音频数据
        float[] spectrum = new float[numberOfSamples];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // 更新柱状图
        for (int i = 0; i < numberOfSamples; i++)
        {
            if (sampleCubes[i] != null)
            {
                Vector3 previousScale = sampleCubes[i].transform.localScale;
                previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * scale, Time.deltaTime * 0.5f);
                sampleCubes[i].transform.localScale = previousScale;
            }
        }
    }
}
