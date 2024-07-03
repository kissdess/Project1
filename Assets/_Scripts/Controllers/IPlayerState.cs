using UnityEngine;
using System.Collections.Generic;

public interface IPlayerState
{
    void Enter();
    void Update();
    void Exit();
}
