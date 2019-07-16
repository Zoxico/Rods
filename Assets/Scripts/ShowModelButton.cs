using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowModelButton : MonoBehaviour
{
    private Transform _rodModel;
    private Action<Transform> _clickAction;
    private Rod _rod;
    private Image arrow;
    private Image viewfinderFill;
    private Image durabilityFill;
    private Image strengthFill; 

    public void Initialize(Transform rodModel, Rod rodButton, Action<Transform> clickAction)
    {
        _rod = rodButton;
        _rodModel = rodModel;
        _clickAction = clickAction;
    }

	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(HandleButtonClick);
	}
	
	void HandleButtonClick()
    {
        _clickAction(_rodModel);

        _rod.rodNameText.GetComponent<Text>().text = _rod.rodName;  
        _rod.rodLevelText.GetComponent<Text>().text = _rod.level.ToString();              
        _rod.progressBarText.GetComponent<Text>().text = _rod.progress.ToString(); 

        arrow = _rod.paramsUpgradeArrow.transform.Find("ArrowIcon").GetComponent<Image>();
        arrow.gameObject.SetActive(_rod.progress == 100);
        //viewfinderFill = _rod.viewfinderBar.GetComponent<Image>();
        //viewfinderFill.fillMethod = Image.FillMethod.Horizontal;
        //viewfinderFill.fillAmount = _rod.progress;
        //durabilityFill = _rod.durabilityBar.GetComponent<Image>();
        //durabilityFill.fillMethod = Image.FillMethod.Horizontal;
        //durabilityFill.fillAmount = _rod.progress;
        //strengthFill = _rod.strengthBar.GetComponent<Image>();
        //strengthFill.fillMethod = Image.FillMethod.Horizontal;
        //strengthFill.fillAmount = _rod.progress;

        switch (_rod.type)
        {
            case 0:
                _rod.rodTypeText.GetComponent<Text>().text = "SPINNING";
                break;
            case 1:
                _rod.rodTypeText.GetComponent<Text>().text = "BAITCASTING";
                break;
            case 2:
                _rod.rodTypeText.GetComponent<Text>().text = "FLYFISHING";
                break;
        }


    }
}
