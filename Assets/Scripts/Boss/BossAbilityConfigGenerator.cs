using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityConfigGenerator : NetworkBehaviour
{
    private BossAbility[] allAbilitiesList;
    private BossAbility[] randomAbilityList;

    public BossAbility[] GetRandomAbilityList()
    {
        return randomAbilityList;
    }
    public void GenerateRandomAbilityList(int numberOfAbilities)
    {
        if (numberOfAbilities > allAbilitiesList.Length || numberOfAbilities < 1)
            throw new System.Exception("Error: Number of abilities requested is invalid. Number must be between 1 and the total implemented.");

        int[] randomIndexArray = GetRandomUniqueIntArray(numberOfAbilities, allAbilitiesList.Length);
        randomAbilityList = new BossAbility[numberOfAbilities];
        for (int i = 0; i < randomIndexArray.Length; i++)
        {
            randomAbilityList[i] = allAbilitiesList[randomIndexArray[i]];
        }

    }
    private int[] GetRandomUniqueIntArray(int arraySize, int arrayMaxRange)
    {
        int[] result = new int[arraySize];
        List<int> numbersInOrder = new List<int>();
        for (var x = 0; x < arrayMaxRange; x++)
        {
            numbersInOrder.Add(x);
        }
        for (var x = 0; x < arraySize; x++)
        {
            var randomIndex = UnityEngine.Random.Range(0, numbersInOrder.Count);
            result[x] = numbersInOrder[randomIndex];
            numbersInOrder.RemoveAt(randomIndex);
        }

        return result;
    }
    private void SetAllAbilityList()
    {
        BossAbility[] abilityList = { gameObject.GetComponent<BossAbilityPellet>(), gameObject.GetComponent<BossAbilityPelletBurst>(), gameObject.GetComponent<BossAbilityBigSlowPellet>(), gameObject.GetComponent<BossAbilityRapidPellets>() };
        allAbilitiesList = abilityList;
    }
    void Start()
    {
        if (!isServer)
            return;

        SetAllAbilityList();
    }
    void Update()
    {
        if (!isServer)
            return;
    }
}
