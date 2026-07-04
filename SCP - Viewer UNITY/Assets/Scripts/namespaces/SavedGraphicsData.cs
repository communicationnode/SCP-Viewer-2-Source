using UnityEngine;
public static class SavedGraphicsData {
    public static void GetGraphics() {
        /*
         * if game was started at first - run this
         */
        if (PlayerPrefs.GetInt(PlayerPrefsKeys.STATISTICS_FIRST_LOAD) == 0) {
            FirstProgrammLoading();
            return;
        }

        /*
         * DPI
         */
        QualitySettings.resolutionScalingFixedDPIFactor = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_DPI);

        /*
         * FPS
         */
        if (!PlayerPrefs.HasKey(PlayerPrefsKeys.OPTIONS_FPS) || PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_FPS) < 25) {
            PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_FPS, 32);
        }
        Application.targetFrameRate = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_FPS);

        /*
         * texture mipmap quality
         */
        QualitySettings.globalTextureMipmapLimit = PlayerPrefs.GetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY);

        /*
         * resolution
         */
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.OPTIONS_RESOLUTION) is false){
            PlayerPrefs.SetString(PlayerPrefsKeys.OPTIONS_RESOLUTION, "1920x1080");
            Screen.SetResolution(1920, 1080,true);
        }
    }

    public static void FirstProgrammLoading() {
        PlayerPrefs.SetInt(PlayerPrefsKeys.STATISTICS_FIRST_LOAD, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DPI, 2);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_FPS, 45);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_TEXTURE_QUALITY, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_MOTION_BLUR, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_DECAL_DETAILS, 1);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_POST_PROCESSING, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_BLOOM, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_CHROMATIC, 0);
        PlayerPrefs.SetString(PlayerPrefsKeys.OPTIONS_NOISE_COLOR, "1,1,1,0.07f");
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_NOISE_COLOR_INDEX, 0);
        PlayerPrefs.SetInt(PlayerPrefsKeys.OPTIONS_NOISE_ENABLED, 0);
        PlayerPrefs.SetString(PlayerPrefsKeys.OPTIONS_RESOLUTION, "1920x1080");

        GetGraphics();
    }
}