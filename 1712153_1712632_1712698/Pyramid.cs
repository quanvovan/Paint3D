using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL.SceneGraph.Assets;

namespace Lab04
{
    class Pyramid : Object
    {
        public Point3D O, A, B, C, D;
        public Pyramid() :base() //độ dày, màu nền, tâm object, chiều dài cạnh
        {
            length = 2.0f; //độ dài cạnh
            height = 5.0f;
            color = Color.White; //màu nền mặt phẳng
            Solid = false; //check xem có đang thao tác trên hình này không
            type = 1;
            isTexture = false;
            texture = new Texture();

            angelX = angelY = angelZ = 0;
            tX = tY = tZ = 0;
            sX = sY = sZ = 1;
        }
        public void InitPoint()
        {
            double d = (2 * R * R - R * R) / (4 * R);
            A.x = center.x + R; A.y = center.y-R/2; A.z = center.z + R;
            B.x = center.x + R; B.y = center.y-R/2; B.z = center.z - R;
            C.x = center.x - R; C.y = center.y-R/2; C.z = center.z - R;
            D.x = center.x - R; D.y = center.y-R/2; D.z = center.z + R;

            O.x = center.x; O.y = center.y + R; O.z = center.z;
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
            //Vẽ khối hoặc vẽ và dán texture
            if (isTexture)
                DrawTexture(gl);
            else
                DrawRaw(gl);
            VienKhung(gl);
            gl.PopMatrix();
            gl.Flush();
        }

        private void DrawRaw(OpenGL gl)
        {
            //đáy
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0.9);
            gl.Vertex(A.x, A.y, A.z);
            gl.Vertex(B.x, B.y, B.z);
            gl.Vertex(C.x, C.y, C.z);
            gl.Vertex(D.x, D.y, D.z);
            gl.End();

            //trước
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(color.R / 265.0, color.G / 265.0, color.B / 265.0, 0.9);
            gl.Vertex(A.x, A.y, A.z);
            gl.Vertex(B.x, B.y, B.z);
            gl.Vertex(O.x, O.y, O.z);
            gl.End();

            //sau
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(color.R / 275.0, color.G / 275.0, color.B / 275.0, 0.9);
            gl.Vertex(C.x, C.y, C.z);
            gl.Vertex(D.x, D.y, D.z);
            gl.Vertex(O.x, O.y, O.z);
            gl.End();

            //trái
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(color.R / 285.0, color.G / 285.0, color.B / 285.0, 0.9);
            gl.Vertex(B.x, B.y, B.z);
            gl.Vertex(C.x, C.y, C.z);
            gl.Vertex(O.x, O.y, O.z);
            gl.End();

            //phải
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(color.R / 295.0, color.G / 295.0, color.B / 295.0, 0.9);
            gl.Vertex(D.x, D.y, D.z);
            gl.Vertex(A.x, A.y, A.z);
            gl.Vertex(O.x, O.y, O.z);
            gl.End();
        }

        private void DrawTexture(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            //Bind the texture.
            texture.Bind(gl);
            gl.Color(1f, 1f, 1f, 0);
            gl.Begin(OpenGL.GL_QUADS);
            //Ve mat day
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(A.x, A.y, A.z); // V2
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(B.x, B.y, B.z); // V3
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(C.x, C.y, C.z); // V4
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(D.x, D.y, D.z); // V5

            //gl.End();
            //Ve mat ben la 4 tam giac
            //gl.Begin(OpenGL.GL_QUADS);
            //front face
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(A.x, A.y, A.z); // V2
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(B.x, B.y, B.z); // V3

            // right face
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(B.x, B.y, B.z); // V3
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(C.x, C.y, C.z); // V4
            //behind face
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(C.x, C.y, C.z); // V4
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(D.x, D.y, D.z); // V5
            //left face
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.5f, 0.0f); gl.Vertex(O.x, O.y, O.z); // V1
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(D.x, D.y, D.z); // V5
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(A.x, A.y, A.z); // V2

            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);
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
            gl.Vertex(O.x, O.y, O.z); // V1
            gl.Vertex(A.x, A.y, A.z); // V2

            gl.Vertex(O.x, O.y, O.z); // V1
            gl.Vertex(B.x, B.y, B.z); // V3

            gl.Vertex(O.x, O.y, O.z); // V1
            gl.Vertex(C.x, C.y, C.z); // V4

            gl.Vertex(O.x, O.y, O.z); // V1
            gl.Vertex(D.x, D.y, D.z); // V5

            gl.Vertex(A.x, A.y, A.z); // V2
            gl.Vertex(B.x, B.y, B.z); // V3

            gl.Vertex(B.x, B.y, B.z); // V3
            gl.Vertex(C.x, C.y, C.z); // V4

            gl.Vertex(C.x, C.y, C.z); // V4
            gl.Vertex(D.x, D.y, D.z); // V5

            gl.Vertex(D.x, D.y, D.z); // V5
            gl.Vertex(A.x, A.y, A.z); // V2

            gl.End();
        }
    }
}
