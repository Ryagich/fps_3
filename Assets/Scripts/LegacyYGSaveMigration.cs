using UnityEngine;
using YG.Utils;

namespace YG
{
    internal static class LegacyYGSaveMigration
    {
        private const string LegacyStorageKey = "savesData";
        private const string Yg2StorageKey = "YG2_SavesData";

        internal static void MigrateLocalSaveIfNeeded()
        {
            if (LocalStorage.HasKey(Yg2StorageKey) || !LocalStorage.HasKey(LegacyStorageKey))
                return;

            var legacyJson = LocalStorage.GetKey(LegacyStorageKey);
            var migratedSave = JsonUtility.FromJson<SavesYG>(legacyJson);
            if (migratedSave == null)
                return;

            // PluginYG2 treats idSave > 0 as a successfully loaded save.
            if (migratedSave.idSave <= 0)
                migratedSave.idSave = 1;

            LocalStorage.SetKey(Yg2StorageKey, JsonUtility.ToJson(migratedSave));
            Debug.Log("Migrated PluginYG v1 local save data to PluginYG2.");
        }
    }
}
