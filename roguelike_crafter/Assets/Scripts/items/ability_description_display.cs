using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ability_description_display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator ability_animation;
    public TextMeshProUGUI ability_description;
    public string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ability_animation.SetTrigger("on");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ability_animation.SetTrigger("off");
    }

    private void setDescription()
    {
        
    }
}
