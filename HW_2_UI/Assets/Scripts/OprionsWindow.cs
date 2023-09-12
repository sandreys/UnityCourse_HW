using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OprionsWindow : MonoBehaviour
{
    [SerializeField] private Button _creditButton;

    [SerializeField] private Button _cinematicButton;

    [SerializeField] private Toggle _fullScreenToggle;

    [SerializeField] private Toggle _soundBackgroundToggle;

    [SerializeField] private Toggle _challengeNearbyPlayersToggle;

    [SerializeField] private Toggle _allowFriendsSpectateToggle;

    [SerializeField] private Slider _masterVolumeSlider;

    [SerializeField] private Slider _musicVolumeSlider;

    [SerializeField] private TMP_Dropdown _resoltionDropdown;

    [SerializeField] private TMP_Dropdown _qualityDropdown;
    void Start()
    {      
        _creditButton.onClick.AddListener(OnCreditButtOnClickHandler);
        _cinematicButton.onClick.AddListener(OnCinematicButtOnClickHandler);
        _fullScreenToggle.onValueChanged.AddListener(OnFullScreenToggleChangeHandler);
        _soundBackgroundToggle.onValueChanged.AddListener(OnSoundBackgroundToggleChangeHandler);
        _challengeNearbyPlayersToggle.onValueChanged.AddListener(OnChallengeNearbyPlayersToggleChangeHandler);
        _allowFriendsSpectateToggle.onValueChanged.AddListener(OnAllowFriendSpectateToggleHandler);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderValueChangeHandler);
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChangeHandler);
        _resoltionDropdown.onValueChanged.AddListener(OnResolutionDropdownValueChangedHandler);
        _qualityDropdown.onValueChanged.AddListener(OnQualityDropdownValueChangeHandler);
    }
    void Update()
    {

    }
    private void OnCreditButtOnClickHandler()
    {
        Debug.Log($"[{GetType().Name}[OnCreditButtonClickHandler] OK");
    }

    private void OnCinematicButtOnClickHandler()
    {
        Debug.Log($"[{GetType().Name}[OnCinematicButtonClickHandler] OK");
    }

    private void OnFullScreenToggleChangeHandler(bool value)
    {
        Debug.Log($"[{GetType().Name}[OnFullScreenToggleChangeHandler] OK , value: {value}");
    }

    private void OnSoundBackgroundToggleChangeHandler(bool value)
    {
        Debug.Log($"[{GetType().Name}[OnSoundBackgroundToggleChangeHandler] OK , value: {value}");
    }

    private void OnChallengeNearbyPlayersToggleChangeHandler(bool value)
    {
        Debug.Log($"[{GetType().Name}[OnChallengeNearbyPlayersToggleChangeHandler] OK, value:{value}");
    }

    private void OnAllowFriendSpectateToggleHandler(bool value)
    {
        Debug.Log($"[{GetType().Name}[OnAllowFriendSpectateToggleHandler] OK, value:{value}");
    }

    private void OnMasterVolumeSliderValueChangeHandler(float value)
    {
        Debug.Log($"[{GetType().Name}[OnMasterVolumeSliderValueChangeHandler] new value:{value}");
    }

    private void OnMusicVolumeSliderValueChangeHandler(float value)
    {
        Debug.Log($"[{GetType().Name}[OnMusicVolumeSliderValueChangeHandler] new value:{value}");
    }

    private void OnResolutionDropdownValueChangedHandler(int value)
    {
        Debug.Log($"[{GetType().Name}[OnResolutionDropdownValueChangedHandler] index:{value} , value {_resoltionDropdown.options[value].text}");
    }

    private void OnQualityDropdownValueChangeHandler(int value)
    {
        Debug.Log($"[{GetType().Name}[OnQualityDropdownValueChangeHandler] index:{value} , value {_qualityDropdown.options[value].text}");
    }
}
