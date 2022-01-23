using DG.Tweening;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _panel;

    public void ShowPanel()
    {
        SwitchPanelAlpha(1);
        _panel.blocksRaycasts = true;
    }

    public void HidePanel()
    {
        SwitchPanelAlpha(0);
        _panel.blocksRaycasts = false;
    }
    
    private void SwitchPanelAlpha(float alpha)
    {
        _panel.DOFade(alpha, 0.5f);
    }
}