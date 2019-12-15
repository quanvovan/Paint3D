using System;
using SharpGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpGL.SceneGraph.Assets;

namespace Lab04
{
    struct Point3D
    {
       public double x, y, z;
    }
    abstract class Object
    {
        public Point3D center;
        public double R;
        public Color color; // màu nền

        public double length; // chiều dài cạnh
        public double height;
        public bool Solid; //check xem có đang thao tác trên hình này không
        public string name;
        public double type;
        public static double nums = 0; // tính số object

        public double angelX, angelY, angelZ;
        public double tX, tY, tZ;
        public double sX, sY, sZ;

        public bool isTexture;
        public Texture texture;

      
        public Object()
        {
            center.x = center.y = center.z;
            R = 2.0f;
            color = Color.White;
            length = 3.0f; 
            height = 4.0f;

            angelX = angelY = angelZ = 0;
            tX = tY = tZ = 0;
            sX = sY = sZ = 1;

        }

        public virtual void Draw(OpenGLControl gl)
        { 
            gl.OpenGL.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0);
        }

        public void Update() { }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double GetCount() { return nums; }

        ~Object()
        {
        }


    }
}
