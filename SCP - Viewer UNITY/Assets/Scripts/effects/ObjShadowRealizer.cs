using UnityEngine;
public sealed class ObjShadowRealizer : MonoBehaviour
{
    private Ray ray = new Ray();
    private Renderer rendererThis => GetComponent<Renderer>();


    private static System.Collections.Generic.Queue<GameObject> shadowsQueue = new System.Collections.Generic.Queue<GameObject>();
    private void Start()
    {
        shadowsQueue.Enqueue(this.gameObject);
        ray.direction = transform.up * -1;  
    }

    private void FixedUpdate()
    {
        try //shadows brain queued 
        {
            if (shadowsQueue.Peek() == this.gameObject)
            {
                ray.origin = transform.position;
                Physics.Raycast(ray, out RaycastHit OUTPUT);
                rendererThis.enabled = Vector3.Distance(transform.position, OUTPUT.point) < 1.5f ? true : false;
                shadowsQueue.Dequeue();
                shadowsQueue.Enqueue(this.gameObject);
            }
            else if (shadowsQueue.Peek() == null)
            {
                shadowsQueue.Dequeue();
            }
        }
        catch
        {
            //if man die or something idk
            shadowsQueue.Dequeue();
        }
    }
}
