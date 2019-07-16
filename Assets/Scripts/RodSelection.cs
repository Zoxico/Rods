using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RodSelection : MonoBehaviour
{
    public List<Rod> listOfRods;
    public GameObject rodsIconsContainer;
    public GameObject rowOfRods;
    //public GameObject rodIconButton;
    public ShowModelButton rodIconButton;
    public GameObject spinningTitle;
    public GameObject flyfishingTitle;
    public GameObject baitcastingTitle;
    public GameObject selectedRodParams;
    public GameObject selectedRodParamsPrefab;
    public GameObject selectedRodParamsContainerParent;
    private GameObject row;

    public GameObject rodNameText;
    public GameObject rodProgressBar;
    public GameObject levelIconsContainer;
    public GameObject rodLevelText;
    public GameObject progressBarText;
    public GameObject upgradeArrow;
    public GameObject viewfinderBar;
    public GameObject durabilityBar;
    public GameObject strengthBar;
    public GameObject rodTypeText;
    public GameObject bars;

    private Sprite[] spinningRodsIcons;
    private Sprite[] baitcastingRodsIcons;
    private Sprite[] flyfishingRodsIcons;

    public string[] spinningRodsNames;
    public string[] flyfishingRodsNames;
    public string[] baitcastingRodsNames;
    string modelName;
    private System.Random randomNumGenerator = new System.Random();
    private int iconsInSegmentCounter = 0;
    private int generalIconsCounter = 0;
    private int numberOfRods;
    private int[] rodsProgresses;
    private int[] rodsLevels;


    private void Start()
    {
        listOfRods = new List<Rod>();
        spinningRodsIcons      = Resources.LoadAll<Sprite>("Rods/Icons/SpinningRods");
        baitcastingRodsIcons   = Resources.LoadAll<Sprite>("Rods/Icons/BaitcastingRods");
        flyfishingRodsIcons    = Resources.LoadAll<Sprite>("Rods/Icons/FlyfishingRods");        
        row = Instantiate(rowOfRods) as GameObject;
        
        numberOfRods      = spinningRodsIcons.Length + baitcastingRodsIcons.Length + flyfishingRodsIcons.Length;
        rodsProgresses    = new int[numberOfRods];
        rodsLevels        = new int[numberOfRods];

        for (int i = 0; i < numberOfRods; i++)
        {
            rodsProgresses[i] = randomNumGenerator.Next(0, 200);
            if (rodsProgresses[i] > 100)
                rodsProgresses[i] = 100;
            rodsLevels[i] = randomNumGenerator.Next(0, 5);
        }

        spinningRodsNames    = File.ReadAllLines("Assets/Resources/Rods/SpinningRodNames_ENG.txt");
        flyfishingRodsNames  = File.ReadAllLines("Assets/Resources/Rods/FlyfishingRodNames_ENG.txt");
        baitcastingRodsNames = File.ReadAllLines("Assets/Resources/Rods/BaitcastingRodNames_ENG.txt");

        var rodModels = FindObjectOfType<ShowRodModelController>().GetRodModels();
        GameObject spinningTitle    = Instantiate(this.spinningTitle) as GameObject;
        GameObject baitcastingTitle = Instantiate(this.baitcastingTitle) as GameObject;
        GameObject flyfishingTitle  = Instantiate(this.flyfishingTitle) as GameObject;

        LoadRodSection(0, spinningRodsIcons, rodModels, spinningTitle, spinningRodsNames);
        LoadRodSection(1, baitcastingRodsIcons, rodModels, baitcastingTitle, baitcastingRodsNames);
        LoadRodSection(2, flyfishingRodsIcons, rodModels, flyfishingTitle, flyfishingRodsNames);

        // podgląd statystyk pierwszej wędki
        if (listOfRods.Count > 0)
        {
            Rod firstRod = listOfRods[0];
            firstRod.rodNameText.GetComponent<Text>().text = firstRod.rodName;
            //firstRod.paramsLevelIconsContainer
            firstRod.rodLevelText.GetComponent<Text>().text = firstRod.level.ToString();
            firstRod.progressBarText.GetComponent<Text>().text = firstRod.progress.ToString();

            Image arrow = firstRod.paramsUpgradeArrow.transform.Find("ArrowIcon").GetComponent<Image>();
            arrow.gameObject.SetActive(firstRod.progress == 100);
            //viewfinderFill = firstRod.viewfinderBar.GetComponent<Image>();
            //viewfinderFill.fillMethod = Image.FillMethod.Horizontal;
            //viewfinderFill.fillAmount = firstRod.progress;
            //durabilityFill = firstRod.durabilityBar.GetComponent<Image>();
            //durabilityFill.fillMethod = Image.FillMethod.Horizontal;
            //durabilityFill.fillAmount = firstRod.progress;
            //strengthFill = firstRod.strengthBar.GetComponent<Image>();
            //strengthFill.fillMethod = Image.FillMethod.Horizontal;
            //strengthFill.fillAmount = firstRod.progress;

            switch (firstRod.type)
            {
                case 0:
                    firstRod.rodTypeText.GetComponent<Text>().text = "SPINNING";
                    break;
                case 1:
                    firstRod.rodTypeText.GetComponent<Text>().text = "BAITCASTING";
                    break;
                case 2:
                    firstRod.rodTypeText.GetComponent<Text>().text = "FLYFISHING";
                    break;
            }
        }
    }

    private void LoadRodSection(int section, Sprite[] icons, List<Transform> rodModels, GameObject title, string[] rodsNames)
    {
        if(icons.Length > 0)
        { 
            foreach (Sprite icon in icons)
            { 
                if (iconsInSegmentCounter % 4 == 0) row = Instantiate(rowOfRods) as GameObject;
                //var iconButton = Instantiate(rodIconButton);

                Rod rod = new Rod(rodIconButton, section, icons, rodModels, title, rodsNames, iconsInSegmentCounter, generalIconsCounter, rodsLevels, rodsProgresses, 
                    randomNumGenerator, selectedRodParams, selectedRodParamsPrefab, selectedRodParamsContainerParent,
                    rodNameText, rodProgressBar, levelIconsContainer, rodLevelText, progressBarText, upgradeArrow, viewfinderBar, durabilityBar, strengthBar, rodTypeText, bars);
                listOfRods.Add(rod);

                if (iconsInSegmentCounter == 0)
                {
                    GameObject titleRow = Instantiate(rowOfRods) as GameObject;
                    titleRow.GetComponent<LayoutElement>().minHeight = 86.0f;
                    title.transform.SetParent(titleRow.transform);
                    titleRow.transform.SetParent(rodsIconsContainer.transform);
                } 
                                  
                var controller = FindObjectOfType<ShowRodModelController>();
                rod.iconButton.Initialize(rodModels[iconsInSegmentCounter % 2], rod, controller.SelectRod);

                rod.iconButton.transform.SetParent(row.transform);
                row.transform.SetParent(rodsIconsContainer.transform);

                modelName = icon.name;
                rod.iconButton.GetComponent<Button>().onClick.AddListener(() => Debug.Log(modelName));

                iconsInSegmentCounter++;
                generalIconsCounter++; 
            }

            iconsInSegmentCounter = 0;
        }
    }
    

}
