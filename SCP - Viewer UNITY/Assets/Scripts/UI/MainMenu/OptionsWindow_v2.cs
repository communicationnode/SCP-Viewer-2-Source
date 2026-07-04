using UnityEngine;
using UnityEngine.UI;

public sealed class OptionsWindow_v2 : MonoBehaviour {

    [SerializeField] private Dropdown resolutionDropdown;

    private void Start() {
        /*
         * resolution
         */
        for (int i = 0; i < resolutionDropdown.options.Count; i++) {
            if (resolutionDropdown.options[i].text == PlayerPrefs.GetString(PlayerPrefsKeys.OPTIONS_RESOLUTION)) {
                resolutionDropdown.SetValueWithoutNotify(i);
            }
        }
        resolutionDropdown.onValueChanged.AddListener((value) => {
            ResolutionSet(resolutionDropdown.captionText.text);
        });
    }

    #region main options
    public void TextureQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY, quality);
        QualitySettings.globalTextureMipmapLimit = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY);
    }
    public void DPIQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DPI, quality);
        QualitySettings.resolutionScalingFixedDPIFactor = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_DPI);
    }
    public void FpsSet(int value) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_FPS, value);
        Application.targetFrameRate = value;
    }
    public void DynamicDetailsQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DECAL_DETAILS, quality);
    }
    public void PreviewPhotosQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_FILE_MANAGER_PREVIEWS, quality);
    }
    public void ResolutionSet(string resolution) {
        if (resolution.Contains('x')) {
            string[] splittedValue = resolution.Split('x');
            int width = 1920;
            int height = 1080;
            int.TryParse(splittedValue[0], out width);
            int.TryParse(splittedValue[1], out height);
            Screen.SetResolution(width, height, true);
            PlayerPrefs.SetString(PlayerPrefsKeys.OPTIONS_RESOLUTION, resolution);
        }
    }

    #endregion

    #region noise color
    public void NoiseColorSet(string rgb) {
        PlayerPrefs.SetString(PlayerPrefsKeys.OPTIONS_NOISE_COLOR, rgb);
    }
    public void NoiseColorIDSet(int index) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_NOISE_COLOR_INDEX, index);
    }
    public void NoiseEnable(int value) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_NOISE_ENABLED, value);
    }
    #endregion

    #region language
    public async void LanguageSet(int valueEnumer) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_LANGUAGE, valueEnumer);

        LocalizatorClass.isUpdating = true;

        await System.Threading.Tasks.Task.Delay(16);

        LocalizatorClass.isUpdating = false;

        await System.Threading.Tasks.Task.Yield();
    }
    #endregion

    #region reset options
    public void ResetQualityOptions() {
        SavedGraphicsData.FirstProgrammLoading();
        Screen.SetResolution(1920, 1080, true);
        LanguageSet(0);

    }
    #endregion

    #region post-processing
    //================== Post Processing =========================
    public void PostProcessingQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_POST_PROCESSING, quality);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    public void BloomQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_BLOOM, quality);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    public void ChromaticQualitySet(int quality) {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_CHROMATIC, quality);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    #endregion

    #region presets
    //================== Presets =========================
    public void LowPresets() {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DPI, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY, 2);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_MOTION_BLUR, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DECAL_DETAILS, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_FILE_MANAGER_PREVIEWS, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_POST_PROCESSING, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_BLOOM, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_CHROMATIC, 0);

        QualitySettings.globalTextureMipmapLimit = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY);
        QualitySettings.resolutionScalingFixedDPIFactor = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_DPI);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    public void MediumPresets() {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DPI, 2);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_MOTION_BLUR, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DECAL_DETAILS, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_POST_PROCESSING, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_BLOOM, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_CHROMATIC, 0);

        QualitySettings.globalTextureMipmapLimit = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY);
        QualitySettings.resolutionScalingFixedDPIFactor = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_DPI);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    public void HeighPresets() {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DPI, 3);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_MOTION_BLUR, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DECAL_DETAILS, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_POST_PROCESSING, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_BLOOM, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_CHROMATIC, 1);

        QualitySettings.globalTextureMipmapLimit = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY);
        QualitySettings.resolutionScalingFixedDPIFactor = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_DPI);
        //IfEnabledCameraShaking.ifEnabledStatic.CheckBlurOptions();
    }
    #endregion
}
