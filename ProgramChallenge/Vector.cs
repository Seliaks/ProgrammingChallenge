using System;

namespace ProgramChallenge
{
    public class Vector
    {
        private double _i;
        private double _j;

        public Vector(double i, double j)
        {
            this._i = i;
            this._j = j;
        }

        public double Magnitude()
        {
            var magnitude = Math.Sqrt(Math.Pow((double) _i, 2) + Math.Pow((double) _j, 2));
            return magnitude;
        }

        public double Angle()
        {
            double angle;
            switch (_i)
            {
                case 0 when _j > 0:
                    angle = Math.PI/2;
                    break;
                case 0 when _j < 0:
                    angle = Math.PI/2 * 3;
                    break;
                default:
                {
                    switch (_j)
                    {
                        case 0 when _i > 0:
                            angle = 0;
                            break;
                        case 0 when _i < 0:
                            angle = Math.PI;
                            break;
                        default:
                        {
                            if (_j > 0)
                            {
                                angle = Math.Atan((double) (_j / _i));
                            }
                            else if (_j < 0)
                            {
                                angle = Math.Atan((double) (_j / _i)) + Math.PI;
                            }
                            else
                            {
                                angle = 0;
                            }

                            break;
                        }
                    }

                    break;
                }
            }
            return angle * 180/Math.PI;
        }
    }
}