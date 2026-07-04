using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SpawnListHudNew : MonoBehaviour {


    // FIELDS
    [SerializeField] private GameObject slotTemplate;
    [SerializeField] private Transform contentTransform;


    // UNITY FUNCTIONAL
    private void OnEnable() {
        CreateSlots();
    }
    private void OnDisable() {
        ClearContent();
    }


    // FUNCTIONAL
    private void CreateSlots() {
        Task.Run(async () => {

            // fckn bug fixer (yes, delay fix my old bugs, fuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuck!!!!!!)
            await Task.Delay(512);
            await Awaitable.MainThreadAsync();

            // if active was disabled before delay - return;
            if (gameObject.activeSelf is false) return;

            // safe block
            var currentCollection = GetCurrentArray();
            if (currentCollection.Count <= 0) return;

            // create slots
            int index = 0;
            foreach (var item in currentCollection) {
                var slot = GameObject.Instantiate(slotTemplate, contentTransform);

                // get components as fields
                var imageComponent = slot.transform.GetChild(0).GetComponent<Image>();
                var buttonComponent = slot.transform.GetChild(0).GetComponent<Button>();
                var slotIdComponent = slot.transform.GetChild(0).GetComponent<SlotIDBehavior>();
                var textComponent = slot.transform.GetChild(1).GetComponent<Text>();

                // set values to slot ID component
                slotIdComponent.id = index;
                slotIdComponent.name = item.name;

                // set text component value
                textComponent.text = item.name;

                // bind custom event to button
                buttonComponent.onClick.AddListener(() => {
                    SpawnerManager.instance.SelectObject(slotIdComponent.id);
                    SpawnerManager.instance.SelectedInstance = item;
                });

                // load slot avatar
                LoadImage(imageComponent, $@"SpawnListPictures/{item.name}");

                // last operations
                slot.name = item.name;
                slot.SetActive(true);
                index++;
            }
        });
    }
    private void ClearContent() {
        for (int i = 0; i < contentTransform.childCount; i++) {
            GameObject.Destroy(contentTransform.GetChild(i).gameObject);
        }
    }
    private void LoadImage(Image image, in string path) {
        var resourceRequest = Resources.LoadAsync<Sprite>(path);
        resourceRequest.completed += (asyncOperation) => { image.sprite = (asyncOperation as ResourceRequest).asset as Sprite; };
    }
    private ReadOnlyCollection<GameObject> GetCurrentArray() {
        switch (SpawnerManager.instance.ArrayMode) {
            case SpawnerManager.ArraySPAWNLIST.Prop: { }
                return SpawnerManager.instance.PropsArray.AsReadOnly();
            case SpawnerManager.ArraySPAWNLIST.NPC: { }
                return SpawnerManager.instance.NPCArray.AsReadOnly();
            case SpawnerManager.ArraySPAWNLIST.SCP: { }
                return SpawnerManager.instance.SCPArray.AsReadOnly();
            case SpawnerManager.ArraySPAWNLIST.Weapons: { }
                return SpawnerManager.instance.WeaponsArray.AsReadOnly();
            case SpawnerManager.ArraySPAWNLIST.Tools: { }
                return SpawnerManager.instance.ToolsArray.AsReadOnly();
            case SpawnerManager.ArraySPAWNLIST.Maps: { }
                return SpawnerManager.instance.MapsArray.AsReadOnly();
            default:
                return null;
        }
    }
}
