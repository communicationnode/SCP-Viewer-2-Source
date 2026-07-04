using UnityEngine;
using UnityEngine.Android;

public sealed class AvatarLoad : MonoBehaviour {

    /*
     * values
     */
    public string playerPrefsKeyName;

    /*
     * methods
     */
    public void GetFile() {
        NativeFilePicker.Permission permission = NativeFilePicker.RequestPermission();
        Debug.Log("Permission status: "+permission);

        NativeFilePicker.PickFile((path) => {
            SavePlayerPrefsPath(path);
        });
    }
    public void SavePlayerPrefsPath(in string fullName) => PlayerPrefs.SetString(playerPrefsKeyName, fullName);
}
