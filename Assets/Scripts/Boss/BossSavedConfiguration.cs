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

	public void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath
					 + "/MySaveData.dat");
		SaveData data = new SaveData();

		data.bossAbilityIDs = bossAbilityIDs;
		data.bossStrategyIDs = bossStrategyIDs;

		bf.Serialize(file, data);
		file.Close();
		Debug.Log("Game data saved!");
	}


	public void LoadGame()
	{
		if (File.Exists(Application.persistentDataPath
					   + "/MySaveData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file =
					   File.Open(Application.persistentDataPath
					   + "/MySaveData.dat", FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();
			data.bossAbilityIDs = bossAbilityIDs;
			data.bossStrategyIDs = bossStrategyIDs;
			Debug.Log("Game data loaded!");
		}
		else
			Debug.LogError("There is no save data!");
	}
}
[Serializable]
public class SaveData
{
	public int[] bossAbilityIDs;
	public int[] bossStrategyIDs;

}