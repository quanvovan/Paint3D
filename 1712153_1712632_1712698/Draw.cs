//Draw and Redraw everytime
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Draw
    {
        //public static Stack<Object> stackObject = new Stack<Object>();
        public static List<Object> listObject = new List<Object>();
        public static Object chooseObject(OpenGLControl openGLControl, int chooseIcon, Point3D center)
        {
            Object chooseObject = null;

            /*Choose a shape */

            switch (chooseIcon)
            {
                case 1://Cube
                    chooseObject = new Cube();//màu nền, tâm, chiều dài cạnh, check đang chọn
                    break;
                case 2://Pyramid - Hình chóp đáy là hình vuông
                    chooseObject = new Pyramid(); //màu nền, tâm, chiều dài cạnh, check đang chọn, đỉnh chóp
                    break;
                case 3://Prism - Hình lăng trụ đáy là tam giác đều 
                    chooseObject = new Prism();//màu nền, tâm, chiều dài cạnh, check đang chọn
                    break;
                //xem lại chú thích
                default:
                    break;
            }
            if (chooseObject != null) // nếu tạo được object
            {
                string name;
                chooseObject.name = Object.nums.ToString() + "." + chooseObject.name;
                listObject.Add(chooseObject);
            }

            return chooseObject;
        }

        /*
        draw object from stack 
        */
        public static void DrawShape(OpenGLControl openGLControl)
        {
            var gl = openGLControl.OpenGL;
            foreach (var x in listObject)
            {
                gl.PushMatrix();
                x.Draw(openGLControl);
                gl.PopMatrix();
            }
        }
    }
}
