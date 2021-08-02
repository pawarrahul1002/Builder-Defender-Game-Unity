using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{

    private GameObject spriteGameObject;

    private void Awake()
    {
        spriteGameObject = transform.Find("sprite").gameObject;
    }

    private void Show()
    {
        spriteGameObject.SetActive(true);
    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }




}
