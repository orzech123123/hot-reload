using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{
    [SerializeField] private Text _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;

    private float _timer;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 300;
    }

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = fps.ToString();
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}