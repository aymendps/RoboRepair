using UnityEngine;
using UnityEngine.UI;


public class InputFieldAudio : MonoBehaviour
{
    public TargetManager targetManager;
    private bool clicked = false;
        private void Update()
        {
            if (Input.GetKeyDown("return") && !clicked && targetManager.runItButton.interactable)
            {
                targetManager.RunIt();
                clicked = true;
            }
            else
            {
                clicked = false;
            }
        }

        public void PlayKeyClip()
        {
            BackgroundMusic.Instance.PlayKeyClip();
        }
    }
