using UnityEngine;
using UnityEngine.UI;

public class Instance_BTN : MonoBehaviour {
    public int SlotID;
    public string SlotNamespace;
    protected Text _text;
    protected GameObject gettedItem;
    protected Button _button => GetComponent<Button>();


    public void Awake() {
        _text = transform.GetChild(0).GetComponent<Text>();
    }
    public void Update() {
        int OriginalSlotID = SlotID + SpawnerManager.instance.ArrayOffset;

        switch (SpawnerManager.instance.ArrayMode) {

            case SpawnerManager.ArraySPAWNLIST.Prop:
                try {
                    _text.text = $"{SpawnerManager.instance.PropsArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.PropsArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;

            case SpawnerManager.ArraySPAWNLIST.NPC:
                try {
                    _text.text = $"{SpawnerManager.instance.NPCArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.NPCArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;

            case SpawnerManager.ArraySPAWNLIST.SCP:
                try {
                    _text.text = $"{SpawnerManager.instance.SCPArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.SCPArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~Per update~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            case SpawnerManager.ArraySPAWNLIST.Weapons:
                try {
                    _text.text = $"{SpawnerManager.instance.WeaponsArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.WeaponsArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;
            case SpawnerManager.ArraySPAWNLIST.Tools:
                try {
                    _text.text = $"{SpawnerManager.instance.ToolsArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.ToolsArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;
            case SpawnerManager.ArraySPAWNLIST.Maps:
                try {
                    _text.text = $"{SpawnerManager.instance.MapsArray[OriginalSlotID]?.transform?.gameObject?.name}" ?? "NULL";
                    _text.color = new Color(132, 132, 132, 255);
                    gettedItem = SpawnerManager.instance.MapsArray[OriginalSlotID].transform.gameObject;
                } catch {
                    _text.text = "None";
                    _text.color = new Color(0.3018868f, 0.1519968f, 0.1409754f, 1);
                }
                break;

            default:
                return;
        }
        _button.onClick.AddListener(OnClick);
    }
    protected void OnClick() {
        SpawnerManager.instance.SelectedInstance = gettedItem;
    }
}
