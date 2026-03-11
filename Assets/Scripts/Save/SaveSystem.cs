using UnityEngine;

namespace MushroomNocturne.Save
{
    public static class SaveSystem
    {
        private const string SaveKey = "MUSHROOM_NOCTURNE_SAVE";

        public static void Save(SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();
        }

        public static SaveData Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return null;
            string json = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<SaveData>(json);
        }
    }
}
