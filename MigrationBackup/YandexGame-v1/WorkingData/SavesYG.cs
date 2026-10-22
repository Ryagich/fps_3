namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
// "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;


// Ваши сохранения

        public bool[] openLevels = { true, false, false };

        public float[] x = { 0, 0, 0 };
        public float[] y = { 0, 0, 0 };
        public float[] z = { 0, 0, 0 };

        //Ads Save
        public int AdsVariant = 0;

// 3lvl
        public bool BossAlive = true;
// Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


// Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
// Допустим, задать значения по умолчанию для отдельных элементов массива
        }
    }
}