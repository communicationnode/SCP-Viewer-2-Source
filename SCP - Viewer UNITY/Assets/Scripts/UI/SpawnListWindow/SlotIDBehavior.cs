using UnityEngine;

public class SlotIDBehavior : MonoBehaviour {
    public int id = 0;
    public new string name = "undefined";

    public override string ToString() {
        return $@"index: {id}; name: {name}";
    }
}
