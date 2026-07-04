using System.Threading.Tasks;
using UnityEngine;

public class BTN_UpToDown : MonoBehaviour {
    /*
     * values
     */
    [SerializeField] private AudioSource clickAudioSource;
    [SerializeField] private AudioSource boundsAudioSource;
    [SerializeField, Range(0.07f, 0.5f)] private float stepSpeed = 0.07f;
    private int stepCount = 5;

    /*
     * methods
     */
    public void ArraySetUp() => Task.Run(MoveUp);
    public void ArraySetDown() => Task.Run(MoveDown);

    public async void MoveUp() {
        await Awaitable.MainThreadAsync();

        for (short i = 0; i < stepCount; i++) {
            //wait while clip will play 1\4 of himself time + add stepSpeed value
            await Awaitable.WaitForSecondsAsync(clickAudioSource.clip.length*0.3f+ stepSpeed);

            clickAudioSource.Play();

            //if bounds
            if (SpawnerManager.instance.ArrayOffset == 0) {
                boundsAudioSource.Play();
                break;
            }

            //clamping
            SpawnerManager.instance.ArrayOffset = Mathf.Clamp(SpawnerManager.instance.ArrayOffset - 1, 0, 999);
        }
    }
    public async void MoveDown() {
        await Awaitable.MainThreadAsync();

        for (short i = 0; i < stepCount; i++) {
            //wait while clip will play 1\4 of himself time + add stepSpeed value
            await Awaitable.WaitForSecondsAsync(clickAudioSource.clip.length * 0.3f+stepSpeed);

            clickAudioSource.Play();

            //clamping
            SpawnerManager.instance.ArrayOffset = Mathf.Clamp(SpawnerManager.instance.ArrayOffset + 1, 0, 999);
            clickAudioSource.Play();
        }
    }
}
