using UnityEngine;
using UnityEngine.UI;

public sealed class LastObjectsList : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private readonly SimpleDelayer delayer = new SimpleDelayer(100);

    private  void Update(){

        delayer.Move();
        if (delayer.OnElapsed())
        {
            if (SpawnerManager.instance.lastSelectedList.ToArray().Length <= 0 || SpawnerManager.instance.lastSelectedList.ToArray().Length > 6)
            {
                return;
            }
            for (int i = 0; i < SpawnerManager.instance.lastSelectedList.ToArray().Length; i++)
            {
                buttons[i].transform.GetChild(0).GetComponent<Text>().text = SpawnerManager.instance.lastSelectedList[i] != null ? SpawnerManager.instance.lastSelectedList[i].name : "NULL";
            }
        }
    }
}
