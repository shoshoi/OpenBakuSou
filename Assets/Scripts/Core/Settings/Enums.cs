
namespace BakuSou
{
    public enum Judgement
    {
        EARLY, /* 判定対象外（押すのが早すぎるとき）*/
        GREAT,
        GOOD,
        BAD,
        LATE,   /* 判定対象外（押すのが遅すぎるとき）*/
        NOJUDGE
    }
}