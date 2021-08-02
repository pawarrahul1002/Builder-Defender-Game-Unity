﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    // private BuildingTypeSO buildingType;
    private ResourceGeneratorData resourceGeneratorData;
    private float timer;
    private float timerMax;

    private void Awake()
    {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
    }

    private void Start()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratorData.resourceDetectionRadious);

        int nearByResourceAmount = 0;
        foreach (Collider2D collider2D in collider2DArray)
        {
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                //it's resource node!!
                if (resourceNode.resourceType == resourceGeneratorData.resourceType)
                {
                    //same type
                    nearByResourceAmount++;
                }

            }
        }
        nearByResourceAmount = Mathf.Clamp(nearByResourceAmount, 0, resourceGeneratorData.maxResourceAmount);

        if (nearByResourceAmount == 0)
        {
            //no resource nodes nearby
            //disable the resource generator
            enabled = false;
        }
        else
        {
            timerMax = (resourceGeneratorData.timerMax / 2f) +
                        resourceGeneratorData.timerMax *
                        (1 - (float)nearByResourceAmount / resourceGeneratorData.maxResourceAmount);
        }

        Debug.Log("nearByResourceAmount : " + nearByResourceAmount + " ; timermax : " + timerMax);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timerMax;
            // Debug.Log(buildingType.resourceGeneratorData.resourceType.nameString);
            ResourceManager.Instance.AddResource(resourceGeneratorData.resourceType, 1);
        }



    }
}
