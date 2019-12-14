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
        private double R_bot;
        private double alpha;
        Point3D A, B, C, D, E, F;

        public Prism() //màu nền, tâm, chiều dài cạnh, check đang chọn
        {
            center.x = center.y = center.z = 0;
            Solid = false; //check xem có đang thao tác trên hình này không
            alpha = 2 * Math.PI / 3;
            type = 2;
            
        }
        public void InitPoint()
        {
            R = height / 2;

            A.x = center.x + R;
            A.y = center.y;
            A.z = center.z + R ;

            B.x = center.x - R;
            B.y = center.y - R;
            B.z = center.z + R;

            C.x = center.x - R;
            C.y = center.y + R;
            C.z = center.z + R;

            D.x = center.x + R;
            D.y = center.y;
            D.z = center.y - R;

            E.x = center.x - R;
            E.y = center.y - R;
            E.z = center.z - R;

            F.x = center.x - R;
            F.y = center.y + R;
            F.z = center.z - R;
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

            VienKhung(gl);
            gl.PopMatrix();
            gl.Flush();// Thực hiện lệnh vẽ ngay lập tức thay vì đợi sau 1 khoảng thời gian
        }

        private void VienKhung(OpenGL gl)
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

            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(C.x, C.y, C.z); // V3

            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(C.x, C.y, C.z); // V3

            gl.Vertex(A.x, A.y, A.z); // V1
            gl.Vertex(D.x, D.y, D.z); // V4

            gl.Vertex(B.x, B.y, B.z); // V2
            gl.Vertex(E.x, E.y, E.z); // V5

            gl.Vertex(C.x, C.y, C.z); // V3
            gl.Vertex(F.x, F.y, F.z); // V6

            gl.Vertex(D.x, D.y, D.z); // V4
            gl.Vertex(E.x, E.y, E.z); // V5

            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(D.x, D.y, D.z); // V4

            gl.Vertex(F.x, F.y, F.z); // V6
            gl.Vertex(E.x, E.y, E.z); // V5

            gl.End();
        }

        ~Prism()
        {
        }
    }
}
