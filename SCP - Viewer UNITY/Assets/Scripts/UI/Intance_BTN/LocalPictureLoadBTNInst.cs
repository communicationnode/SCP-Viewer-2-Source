using UnityEngine.UI;
using UnityEngine;

public class LocalPictureLoadBTNInst : MonoBehaviour {
    /*
     * values
     */
    private Image image;
    private string updateTextCheck;
    private string cachedResourceName;

    /*
     * methods
     */
    private async void Start() {
        TryGetComponent<Image>(out image);
        Sprite cachedNullSprite = image.sprite;

        while (true) {
            await Awaitable.NextFrameAsync();
            try {
                if (gameObject.activeSelf == false) continue;

                string slotName = transform.parent.GetChild(0).GetComponent<Text>().text;
                if (cachedResourceName != $"SpawnListPictures/{slotName}") {
                    cachedResourceName = $"SpawnListPictures/{slotName}";

                    if (updateTextCheck != slotName) {
                        updateTextCheck = slotName;

                        var imageResource = Resources.Load($"SpawnListPictures/{slotName}", typeof(Sprite));

                        if (imageResource != null) {
                            image.sprite = imageResource as Sprite;
                        } else {
                            image.sprite = cachedNullSprite;
                        }
                    }
                }

            } catch {
                return;
            }
        }
    }
}
