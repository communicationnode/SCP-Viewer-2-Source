using UnityEngine;
using System.Threading.Tasks;

sealed class AmbientAudioSourceManager : MonoBehaviour {
    /*
     * values
     */
    public  AudioClip[] AmbientClips;
    private AudioSource aSource;

    /*
     * methods
     */
    private void Start() {
        //elapse with random time random clips in aSource.
        if (TryGetComponent<AudioSource>(out aSource)) {

            //run async task.
            Task.Run(async () => {
                await Awaitable.MainThreadAsync();
                while (true) {

                    //set random clip.
                    int currentClip = Random.Range(0, AmbientClips.Length);
                    aSource.clip = AmbientClips[currentClip];
                    aSource.Play();

                    //set delay by clip length + random shitty seconds.
                    await Awaitable.WaitForSecondsAsync(AmbientClips[currentClip].length + Random.Range(3,6));
                }
            });
        }
    }
}
