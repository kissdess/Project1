using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

    public enum Layer
    {
        Box = 7,
        Monster = 8,
        Ground = 9,
        Wall = 10,
        Obstacle = 11,
        Dead = 30,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }

    public enum UIEvent
    {
        Enter,
        Exit,
        Click,
        RightClick,
        BeginDrag,
        Dragging,
        EndDrag,

    }
    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
        RightClick,
    }

    public enum CameraMode
    {
        QuarterView,
    }

    public enum State
    {
        Idle,
        SuddenIdle,
        Moving,
        Die,
        Skill,
        Interaction,
    }

}
