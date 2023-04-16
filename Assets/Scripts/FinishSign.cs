using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSign : MonoBehaviour
{
        public TextMeshProUGUI levelSuccessText;
        public Image blackPanel;
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
                if (!other.CompareTag("Movable")) return;
                if (!other.gameObject.GetComponent<Movable>().isPlayer) return;
                
                other.gameObject.GetComponent<Movable>().Stop();
                other.gameObject.GetComponent<Animator>().Play("Win");
                levelSuccessText.DOFade(1, 1f).OnStart(() =>
                {
                        BackgroundMusic.Instance.PlaySuccessClip();
                });
                blackPanel.DOFillAmount(1, 0.5f)
                        .SetDelay(1.5f)
                        .OnStart(() =>
                        {
                                if (RetryCanvas.Instance != null)
                                {
                                        RetryCanvas.Instance.HideUI();
                                }
                        })
                        .OnComplete(() =>
                        { 
                                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                        });

        }
}