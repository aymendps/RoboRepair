using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class RetryCanvas : MonoBehaviour
{
        public static RetryCanvas Instance;
        public List<GameObject> batteries = new List<GameObject>();
        public GameObject ui;
        public GameObject lostScreen;

        private int _remainingTries = 2;

        private void Awake()
        {
                if (Instance != null && Instance != this)
                {
                        Destroy(gameObject);
                }
                else
                {
                        Instance = this;
                        DontDestroyOnLoad(gameObject);
                }
        }

        public void ShowUI()
        {
                ui.SetActive(true);
        }

        public void HideUI()
        {
                ui.SetActive(false);
        }

        public void Retry()
        {
                if (_remainingTries - 1 < -1)
                {
                        lostScreen.SetActive(true);
                        return;
                }
                
                batteries[_remainingTries].SetActive(false);
                _remainingTries--;
                var blackPanel = GameObject.Find("Black Panel").GetComponent<Image>();
                blackPanel.DOFillAmount(1, 0.5f)
                        .OnStart(() =>
                        {
                                RetryCanvas.Instance.HideUI();
                        })
                        .OnComplete(() =>
                        { 
                                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                        });
        }

        public void Restart()
        {
                foreach (var battery in batteries)
                {
                        battery.SetActive(true);
                }
                _remainingTries = 2;
                HideUI();
                lostScreen.SetActive(false);
                Destroy(gameObject);
                SceneManager.LoadScene(0);
        }
}