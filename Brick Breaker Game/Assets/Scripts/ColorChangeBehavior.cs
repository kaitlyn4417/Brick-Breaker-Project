using UnityEngine;

public class ColorChangeBehavior : MonoBehaviour
{
    public ColorData[] colorOptions;

    private void OnCollisionEnter(Collision collision)
    {
        ChangeColorRandomly();
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeColorRandomly();
    }

    private void ChangeColorRandomly()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && colorOptions != null && colorOptions.Length > 0)
        {
            ColorData randomColorData = colorOptions[Random.Range(0, colorOptions.Length)];
            renderer.material.color = randomColorData.color;
        }
    }
}

