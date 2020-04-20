using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    private Text clock;
    private float time = 0;
    private int wholeTime;
    private int dayCount = 1;
    public GameObject upgradePanel;
    public Button upgradeMedicButton;
    public Button recruitMedicButton;
    [SerializeField]
    private float clockSpeed = 0.2f;
    private bool upgradesDone = false;
    public bool selected = false;
    public GameObject medicPrefab;
    public GameObject medicsCollection;
    public GameObject medicPlaceholder;

    void Start()
    {
        clock = GetComponent<Text>();
        upgradeMedicButton.onClick.AddListener(clickUpgrade);
        recruitMedicButton.onClick.AddListener(clickRecruit);
    }

    void Update()
    {
        time += clockSpeed * Time.deltaTime;
        wholeTime = Mathf.RoundToInt(time);

        if (wholeTime == 24)
        {
            time = 0;
            dayCount++;
        }
        if (wholeTime < 10)
        {
            clock.text = "Day " + dayCount + "     " + "0" + wholeTime.ToString() + ":00";
        }
        else
        {
            clock.text = "Day " + dayCount + "     " + wholeTime.ToString() + ":00";
        }

        if (dayCount % 3 == 0 && !upgradesDone)
        {
            upgradePanel.SetActive(true);
            Time.timeScale = 0;

        }
        if ((dayCount-1) % 3 == 0)
        {
            upgradesDone = false;
        }
        
    }

    void clickUpgrade()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1;
        upgradesDone = true;
        selected = true;
    }

    void clickRecruit()
    {
        GameObject newMedic = Instantiate<GameObject>(medicPrefab);
        newMedic.transform.parent = medicPlaceholder.transform;
        newMedic.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        newMedic.transform.localPosition = new Vector3(0f, 0f, 0f);

        upgradePanel.SetActive(false);
        Time.timeScale = 1;
        upgradesDone = true;
        selected = true;
    }
}
