using System;
using SharpGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;

namespace Lab04
{
    class Cube : Object
    {
        private Point3D delta;//dịch tâm một tọa độ delta(x,y,z)
        public Point3D A, B, C, D, E, F, G, H;
        public Cube() //màu nền, tâm, chiều dài cạnh, check đang chọn
        {
            Solid = false;
            length = 5;
            type = 0;
            isTexture = false;
            texture = new Texture();
            name = "cube";
        }
        public void initPoint()
        {
            R = length / 2;

            A.x = center.x - R;
            A.y = center.y - R;
            A.z = center.z - R;

            B.x = center.x - R;
            B.y = center.y + R;
            B.z = center.z - R;

            C.x = center.x + R;
            C.y = center.y + R;
            C.z = center.z - R;

            D.x = center.x + R;
            D.y = center.y - R;
            D.z = center.z - R;

            E.x = center.x - R;
            E.y = center.y + R;
            E.z = center.z + R;

            F.x = center.x - R;
            F.y = center.y - R;
            F.z = center.z + R;

            G.x = center.x + R;
            G.y = center.y - R;
            G.z = center.z + R;

            H.x = center.x + R;
            H.y = center.y + R;
            H.z = center.z + R;
     
        }

        public override void Draw(OpenGLControl glControl)
        {
            OpenGL gl = glControl.OpenGL;
            initPoint();
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

            //Viền khung
            border(gl);
            gl.PopMatrix();
            gl.Flush();
        }

        private void DrawRaw(OpenGL gl)
        {
            // mặt phải
            gl.Begin(OpenGL.GL_QUADS);//GL_QUADS là tứ giác
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 1.0);
            gl.Vertex(A.x, A.y, A.z);//V1
            gl.Vertex(B.x, B.y, B.z);//V2
            gl.Vertex(C.x, C.y, C.z); //V3
            gl.Vertex(D.x, D.y, D.z); //V4
            gl.End();

            // mặt sau EFGH
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 265.0, color.G / 265.0, color.B / 265.0, 0.9);
            gl.Vertex(A.x, A.y, A.z); //V1
            gl.Vertex(B.x, B.y, B.z); //V2
            gl.Vertex(E.x, E.y, E.z);//V5
            gl.Vertex(F.x, F.y, F.z);//V6
            gl.End();

            // mặt dưới

            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 275.0, color.G / 275.0, color.B / 275.0, 0.9);
            gl.Vertex(A.x, A.y, A.z); //V1
            gl.Vertex(F.x, F.y, F.z);//V6
            gl.Vertex(G.x, G.y, G.z);//V7
            gl.Vertex(D.x, D.y, D.z);//V4

            gl.End();

            //sau
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 285.0, color.G / 285.0, color.B / 285.0, 0.9);
            gl.Vertex(F.x, F.y, F.z);//V6
            gl.Vertex(E.x, E.y, E.z);//V5
            gl.Vertex(H.x, H.y, H.z);//V8
            gl.Vertex(G.x, G.y, G.z);//V7
            gl.End();

            //trái
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 295.0, color.G / 295.0, color.B / 295.0, 0.9);
            gl.Vertex(B.x, B.y, B.z);//V2
            gl.Vertex(E.x, E.y, E.z);//V5
            gl.Vertex(H.x, H.y, H.z);//V8
            gl.Vertex(C.x, C.y, C.z);//V3
            gl.End();

            //phải
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(color.R / 305.0, color.G / 305.0, color.B / 305.0, 0.9);
            gl.Vertex(C.x, C.y, C.z);//V3
            gl.Vertex(D.x, D.y, D.z);//V4
            gl.Vertex(G.x, G.y, G.z);//V7
            gl.Vertex(H.x, H.y, H.z);//V8
            gl.End();
        }

        private void DrawTexture(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            //Bind the texture.
            texture.Bind(gl);
            gl.Color(1f, 1f, 1f, 0);
            gl.Begin(OpenGL.GL_QUADS);
            //Vẽ mặt phẳng
            //Right face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(A.x , A.y , A.z);//V1
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(B.x , B.y , B.z);//V2
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(C.x , C.y , C.z); //V3
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(D.x , D.y , D.z); //V4

            // Behind face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(A.x , A.y , A.z); //V1
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(B.x , B.y , B.z); //V2
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(E.x , E.y , E.z);//V5
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(F.x , F.y , F.z);//V6

            //Down face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(A.x , A.y , A.z); //V1
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(F.x , F.y , F.z);//V6
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(G.x , G.y , G.z);//V7
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(D.x , D.y , D.z);//V4

            //Left face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(F.x , F.y , F.z);//V6
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(E.x , E.y , E.z);//V5
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(H.x , H.y , H.z);//V8
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(G.x , G.y , G.z);//V7

            // Up face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(B.x , B.y , B.z);//V2
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(E.x , E.y , E.z);//V5
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(H.x , H.y , H.z);//V8
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(C.x , C.y , C.z);//V3

            //Front face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(C.x , C.y , C.z);//V3
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(D.x , D.y , D.z);//V4
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(G.x , G.y , G.z);//V7
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(H.x , H.y , H.z);//V8

            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }


        private void border(OpenGL gl)
        {
            if (Solid) //nếu đang thao tác trên hình
            {
                //viền cam đậm
                gl.Color(236.0f/ 255.0, 135.0f/ 255.0, 14/ 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)3);
            }
            else // nếu không thao tác
            {
                //viền đen nhạt
                gl.Color(255 / 255.0, 255 / 255.0, 255 / 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)2);
            }

            gl.Begin(OpenGL.GL_LINE);
            //Vẽ các cạnh
            gl.Vertex(A.x, A.y, A.z);
            gl.Vertex(B.x, B.y, B.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(B.x, B.y, B.z);
            gl.Vertex(C.x, C.y, C.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(C.x, C.y, C.z);
            gl.Vertex(D.x, D.y, D.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(A.x, A.y, A.z);
            gl.Vertex(D.x, D.y, D.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(B.x, B.y, B.z);
            gl.Vertex(E.x, E.y, E.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(F.x, F.y, F.z);
            gl.Vertex(E.x, E.y, E.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(F.x, F.y, F.z);
            gl.Vertex(A.x, A.y, A.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(F.x, F.y, F.z);
            gl.Vertex(G.x, G.y, G.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(D.x, D.y, D.z);
            gl.Vertex(G.x, G.y, G.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(E.x, E.y, E.z);
            gl.Vertex(H.x, H.y, H.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(G.x, G.y, G.z);
            gl.Vertex(H.x, H.y, H.z);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(C.x, C.y, C.z);
            gl.Vertex(H.x, H.y, H.z);
            gl.End();

        }

        ~Cube()
        {
        }
    }
}
