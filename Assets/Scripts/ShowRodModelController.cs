using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRodModelController : MonoBehaviour
{
    private List<Transform> rodModels;

	void Awake ()
    {
        rodModels = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            rodModels.Add(model);

            model.gameObject.SetActive(i == 0);
        }
	}
	
    public void SelectRod(Transform modelTransform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var transformToToggle = transform.GetChild(i);
            bool shouldBeActive = transformToToggle == modelTransform;
            transformToToggle.gameObject.SetActive(shouldBeActive);
        }
    }

    public List<Transform> GetRodModels()
    {
        return new List<Transform>(rodModels);
    }
}
