using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rod : MonoBehaviour
{
    #region fields
    public ShowModelButton iconButton { get; set; }
    public string rodName { get; set; }
    public int color    { get; set; }
    public int level    { get; set; }
    public int progress { get; set; }
    public int type     { get; set; }
    public int viewfinderValue  { get; set; }
    public int durabilityValue  { get; set; }
    public int strengthValue    { get; set; }

    // przycisk z ikoną wędki
    public Sprite icon { get; set; } 
    public GameObject levelIconsContainer { get; set; }
    public GameObject iconContainer     { get; set; }
    public GameObject nameLabel         { get; set; }
    public GameObject cardsContainer    { get; set; }
    public GameObject progressContainer { get; set; }
    public GameObject upgradeArrow      { get; set; }
    public GameObject levelContainer    { get; set; }
    public GameObject selectedRodParams { get; set; }
    public GameObject selectedRodParamsPrefab { get; set; }
    public GameObject selectedRodParamsContainerParent { get; set; }

    public Image blueLevelIcon      { get; set; }
    public Image purpleLevelIcon    { get; set; }
    public Image yellowLevelIcon    { get; set; }
    public Image blueCard           { get; set; }
    public Image purpleCard         { get; set; }
    public Image yellowCard         { get; set; }
    public Image arrow              { get; set; }

    // obszar podglądu
    public GameObject paramsLevelIconsContainer { get; set; }
    public GameObject paramsUpgradeArrow { get; set; }
    public GameObject rodNameText       { get; set; }
    public GameObject rodProgressBar    { get; set; }
    public GameObject rodLevelText      { get; set; }
    public GameObject progressBarText   { get; set; }
    public GameObject viewfinderBar     { get; set; }
    public GameObject durabilityBar     { get; set; }
    public GameObject strengthBar       { get; set; }
    public GameObject rodTypeText       { get; set; }
    public GameObject bars              { get; set; }



#endregion

    public Rod(ShowModelButton rodIconButton, int section, Sprite[] icons, List<Transform> rodModels, GameObject title, string[] rodsNames, 
            int iconsInSegmentCounter, int generalIconsCounter, int[] rodsLevels, int[] rodsProgresses, System.Random rnd, GameObject selectedRodParams, 
            GameObject selectedRodParamsPrefab, GameObject selectedRodParamsContainerParent,
                   GameObject rodNameText, GameObject rodProgressBar, GameObject paramsLevelIconsContainer, GameObject rodLevelText, GameObject progressBarText,
                   GameObject paramsUpgradeArrow, GameObject viewfinderBar, GameObject durabilityBar, GameObject strengthBar, GameObject rodTypeText, GameObject bars)
    {
        rodName = rodsNames[iconsInSegmentCounter];
        color = generalIconsCounter % 3;
        level = rodsLevels[generalIconsCounter];
        progress = rodsProgresses[generalIconsCounter];
        type = section;
        viewfinderValue = rnd.Next(0, 100);
        durabilityValue = rnd.Next(0, 100);
        strengthValue = rnd.Next(0, 100);
        icon = icons[iconsInSegmentCounter];
        this.selectedRodParamsContainerParent = selectedRodParamsContainerParent;
        this.selectedRodParams = selectedRodParams;
        this.selectedRodParams.transform.SetParent(this.selectedRodParamsContainerParent.transform);
        this.selectedRodParamsPrefab = selectedRodParamsPrefab;

        this.rodNameText = rodNameText;
        this.rodProgressBar = rodProgressBar;
        this.paramsLevelIconsContainer = paramsLevelIconsContainer;
        this.rodLevelText = rodLevelText;
        this.progressBarText = progressBarText;
        this.paramsUpgradeArrow = paramsUpgradeArrow;
        this.viewfinderBar = viewfinderBar;
        this.durabilityBar = durabilityBar;
        this.strengthBar = strengthBar;
        this.rodTypeText = rodTypeText;
        this.bars = bars;

        iconButton = Instantiate(rodIconButton);

        iconContainer   = iconButton.transform.Find("IconContainer").gameObject;
        nameLabel       = iconButton.transform.Find("RodName").gameObject;
        levelIconsContainer = iconButton.transform.Find("LevelIconsContainer").gameObject;
        cardsContainer  = iconButton.transform.Find("CardsContainer").gameObject;
        progressContainer = iconButton.transform.Find("ProgressText").gameObject;
        upgradeArrow    = iconButton.transform.Find("UpgradeArrow").gameObject;
        levelContainer  = iconButton.transform.Find("RodLevel").gameObject;
        blueLevelIcon   = levelIconsContainer.transform.Find("BlueLevelIcon").GetComponent<Image>();
        purpleLevelIcon = levelIconsContainer.transform.Find("PurpleLevelIcon").GetComponent<Image>();
        yellowLevelIcon = levelIconsContainer.transform.Find("YellowLevelIcon").GetComponent<Image>();
        blueCard        = cardsContainer.transform.Find("BlueCard").GetComponent<Image>();
        purpleCard      = cardsContainer.transform.Find("PurpleCard").GetComponent<Image>();
        yellowCard      = cardsContainer.transform.Find("YellowCard").GetComponent<Image>();
        arrow           = upgradeArrow.transform.Find("ArrowIcon").GetComponent<Image>();

        iconContainer.AddComponent<Image>();
        iconContainer.GetComponent<Image>().sprite = icon;
        nameLabel.GetComponent<Text>().text = rodName;
        progressContainer.GetComponent<Text>().text = progress.ToString() + "/100";

        blueLevelIcon.gameObject.SetActive(color == 0);
        purpleLevelIcon.gameObject.SetActive(color == 1);
        yellowLevelIcon.gameObject.SetActive(color == 2);

        blueCard.gameObject.SetActive(color == 0);
        purpleCard.gameObject.SetActive(color == 1);
        yellowCard.gameObject.SetActive(color == 2);

        arrow.gameObject.SetActive(progress == 100);

        levelContainer.GetComponent<Text>().text = level.ToString();

    }
}
