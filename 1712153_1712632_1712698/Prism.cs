using System;
using SharpGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpGL.SceneGraph;

namespace Lab04
{
    class Prism : Object
    {
        public List<Vertex> listVertex;
        
        Point3D A, B, C, D, E, F;

        public Prism() //màu nền, tâm, chiều dài cạnh, check đang chọn
        {
            center.x = center.y = center.z = 0;
            Solid = false; //check xem có đang thao tác trên hình này không
            type = 2;
            name = "prism";
        }
        public void InitPoint()
        {
            R = length * Math.Sqrt(3) / 3;
            double alpha = 2 * Math.PI / 3;

            A.x = center.x + R;
            A.y = center.y - height / 2;
            A.z = center.z;

            B.x = center.x + R * Math.Cos(alpha);
            B.y = center.y - height/2;
            B.z = center.z + R*Math.Sin(alpha);

            C.x = center.x + R * Math.Cos(2 * alpha);
            C.y = center.y - height / 2;
            C.z = center.z + R * Math.Sin(2 * alpha);

            D.x = A.x;
            D.y = A.y+ height;
            D.z = A.z;

            E.x = B.x;
            E.y = B.y + height;
            E.z = B.z;

            F.x = C.x;
            F.y = C.y + height;
            F.z = C.z;
        }
        

        public override void Draw(OpenGLControl glControl)
        {
            OpenGL gl = glControl.OpenGL;
            InitPoint();

            gl.PushMatrix();

            gl.Rotate((float)angelX, (float)angelY, (float)angelZ);
            gl.Translate(tX, tY, tZ);
            gl.Scale(sX, sY, sZ);

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_TRIANGLES);
            //Ve mat tam giac
            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(C.x, C.y, C.z); // V3

            gl.Vertex(D.x, D.y, D.z); // V4
            gl.Vertex(E.x, E.y, E.z); // V5
            gl.Vertex(F.x, F.y, F.z); // V6

            gl.End();

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_QUADS);
            //Ve mat ben
            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(E.x, E.y, E.z); // V5
            gl.Vertex(D.x, D.y, D.z); // V4

            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(C.x, C.y, C.z); // V3
            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(D.x, D.y, D.z); // V4

            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(C.x, C.y, C.z); // V3
            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(E.x, E.y, E.z); // V5

            gl.End();

            border(gl);
            gl.PopMatrix();
            gl.Flush();// Thực hiện lệnh vẽ ngay lập tức thay vì đợi sau 1 khoảng thời gian
        }

        private void border(OpenGL gl)
        {
            if (Solid) //nếu đang thao tác trên hình
            {
                //viền cam đậm
                gl.Color(236 / 255.0, 135 / 255.0, 14 / 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)2);
            }
            else // nếu không thao tác
            {
                //viền đen nhạt
                gl.Color(255 / 255.0, 255 / 255.0, 255 / 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)2);
            }

            gl.Begin(OpenGL.GL_LINES);
            //Vẽ các cạnh
            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(B.x, B.y, B.z); // V2
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(C.x, C.y, C.z); // V3
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(C.x, C.y, C.z); // V3
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(D.x, D.y, D.z); // V4
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(E.x, E.y, E.z); // V5
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(C.x, C.y, C.z); // V3
            gl.Vertex(F.x, F.y, F.z); // V6
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(D.x, D.y, D.z); // V4
            gl.Vertex(E.x, E.y, E.z); // V5
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(D.x, D.y, D.z); // V4
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(E.x, E.y, E.z); // V5
            gl.End();

        }

        ~Prism()
        {
        }
    }
}
