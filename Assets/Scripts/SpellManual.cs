using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SpellManual : MonoBehaviour
{
    public static SpellManual Instance { get; private set; }

    public bool hasVelocity;
    public bool hasGravity;
    public bool hasForce;

    public List<Sprite> manualPages = new List<Sprite>();
    public List<Button> manualButtons = new List<Button>();

    private Image _currentImage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentImage = GetComponent<Image>();
    }

    private void Update()
    {
        manualButtons[0].interactable = hasVelocity;
        manualButtons[1].interactable = hasGravity;
        manualButtons[2].interactable = hasForce;
    }

    public void ShowUI(bool show)
    {
        transform.DOLocalMoveX(show ? 709f : 1214f, 0.5f);
    }

    public void SetManualImage(int index)
    {
        _currentImage.sprite = manualPages[index];
    }
}