using UnityEngine;
using UnityEngine.UI;
public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    void Start()
    {
        ActiveTab(0);
    }

    public void ActiveTab(int TabNo)
    {
        for(int i =0; i< pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[TabNo].SetActive(true);
        tabImages[TabNo].color = Color.white;
    }
   
   
}
