using UnityEngine;
using System.Collections;

public class PointStar : MonoBehaviour, IPlayerRespawnListner
{
    public GameObject Effect;
    public int PointsToAdd = 10;
    public AudioClip HitStarSound;
    public Animator Animator;
    public SpriteRenderer Renderer;

    private bool _isCollected;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_isCollected)
            return;

        if (other.GetComponent<Player>() == null)
            return;
        
        if (HitStarSound != null)
            AudioSource.PlayClipAtPoint(HitStarSound, transform.position);

        GameManager.Instance.AddPoints(PointsToAdd);
        Effect.renderer.sortingLayerName = "Particles";
        Instantiate(Effect, transform.position, transform.rotation);

        // gameObject.SetActive(false);

        FloatingText.Show(string.Format("+{0}!", PointsToAdd), "PointStarText",
            new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));

        _isCollected = true;
        Animator.SetTrigger("Collect");
    }

    public void FinishAnimationEvent()
    {
        Debug.Log("Finished Collect Animation");
        Renderer.enabled = false;
    }

    public void OnPlayerRespawnInThisCheckpoint(Checkpoint checkpoint, Player player)
    {
        _isCollected = false;
        Animator.SetTrigger("Reset"); 
        Renderer.enabled = true;

    }
}
