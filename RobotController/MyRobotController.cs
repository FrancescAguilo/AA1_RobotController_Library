using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController
{

    public struct MyQuat
    {

        public float w;
        public float x;
        public float y;
        public float z;
    }

    public struct MyVec
    {

        public float x;
        public float y;
        public float z;
    }






    public class MyRobotController
    {

        #region public methods



        public string Hi()
        {

            string s = "hello world from my Robot Controller _ Aguiló/Blas";
            return s;

        }


        //EX1: this function will place the robot in the initial position

        public void PutRobotStraight(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3) {

            //todo: change this, use the function Rotate declared below
            //rot0 = NullQ;
            //rot1 = NullQ;
            //rot2 = NullQ;
            //rot3 = NullQ;
            float[] angles = new float[4];
            angles[0] = 74;
            angles[1] = -10;
            angles[2] = 80;
            angles[3] = 40;

            MyVec auxVec;
            auxVec.x = 0;
            auxVec.y = 1;
            auxVec.z = 0;

            rot0 = NullQ;
            rot0 = Rotate(rot0, auxVec, (float)Radians(angles[0]));
            auxVec.y = 0;
            auxVec.x = 1;
            rot1 = Rotate(rot0, auxVec, (float)Radians(angles[1]));
            rot2 = Rotate(rot1, auxVec, (float)Radians(angles[2]));
            rot3 = Rotate(rot2, auxVec, (float)Radians(angles[3]));
        }



        //EX2: this function will interpolate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.


        public bool PickStudAnim(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            if (myCondition)
            {
                //todo: add your code here
                rot0 = NullQ;
                rot1 = NullQ;
                rot2 = NullQ;
                rot3 = NullQ;


                return true;
            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        //EX3: this function will calculate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.
        //the only difference wtih exercise 2 is that rot3 has a swing and a twist, where the swing will apply to joint3 and the twist to joint4

        public bool PickStudAnimVertical(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            while (myCondition)
            {
                //todo: add your code here


            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        public static MyQuat GetSwing(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }


        public static MyQuat GetTwist(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }




        #endregion


        #region private and internal methods

        internal int TimeSinceMidnight { get { return (DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; } }


        private static MyQuat NullQ
        {
            get
            {
                MyQuat a;
                a.w = 1;
                a.x = 0;
                a.y = 0;
                a.z = 0;
                return a;

            }
        }

        internal MyQuat Multiply(MyQuat q1, MyQuat q2) {

           
            MyQuat returnQuat = NullQ;

            returnQuat.x = q1.x * q2.w + q1.y * q2.z - q1.z * q2.y + q1.w * q2.x;
            returnQuat.y = -q1.x * q2.z + q1.y * q2.w + q1.z * q2.x + q1.w * q2.y;
            returnQuat.z = q1.x * q2.y - q1.y * q2.x + q1.z * q2.w + q1.w * q2.z;
            returnQuat.w = -q1.x * q2.x - q1.y * q2.y - q1.z * q2.z + q1.w * q2.w;

            return returnQuat;

        }

        internal MyQuat Rotate(MyQuat currentRotation, MyVec axis, float angle)
        {

            MyQuat rotationQuat;
            rotationQuat.x = axis.x * (float)Math.Sin(angle / 2);
            rotationQuat.y = axis.y * (float)Math.Sin(angle / 2);
            rotationQuat.z = axis.z * (float)Math.Sin(angle / 2);
            rotationQuat.w = (float)Math.Cos(angle / 2);


            return Normalize(Multiply(currentRotation, rotationQuat));

        }

        internal MyQuat Normalize(MyQuat _quat)
        {
            MyQuat returnQuat = _quat;
            float magnitude = (float)Math.Sqrt(Math.Pow(_quat.x, 2) + Math.Pow(_quat.y, 2) + Math.Pow(_quat.z, 2) + Math.Pow(_quat.w, 2));
            returnQuat.x /= magnitude;
            returnQuat.y /= magnitude;
            returnQuat.z /= magnitude;
            returnQuat.w /= magnitude;

            return returnQuat;
        }

        internal double Radians(double degree)
        {
            return (degree * (Math.PI / 180));
        }

        

        #endregion






    }
}
