using UnityEngine;

public class DestroyBlockBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        DestroyObjectDelayed(gameObject, 0.1f);
    }

   private void DestroyObjectDelayed(GameObject obj, float delay)
    {
        Destroy(obj, delay);
    }
}

