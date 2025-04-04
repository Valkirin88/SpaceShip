using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _heightText;
    [SerializeField]
    private TMP_Text _endText;
    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Transform _groundTransform;
    [SerializeField]
    private Transform _rocketTransform;

    private void Start()
    {
        Time.timeScale = 1.0f;
        _restartButton.onClick.AddListener(Restart);
    }

    private void Update()
    {
        int height = (int)Vector2.Distance(_rocketTransform.position, _groundTransform.position);


        _heightText.text = height.ToString();

        if (height > 149)
            ShowEnd();
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    private void ShowEnd()
    {
        _restartButton.gameObject.SetActive(true);
        _endText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(Restart);
    }
}
