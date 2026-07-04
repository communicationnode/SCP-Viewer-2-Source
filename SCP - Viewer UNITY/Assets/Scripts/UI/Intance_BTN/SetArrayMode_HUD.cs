using UnityEngine;

public class SetArrayMode_HUD : MonoBehaviour
{
    public void SetProp_MODE(){
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.Prop;
    }
    public void SetNPC_MODE(){
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.NPC;
    }
    public void SetSCP_MODE(){
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.SCP;
    }
    //~~~~~~~~~~~~~~~~Per update~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public void SetWEAPONS_MODE()
    {
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.Weapons;
    }
    public void SetTOOLS_MODE()
    {
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.Tools;
    }
    public void SetMAPS_MODE()
    {
        SpawnerManager.instance.ArrayMode = SpawnerManager.ArraySPAWNLIST.Maps;
    }
}
