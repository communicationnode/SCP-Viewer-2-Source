using UnityEngine;

public class GraphicSettingsAtStart : MonoBehaviour {
    private void Start() {
        SavedGraphicsData.GetGraphics();
        QualitySettings.vSyncCount = 0;
        QualitySettings.antiAliasing = 0;
    }
}
