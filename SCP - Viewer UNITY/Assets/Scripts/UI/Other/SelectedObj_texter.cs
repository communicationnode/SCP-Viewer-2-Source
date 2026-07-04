using UnityEngine;
using UnityEngine.UI;

public class SelectedObj_texter : MonoBehaviour
{
    private Text texter;
    public  Text textTutor;

    private void Start  (){
        texter = GetComponent<Text>();
    }
    private void Update (){
        string gettedtext   = textTutor.transform.gameObject.GetComponent<Localizator_SCP>().gettedText;
        textTutor.text      = SpawnerManager.instance.SelectedInstance != null  ?   gettedtext : "...";
        texter.text         = SpawnerManager.instance.SelectedInstance != null  ?   $"//[ {SpawnerManager.instance.SelectedInstance.name} ]\\\\" : $"//[ Object ]\\\\";
    }
}
