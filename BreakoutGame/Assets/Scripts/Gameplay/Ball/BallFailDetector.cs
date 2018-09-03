using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BallFailDetector
    {
        private readonly BreakoutGameController _breakoutGameController;

        private float _prevBallY = 0.0f;
        private readonly Ball _ball;
        private readonly float _ballFailY;

        public BallFailDetector(
            BreakoutGameController breakoutGameController, 
            Ball ball, 
            float ballFailY)
        {
            _breakoutGameController = breakoutGameController;
            _ball = ball;
            _ballFailY = ballFailY;
        }
      
        public void CheckForBallFail()
        {            
            if (_ball == null)
            {
                return;
            }
            var ballY = _ball.transform.localPosition.z;                        

            if(_prevBallY > _ballFailY &&
               ballY < _ballFailY)
            {
                _breakoutGameController.OnBallFail(_ball);
            }
            _prevBallY = ballY;
        }
    }
}