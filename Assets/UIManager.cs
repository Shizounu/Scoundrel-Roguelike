using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public PlayerManager playerManager;
    public List<int> CurrentSelection = new();

    [Header("UI Object References")]
    public CardSlot CardSlot0 = new();
    public CardSlot CardSlot1 = new();
    public CardSlot CardSlot2 = new();
    public CardSlot CardSlot3 = new();
    [Space(), Header("Color Reference")]
    public Color SoloSelectColor;
    public Color MultiSelectColor;

    private void LateUpdate()
    {
        //Update Visuals
        for (int i = 0; i < playerManager.CurrentCards.Count; i++) {
            if (playerManager.CurrentCards[i] != null)
            {
                IndexToSlot(i).Image.sprite = playerManager.CurrentCards[i].CardSprite;
                IndexToSlot(i).SetVisible();
            } else {
                IndexToSlot(i).SetInvisible();
            }
            IndexToSlot(i).SetUnselected();
        }

        foreach (int index in CurrentSelection) {
            if(CurrentSelection.Count == 1) {
                IndexToSlot(index).SetSoloSelected(SoloSelectColor);
            } else {
                IndexToSlot(index).SetMultiSelected(MultiSelectColor);
            }
        }
    }

    public CardSlot IndexToSlot(int index)
    {
        return index switch
        {
            0 => CardSlot0,
            1 => CardSlot1,
            2 => CardSlot2,
            3 => CardSlot3,
            _ => throw new System.IndexOutOfRangeException(),
        };
    }


    public void SwapSelection(int index)
    {
        if (CurrentSelection.Contains(index))
            CurrentSelection.Remove(index);
        else
            CurrentSelection.Add(index);
    }
}

[System.Serializable]
public class CardSlot
{
    public Image Image;
    public Button Button;
    [Space()]
    public Button ActivateButton;
    public Image ActivateButtonImage;
    public void UpdateSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public void SetInvisible() {
        Image.color = new Color(1, 1, 1, 0);
        Button.enabled = false;
    }
    public void SetVisible()
    {
        Image.color = new Color(1, 1, 1, 1);
        Button.enabled = true;
    }
    public void SetSoloSelected(Color soloSelectColor)
    {
        ActivateButton.gameObject.SetActive(true);
        ActivateButtonImage.color = soloSelectColor;
    }
    public void SetMultiSelected(Color multiSelectColor)
    {
        ActivateButton.gameObject.SetActive(true);
        ActivateButton.interactable = false;
        ActivateButtonImage.color = multiSelectColor;
    }
    public void SetUnselected()
    {
        ActivateButton.gameObject.SetActive(false);
    }


}
