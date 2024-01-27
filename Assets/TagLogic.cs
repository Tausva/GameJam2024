using Assets.Scripts.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TagLogic : MonoBehaviour
{
    [SerializeField] private List<TagSprite> sprites = new List<TagSprite>();

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(Tag tag)
    {
        image.sprite = sprites.First(s => s.Type == tag).Sprite;
    }
}
