using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public sealed class InternetStatusRequestor : MonoBehaviour {
   
    /*
    * values
    */
    public static InternetStatusRequestor instance;
    public static bool isConnected = false;
    public Action OnNetAvailable = () => { };
    public Action OnNetFailure = () => { };
    private bool useEvents = true;


    /*
    * methods
    */
    private void Awake() {
        instance = this;

        Task.Run(async () => {
            await Awaitable.MainThreadAsync();
            while (true) {
                await Awaitable.WaitForSecondsAsync(isConnected is true ? 5 : 3);
                StartCoroutine(checkInternetConnection((isConnected) => {
                    InternetStatusRequestor.isConnected = isConnected;
                }));
            }
        });
    }

    private IEnumerator checkInternetConnection(Action<bool> action) {
        WWW www = new WWW("http://google.com");
        yield return www;

        if (www.error != null) {
            action(false);
            if (useEvents) {
                OnNetFailure();
                useEvents = false;
            }
        } 
        else {
            action(true);
            if (useEvents) {
                OnNetAvailable();
                useEvents = false;
            }
        }
    }
}
