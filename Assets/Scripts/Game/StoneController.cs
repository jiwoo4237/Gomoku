using UnityEngine;
using UnityEngine.EventSystems;

public class StoneController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int originHearts = 3;
    private int leftHearts;

    void Start()
    {
        leftHearts = originHearts;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < leftHearts; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < leftHearts; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
