using UnityEngine;
using System.Collections;

public static class Global_Vars {

    public enum CONDITIONS
    {
        HURT,
        COLD,
        SCARED,
        TIRED,
        NORMAL
    }

    public enum PANDA_STATE
    {
        FOLLOW,
        HIDE,
        HELP,
        RUN
    }

    public static Character player;
}
