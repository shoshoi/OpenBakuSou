
namespace BakuSou
{
    static class Constants
    {
        // 判定の長さ
        public static double JUDGE_GREAT_TIME = 0.1;
        public static double JUDGE_GOOD_TIME = 0.15;
        public static double JUDGE_BAD_TIME = 0.2;

        // 判定のオフセット
        public static float JUDGE_OFFSET_TIME = 0.00f/*0.05f*/;

        // ノートの位置、スピード
        public static float DEFAULT_FALL_DIST = 50;
        public static float DEFAULT_FALL_SPEED = 2;

        // プールするノートの数
        public static int NOTE_POOL_SIZE = 50;

        // ノートのオブジェクトの横幅
        public static double NOTEO_OBJECT_WIDTH = 2.2;
    }
}