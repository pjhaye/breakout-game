using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BreakoutGame
{
    public class BrickGenerator
    {
        private BrickFactory _brickFactory;
        private LevelConfig _levelConfig;

        public BrickGenerator(
            BrickFactory brickFactory, 
            LevelConfig levelConfig)
        {
            _brickFactory = brickFactory;
            _levelConfig = levelConfig;
        }     
        
        public void GenerateBricks(BreakoutGameController breakoutGameController)
        {
            var numRows = _levelConfig.rowConfigs.Length;
            for(var i = 0; i < numRows; i++)
            {
                var rowConfig = _levelConfig.rowConfigs[i];
                GenerateRow(breakoutGameController, rowConfig, i);
            }
        }

        private void GenerateRow(
            BreakoutGameController breakoutGameController, 
            RowConfig rowConfig, 
            int rowIndex)
        {
            var unitSize = breakoutGameController.UnitSize;
            var numColumns = rowConfig.numColumns;
            var baseWidth = (breakoutGameController.PaddedGameBoardWidth / rowConfig.numColumns);

            var brickTopCenterPosition =
                new Vector3(0.0f,
                -breakoutGameController.PaddedGameBoardHeight * 0.5f * unitSize,
                0.0f);

            var y = (rowIndex * unitSize + brickTopCenterPosition.y);
            var startX = -(breakoutGameController.PaddedGameBoardWidth * 0.5f + brickTopCenterPosition.x) * unitSize;
            Debug.Log(breakoutGameController.PaddedGameBoardWidth + " : "  + breakoutGameController.GameBoardWidth);
            for (var i = 0; i < numColumns; i++)
            {
                var x = startX + (i * baseWidth * unitSize) + (baseWidth * 0.5f * unitSize);
                var brickConfig = GetBrickConfigForCoords(rowConfig, i);
                brickConfig.width = baseWidth;
                brickConfig.unitSize = unitSize;
                var brick = _brickFactory.CreateBrick(brickConfig);
                brick.transform.localPosition = new Vector3(x, 0.0f, -y);
                breakoutGameController.AddBrick(brick);
            }
        }

        private BrickConfig GetBrickConfigForCoords(
            RowConfig rowConfig, 
            int column)
        {
            var columnPercent = column / rowConfig.numColumns;
            var validSpawnRuleConfigs = GetValidSpawnRuleConfigs(
                columnPercent, 
                rowConfig.brickSpawnRuleConfigs.ToList());

            var numColors = validSpawnRuleConfigs[0].brickColors.Length;
            var randomIndex = Random.Range(0, numColors);
            var randomColor = validSpawnRuleConfigs[0].brickColors[randomIndex];
            var brickConfig = new BrickConfig
            {
                color = randomColor
            };
            return brickConfig;
        }

        private List<BrickSpawnRuleConfig> GetValidSpawnRuleConfigs(float columnPercent, List<BrickSpawnRuleConfig> spawnRuleConfigs)
        {
            var result = new List<BrickSpawnRuleConfig>();
            var numBrickConfigs = spawnRuleConfigs.Count;
            for (var i = 0; i < numBrickConfigs; i++)
            {
                var spawnRuleConfig = spawnRuleConfigs[i];                
                if(columnPercent >= spawnRuleConfig.minColumnPercent &&
                   columnPercent <= spawnRuleConfig.maxColumnPercent)
                {
                    result.Add(spawnRuleConfig);
                }
            }
            return result;
        }
    }
}