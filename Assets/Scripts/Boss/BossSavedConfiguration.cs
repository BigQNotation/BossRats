using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class BossSavedConfiguration : MonoBehaviour
{
    int[] bossAbilityIDs;
    int[] bossStrategyIDs;

	public int[] GetBossAbilityIDs()
    {
		return bossAbilityIDs;
    }
	public int[] GetBossStrategyIDs()
    {
		return bossStrategyIDs;
    }

	public void SaveBossAbilityIDs(int[] abilityIDs)
    {
		bossAbilityIDs = abilityIDs;
		SaveAbilities();
    }
	public void SaveBossStrategyIDs(int[] strategyIDs)
    {
		bossStrategyIDs = strategyIDs;
    }

	private void SaveAbilities()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath
					 + "/MySaveAbilityData.dat");
		SaveAbilities data = new SaveAbilities();
		data.bossAbilityIDs = bossAbilityIDs;

		bf.Serialize(file, data);
		file.Close();
		Debug.Log("Game data saved!");
	}

	public void LoadAbilities()
	{
		if (File.Exists(Application.persistentDataPath
					   + "/MySaveAbilityData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file =
					   File.Open(Application.persistentDataPath
					   + "/MySaveAbilityData.dat", FileMode.Open);
			SaveAbilities data = (SaveAbilities)bf.Deserialize(file);
			file.Close();
			bossAbilityIDs = data.bossAbilityIDs;
			Debug.Log("Game data loaded!");
		}
		else
			Debug.LogError("There is no save data!");
	}
}
[Serializable]
public class SaveStrategies
{
	public int[] bossStrategyIDs;

}
[Serializable]
public class SaveAbilities
{
	public int[] bossAbilityIDs;

}