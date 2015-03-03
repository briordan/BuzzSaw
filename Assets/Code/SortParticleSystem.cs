using UnityEngine;
using System.Collections;

// [RequireComponent(typeof(SpriteRenderer))]
// [RequireComponent(typeof(ParticleSystem))]
public class SortParticleSystem : MonoBehaviour
{
    public string LayerName = "Particles";

    public void Start()
    {
         particleSystem.renderer.sortingLayerName = LayerName;
        // particleSystem.renderer.sortingOrder = -1;
        
    //    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
     //   particleSystem.renderer.sortingLayerID = spriteRenderer.sortingLayerID;
     //   particleSystem.renderer.sortingOrder = spriteRenderer.sortingOrder;

    }

}
