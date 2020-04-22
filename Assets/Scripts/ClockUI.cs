using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    public GameVariables gamevariablesScript;

    private Text clock;
    private float time = 0;
    public int wholeTime;
    public int dayCount = 1;
    public GameObject upgradePanel;
    public GameObject medicUpgradePanel;
    public GameObject optionsPanel;
    public Button upgradeMedicButton;
    public Button recruitMedicButton;
    [SerializeField]
    private float clockSpeed = 0.2f;
    private bool upgradesDone = false;
    public bool selected = false;
    public bool upgradeSelected = false;
    public bool upgradeOptionChosen = false;
    public GameObject medicPrefab;
    public GameObject medicsCollection;
    public GameObject medicPlaceholder;

    public Button speedUpgrade;
    public Button riskMeterUpgrade;
    public Button bleedoutUpgrade;
    public Button countdownUpgrade;

    public Text upgradeStats;
    private float playerSpeedPercent = 0;
    private float riskMeterPercent = 0;
    private float bleedoutPercent = 0;
    private float countdownSeconds = 0;

    void Start()
    {
        gamevariablesScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameVariables>();
        clock = GetComponent<Text>();
        upgradeMedicButton.onClick.AddListener(clickUpgrade);
        recruitMedicButton.onClick.AddListener(clickRecruit);

        speedUpgrade.onClick.AddListener(delegate { upgradeMedic("speed"); });
        riskMeterUpgrade.onClick.AddListener(delegate { upgradeMedic("risk"); });
        bleedoutUpgrade.onClick.AddListener(delegate { upgradeMedic("bleedout"); });
        countdownUpgrade.onClick.AddListener(delegate { upgradeMedic("countdown"); });
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

        upgradeStats.text = "+ " + playerSpeedPercent + "%\n\n" + "- " + riskMeterPercent + "%\n\n" + "+ " + bleedoutPercent + "%\n\n" + "+ " + countdownSeconds + " seconds";
        
    }

    void clickUpgrade()
    {
        upgradeSelected = true;
        medicUpgradePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    void clickRecruit()
    {
        GameObject newMedic = Instantiate<GameObject>(medicPrefab);
        newMedic.transform.parent = medicPlaceholder.transform;
        newMedic.transform.localScale = new Vector3(1f, 1f, 1f);
        newMedic.transform.localPosition = new Vector3(0f, 0f, 0f);

        upgradePanel.SetActive(false);
        optionsPanel.SetActive(true);
        Time.timeScale = 1;
        upgradesDone = true;
        selected = true;
    }

    void upgradeMedic (string choice)
    {
        if (choice == "speed")
        {
            gamevariablesScript.playerSpeed += 6.25f;
            playerSpeedPercent += 5;
            upgradeOptionChosen = true;
        }
        if (choice == "risk")
        {
            gamevariablesScript.riskMeterSpeed -= 0.25f;
            riskMeterPercent += 5;
            upgradeOptionChosen = true;
        }
        if (choice == "bleedout")
        {
            gamevariablesScript.bleedoutSpeed -= 0.15f;
            bleedoutPercent += 5;
            upgradeOptionChosen = true;
        }
        if (choice == "countdown")
        {
            gamevariablesScript.countdownStartingTime += 0.5f;
            countdownSeconds += 0.5f;
            upgradeOptionChosen = true;
        }
        medicUpgradePanel.SetActive(false);
        upgradePanel.SetActive(false);
        optionsPanel.SetActive(true);
        Time.timeScale = 1;
        upgradesDone = true;
        selected = true;
    }
}
