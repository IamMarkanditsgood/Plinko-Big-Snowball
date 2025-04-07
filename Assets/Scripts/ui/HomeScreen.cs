using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballSize;
    [SerializeField] private TMP_Text _recordDistance;
    [SerializeField] private TMP_Text _recordSpeed;
    [SerializeField] private TMP_Text _name;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _rulesButton;

    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _rules;
    [SerializeField] private GameObject _view;

    [SerializeField] private AvatarManager _avatarManager;

    private void OnEnable()
    {
        _ballSize.text = PlayerPrefs.GetInt("RecordBallSize").ToString();
        _recordDistance.text = PlayerPrefs.GetInt("RecordDistance") + "m";
        _recordSpeed.text = PlayerPrefs.GetInt("RecordSpeed") + "m/s";

        _name.text = PlayerPrefs.GetString("Name", "User Name");

        _avatarManager.SetSavedPicture();
    }
    private void Start()
    {
        _playButton.onClick.AddListener(PlayGame);
        _settingsButton.onClick.AddListener(Settings);
        _rulesButton.onClick.AddListener(Rules);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(PlayGame);
        _settingsButton.onClick.RemoveListener(Settings);
        _rulesButton.onClick.RemoveListener(Rules);
    }

    private void PlayGame()
    {
        _gameScreen.SetActive(true);
        _view.SetActive(false);
    }
    private void Settings()
    {
        _settings.SetActive(true);
    }
    private void Rules()
    {
        _rules.SetActive(true);
    }
}
