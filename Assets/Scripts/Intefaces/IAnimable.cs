using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimable
{
    AnimationBehaviour AnimationBehaviour { get; set; }
    float _speed { get; set; }
}
