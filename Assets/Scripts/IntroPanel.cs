using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour
{
        private void Start()
        {
                GetComponent<Image>().DOFillAmount(0, 0.5f)
                        .SetDelay(0.5f)
                        .OnComplete(()=>{gameObject.SetActive(false);});
        }
}