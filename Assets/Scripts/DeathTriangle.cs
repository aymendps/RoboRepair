using UnityEngine;
public class DeathTriangle : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D other)
     {
          if (!other.gameObject.CompareTag("Movable")) return;
          if (!other.gameObject.GetComponent<Movable>().isPlayer) return;
          
          RetryCanvas.Instance.Retry();
          
     }
}