using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab04
{
    public class Camera
    {
        public double eyeX;
        public double eyeY;
        public double eyeZ;

        public double lookX;
        public double lookY;
        public double lookZ;

        public double R;
        public double theta;
        public double phi;

        public Camera()
        {
            eyeX = 10;
            eyeY = 10;
            eyeZ = 10;

            lookX = 0;
            lookY = 0;
            lookZ = 0;

            ComputeR();
            ComputeTheta();
            ComputePhi();
        }

        // Tính góc @theta hiện tại
        public void ComputeTheta()
        {
            // Trường hợp điểm nhìn không phải gốc tọa độ thì trừ @lookX
            theta = Math.Atan((eyeX - lookX) / (eyeZ - lookZ));
        }

        // Tính góc @phi hiện tại
        public void ComputePhi()
        {
            // // Trường hợp điểm nhìn không phải gốc tọa độ thì trừ @lookY
            phi = Math.Asin((eyeY - lookY) / R);
        }

        // Tính bán kính của hình cầu khi thay đổi vị trí camera (khoảng cách từ eye đến look)
        public void ComputeR()
        {
            R = Math.Sqrt(Math.Pow(eyeX - lookX, 2)
                     + Math.Pow(eyeY - lookY, 2)
                     + Math.Pow(eyeZ - lookZ, 2));
        }

        // Phóng to - di chuyển vị trí camera lại gần điểm nhìn
        public void ZoomIn()
        {
            eyeX += -0.017f * eyeX;
            eyeY += -0.017f * eyeY;
            eyeZ += -0.017f * eyeZ;

            // Khi di chuyển vị trí camera thì bán kính hình cầu sẽ thay đổi nên cần cập nhật lại
            ComputeR();
            ComputeTheta();
            ComputePhi();
        }

        // Thu nhỏ - di chuyển vị trí camera ra xa điểm nhìn
        public void ZoomOut()
        {
            eyeX += 0.017f * eyeX;
            eyeY += 0.017f * eyeY;
            eyeZ += 0.017f * eyeZ;

            // Khi di chuyển vị trí camera thì bán kính hình cầu sẽ thay đổi nên cần cập nhật lại
            ComputeR();
            ComputeTheta();
            ComputePhi();
        }

        // Di chuyển camera quay xung quanh điểm nhìn sang phải
        public void RotateRight()
        {
            theta += 0.017;
            eyeX = lookX + R * Math.Cos(phi) * Math.Sin(theta);
            eyeZ = lookZ + R * Math.Cos(phi) * Math.Cos(theta);
        }

        // Di chuyển camera quay xung quanh điểm nhìn sang trái 
        public void RotateLeft()
        {
            theta -= 0.017;
            eyeX = lookX + R * Math.Cos(phi) * Math.Sin(theta);
            eyeZ = lookZ + R * Math.Cos(phi) * Math.Cos(theta);
        }

        // Di chuyển camera quay xung quanh điểm nhìn lên trên
        public void RotateUp()
        {
            phi += 0.017;
            eyeY = lookY + R * Math.Sin(phi);
            eyeZ = lookZ + R * Math.Cos(phi) * Math.Cos(theta);
            eyeX = lookX + R * Math.Cos(phi) * Math.Sin(theta);
        }

        // Di chuyển camera quay xung quanh điểm nhìn xuống dưới
        public void RotateDown()
        {
            phi -= 0.017;

            eyeY = lookY + R * Math.Sin(phi);
            eyeZ = lookZ + R * Math.Cos(phi) * Math.Cos(theta);
            eyeX = lookX + R * Math.Cos(phi) * Math.Sin(theta);

        }
    }
}
