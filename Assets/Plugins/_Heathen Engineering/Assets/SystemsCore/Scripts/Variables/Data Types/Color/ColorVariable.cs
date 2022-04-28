﻿using HeathenEngineering.Events;
using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Color")]
    public class ColorVariable : DataVariable<SerializableColor>
    { }
}
