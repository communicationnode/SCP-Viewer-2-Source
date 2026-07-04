using UnityEngine.UI;
using UnityEngine;

public class ReadPictureObject : MonoBehaviour
{
    private Image   imgSource;
    private string  updateTextCheck;
    async void OnEnable(){
        imgSource = GetComponent<Image>();

        await System.Threading.Tasks.Task.Delay(50);
        LoadPicture();
        await System.Threading.Tasks.Task.Yield();
    }
    private void LoadPicture(){
        if (SpawnerManager.instance.SelectedInstance is null) return;

        string slotName = SpawnerManager.instance.SelectedInstance.name;
        if (updateTextCheck != slotName)
        {
            updateTextCheck = slotName;
            SpawnerManager.UltimateModReferences modReferences = SpawnerManager.instance.TryGetModResources(slotName);
            if (modReferences != null)
            {
                imgSource.sprite = modReferences.icon;
                return;
            }
            else
            {
                imgSource.sprite = Resources.Load($"SpawnListPictures/{SpawnerManager.instance.SelectedInstance.name}", typeof(Sprite)) as Sprite;
            }
        }           
    }
}
