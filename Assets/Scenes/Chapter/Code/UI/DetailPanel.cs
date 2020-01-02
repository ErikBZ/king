using System.Text;
using UnityEngine;
using UnityEngine.UI;
using King.UnitSystem;

public class DetailPanel : MonoBehaviour
{
    public UnitReference Reference;
    public GameObject ImageGO;
    public GameObject TextGO;
    private Image Image;
    private Text Text;
    private void Start()
    {
        Image = ImageGO.GetComponent<Image>();
        Text = TextGO.GetComponent<Text>();
    }

    public void UpdateDetailPanel()
    {
        Image.gameObject.SetActive(true);
        Image.sprite = Reference.Unit.PortraitSprite;

        // Unit Stats
        StringBuilder sb = new StringBuilder();
        sb.Append(Reference.Unit.Name);

        Text.text = sb.ToString();
    }
}
