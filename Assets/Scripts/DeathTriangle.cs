using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathTriangle : MonoBehaviour
{
     public Image blackPanel;
     private void OnCollisionEnter2D(Collision2D other)
     {
          if (!other.gameObject.CompareTag("Movable")) return;
          if (!other.gameObject.GetComponent<Movable>().isPlayer) return;
          
          blackPanel.DOFillAmount(1, 0.5f)
               .OnComplete(() =>
               { 
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
               });
     }
}