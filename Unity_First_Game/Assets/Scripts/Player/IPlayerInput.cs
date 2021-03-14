using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roguelike
{
    public interface IPlayerInput
    {
        bool IsInteracting { get; }
    }

}
