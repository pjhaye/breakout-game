using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [System.Serializable]
    public class BrickColorConfig
    {
        public BrickColor color;
        public Material material;
        public Material weakenedMaterial;
        public int score;
    }
}