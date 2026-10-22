namespace YG
{
    public partial class SavesYG
    {
        // PluginYG2 service fields.
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Game progress migrated from PluginYG v1.
        public bool[] openLevels = { true, false, false };
        public float[] x = { 0, 0, 0 };
        public float[] y = { 0, 0, 0 };
        public float[] z = { 0, 0, 0 };
        public int AdsVariant;
        public bool BossAlive = true;
    }
}
