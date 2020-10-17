using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4()
        {

        }

        public static Matrix4x4 Identity
        {
			//[1 0 0 0]
			//[0 1 0 0]
			//[0 0 1 0]
			//[0 0 0 1]
			get
			{
				var matrix = new Matrix4x4 { };
				matrix.m[0][0] = 1;
				matrix.m[1][1] = 1;
				matrix.m[2][2] = 1;
				matrix.m[3][3] = 1;
				return matrix;
			}
        }

        public float Determinant
        {
			//https://www.math10.com/en/algebra/matrices/determinant.html
			//the -1 is decided by Math.Pow(-1, i + 1), but this is faster. If it's missing a -1 it means it would be 1.
			get
			{
				var matrix = new Matrix4x4 { };
				float d = matrix.m[0][0] * 
					(matrix.m[1][1] * (matrix.m[2][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[2][3]) + 
					matrix.m[2][1] * -1 * (matrix.m[1][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[1][3]) + 
					matrix.m[3][1] * (matrix.m[1][2] * matrix.m[2][3] - matrix.m[2][2] * matrix.m[1][3])) +
					matrix.m[1][0] *
					(matrix.m[0][1] * (matrix.m[2][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[2][3]) +
					matrix.m[2][1] * -1 * (matrix.m[0][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[0][3]) +
					matrix.m[3][1] * (matrix.m[0][2] * matrix.m[2][3] - matrix.m[2][2] * matrix.m[0][3])) +
					matrix.m[2][0] *
					(matrix.m[0][1] * (matrix.m[1][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[1][3]) +
					matrix.m[1][1] * -1 * (matrix.m[0][2] * matrix.m[3][3] - matrix.m[3][2] * matrix.m[0][3]) +
					matrix.m[3][1] * (matrix.m[0][2] * matrix.m[1][3] - matrix.m[1][2] * matrix.m[0][3])) +
					matrix.m[3][0] *
					(matrix.m[0][1] * (matrix.m[1][2] * matrix.m[2][3] - matrix.m[2][2] * matrix.m[1][3]) +
					matrix.m[1][1] * -1 * (matrix.m[0][2] * matrix.m[2][3] - matrix.m[2][2] * matrix.m[0][3]) +
					matrix.m[2][1] * (matrix.m[0][2] * matrix.m[1][3] - matrix.m[1][2] * matrix.m[0][3]));
				return d;
			}
        }

		public static float Determinant3x3(float[][] m)
		{
			float a1 = m[0][0] * m[1][1] * m[2][2];
			float a2 = m[0][1] * m[1][2] * m[2][3];
			float a3 = m[0][2] * m[1][3] * m[2][0];

			float b1 = m[0][2] * m[1][1] * m[2][0];
			float b2 = m[0][1] * m[1][0] * m[2][3];
			float b3 = m[0][0] * m[1][3] * m[2][2];

			return a1 + a2 + a3 - b1 - b2 - b3;
		}

		public Matrix4x4 Inverse
        {
			//https://semath.info/src/inverse-cofactor-ex4.html
			get
			{
				var matrix = new Matrix4x4 { };
				float[][] matrix00 = new float[3][] { new float[3], new float[3], new float[3]};
				float[][] matrix01 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix02 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix03 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix10 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix11 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix12 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix13 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix20 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix21 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix22 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix23 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix30 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix31 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix32 = new float[3][] { new float[3], new float[3], new float[3] };
				float[][] matrix33 = new float[3][] { new float[3], new float[3], new float[3] };

				//matrix 1 (matrixij = m - row i - column j)
				matrix00[0][0] = m[1][1];
				matrix00[0][1] = m[1][2];
				matrix00[0][2] = m[1][3];
				matrix00[1][0] = m[2][1];
				matrix00[1][1] = m[2][2];
				matrix00[1][2] = m[2][3];
				matrix00[2][0] = m[3][1];
				matrix00[2][1] = m[3][2];
				matrix00[2][2] = m[3][3];
				//matrix 2
				matrix01[0][0] = m[0][1];
				matrix01[0][1] = m[0][2];
				matrix01[0][2] = m[0][3];
				matrix01[1][0] = m[2][1];
				matrix01[1][1] = m[2][2];
				matrix01[1][2] = m[2][3];
				matrix01[2][0] = m[3][1];
				matrix01[2][1] = m[3][2];
				matrix01[2][2] = m[3][3];
				//matrix 3
				matrix02[0][0] = m[0][1];
				matrix02[0][1] = m[0][2];
				matrix02[0][2] = m[0][3];
				matrix02[1][0] = m[1][1];
				matrix02[1][1] = m[1][2];
				matrix02[1][2] = m[1][3];
				matrix02[2][0] = m[3][1];
				matrix02[2][1] = m[3][2];
				matrix02[2][2] = m[3][3];
				//matrix 4
				matrix03[0][0] = m[0][1];
				matrix03[0][1] = m[0][2];
				matrix03[0][2] = m[0][3];
				matrix03[1][0] = m[1][1];
				matrix03[1][1] = m[1][2];
				matrix03[1][2] = m[1][3];
				matrix03[2][0] = m[2][1];
				matrix03[2][1] = m[2][2];
				matrix03[2][2] = m[2][3];
				//matrix 5
				matrix10[0][0] = m[1][0];
				matrix10[0][1] = m[1][2];
				matrix10[0][2] = m[1][3];
				matrix10[1][0] = m[2][0];
				matrix10[1][1] = m[2][2];
				matrix10[1][2] = m[2][3];
				matrix10[2][0] = m[3][0];
				matrix10[2][1] = m[3][2];
				matrix10[2][2] = m[3][3];
				//matrix 6
				matrix11[0][0] = m[0][0];
				matrix11[0][1] = m[0][2];
				matrix11[0][2] = m[0][3];
				matrix11[1][0] = m[2][0];
				matrix11[1][1] = m[2][2];
				matrix11[1][2] = m[2][3];
				matrix11[2][0] = m[3][0];
				matrix11[2][1] = m[3][2];
				matrix11[2][2] = m[3][3];
				//matrix 7
				matrix12[0][0] = m[0][0];
				matrix12[0][1] = m[0][2];
				matrix12[0][2] = m[0][3];
				matrix12[1][0] = m[1][0];
				matrix12[1][1] = m[1][2];
				matrix12[1][2] = m[1][3];
				matrix12[2][0] = m[3][0];
				matrix12[2][1] = m[3][2];
				matrix12[2][2] = m[3][3];
				//matrix 8
				matrix13[0][0] = m[0][0];
				matrix13[0][1] = m[0][2];
				matrix13[0][2] = m[0][3];
				matrix13[1][0] = m[1][0];
				matrix13[1][1] = m[1][2];
				matrix13[1][2] = m[1][3];
				matrix13[2][0] = m[2][0];
				matrix13[2][1] = m[2][2];
				matrix13[2][2] = m[2][3];
				//matrix 9
				matrix20[0][0] = m[1][0];
				matrix20[0][1] = m[1][1];
				matrix20[0][2] = m[1][3];
				matrix20[1][0] = m[2][0];
				matrix20[1][1] = m[2][1];
				matrix20[1][2] = m[2][3];
				matrix20[2][0] = m[3][0];
				matrix20[2][1] = m[3][1];
				matrix20[2][2] = m[3][3];
				//matrix 10
				matrix21[0][0] = m[0][0];
				matrix21[0][1] = m[0][1];
				matrix21[0][2] = m[0][3];
				matrix21[1][0] = m[2][0];
				matrix21[1][1] = m[2][1];
				matrix21[1][2] = m[2][3];
				matrix21[2][0] = m[3][0];
				matrix21[2][1] = m[3][1];
				matrix21[2][2] = m[3][3];
				//matrix 11
				matrix22[0][0] = m[0][0];
				matrix22[0][1] = m[0][1];
				matrix22[0][2] = m[0][3];
				matrix22[1][0] = m[1][0];
				matrix22[1][1] = m[1][1];
				matrix22[1][2] = m[1][3];
				matrix22[2][0] = m[3][0];
				matrix22[2][1] = m[3][1];
				matrix22[2][2] = m[3][3];
				//matrix 12
				matrix23[0][0] = m[0][0];
				matrix23[0][1] = m[0][1];
				matrix23[0][2] = m[0][3];
				matrix23[1][0] = m[1][0];
				matrix23[1][1] = m[1][1];
				matrix23[1][2] = m[1][3];
				matrix23[2][0] = m[2][0];
				matrix23[2][1] = m[2][1];
				matrix23[2][2] = m[2][3];
				//matrix 13
				matrix30[0][0] = m[1][0];
				matrix30[0][1] = m[1][1];
				matrix30[0][2] = m[1][2];
				matrix30[1][0] = m[2][0];
				matrix30[1][1] = m[2][1];
				matrix30[1][2] = m[2][2];
				matrix30[2][0] = m[3][0];
				matrix30[2][1] = m[3][1];
				matrix30[2][2] = m[3][2];
				//matrix 14
				matrix31[0][0] = m[0][0];
				matrix31[0][1] = m[0][1];
				matrix31[0][2] = m[0][2];
				matrix31[1][0] = m[2][0];
				matrix31[1][1] = m[2][1];
				matrix31[1][2] = m[2][2];
				matrix31[2][0] = m[3][0];
				matrix31[2][1] = m[3][1];
				matrix31[2][2] = m[3][2];
				//matrix 15
				matrix32[0][0] = m[0][0];
				matrix32[0][1] = m[0][1];
				matrix32[0][2] = m[0][2];
				matrix32[1][0] = m[1][0];
				matrix32[1][1] = m[1][1];
				matrix32[1][2] = m[1][2];
				matrix32[2][0] = m[3][0];
				matrix32[2][1] = m[3][1];
				matrix32[2][2] = m[3][2];
				//matrix 16
				matrix33[0][0] = m[0][0];
				matrix33[0][1] = m[0][1];
				matrix33[0][2] = m[0][2];
				matrix33[1][0] = m[1][0];
				matrix33[1][1] = m[1][1];
				matrix33[1][2] = m[1][2];
				matrix33[2][0] = m[2][0];
				matrix33[2][1] = m[2][1];
				matrix33[2][2] = m[2][2];

				//M4ij = (-1) ^ ij * |M3ji|
				//M4-1 = (1/M4D) * M3D
				matrix.m[0][0] = Determinant3x3(matrix00) * (1 / Determinant);
				matrix.m[0][1] = -Determinant3x3(matrix10) * (1 / Determinant);
				matrix.m[0][2] = Determinant3x3(matrix20) * (1 / Determinant);
				matrix.m[0][3] = -Determinant3x3(matrix30) * (1 / Determinant);
				matrix.m[1][0] = -Determinant3x3(matrix01) * (1 / Determinant);
				matrix.m[1][1] = Determinant3x3(matrix11) * (1 / Determinant);
				matrix.m[1][2] = -Determinant3x3(matrix21) * (1 / Determinant);
				matrix.m[1][3] = Determinant3x3(matrix31) * (1 / Determinant);
				matrix.m[2][0] = Determinant3x3(matrix02) * (1 / Determinant);
				matrix.m[2][1] = -Determinant3x3(matrix12) * (1 / Determinant);
				matrix.m[2][2] = Determinant3x3(matrix22) * (1 / Determinant);
				matrix.m[2][3] = -Determinant3x3(matrix32) * (1 / Determinant);
				matrix.m[3][0] = -Determinant3x3(matrix03) * (1 / Determinant);
				matrix.m[3][1] = Determinant3x3(matrix13) * (1 / Determinant);
				matrix.m[3][2] = -Determinant3x3(matrix23) * (1 / Determinant);
				matrix.m[3][3] = Determinant3x3(matrix33) * (1 / Determinant);

				return matrix;
			}
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
			//[1 0 0 translation.x]
			//[0 1 0 translation.y]
			//[0 0 1 translation.z]
			//[0 0 0 1]
			var matrix = new Matrix4x4 {};
			matrix = Identity;
			matrix.m[0][3] = translation.x;
			matrix.m[1][3] = translation.y;
			matrix.m[2][3] = translation.z;
			return matrix;
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
			var matrix = new Matrix4x4 { };
			matrix = Identity;
			matrix *= RotateZ(rotation.z);
			matrix *= RotateX(rotation.x);
			matrix *= RotateY(rotation.y);
			return matrix;
		}

        public static Matrix4x4 RotateX(float rotation)
        {
			//[cos(a) -sin(a) 0 0]
			//[sin(a) cos(a) 0 0]
			//[0 0 1 0]
			//[0 0 0 1]
			var matrix = new Matrix4x4 { };
			matrix = Identity;
			matrix.m[0][0] = (float)Math.Cos(rotation);
			matrix.m[0][1] = -(float)Math.Sin(rotation);
			matrix.m[1][0] = (float)Math.Sin(rotation);
			matrix.m[1][1] = (float)Math.Cos(rotation);
			return matrix;
        }

        public static Matrix4x4 RotateY(float rotation)
        {
			//[cos(a) 0 -sin(a) 0 0]
			//[0 1 0 0]
			//[sin(a) 0 cos(a) 0]
			//[0 0 0 1]
			var matrix = new Matrix4x4 { };
			matrix = Identity;
			matrix.m[0][0] = (float)Math.Cos(rotation);
			matrix.m[0][2] = -(float)Math.Sin(rotation);
			matrix.m[2][0] = (float)Math.Sin(rotation);
			matrix.m[2][2] = (float)Math.Cos(rotation);
			return matrix;
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
			//[1 0 0 0]
			//[0 cos(a) -sin(a) 0]
			//[0 sin(a) cos(a) 0]
			//[0 0 0 1]
			var matrix = new Matrix4x4 { };
			matrix = Identity;
			matrix.m[1][1] = (float)Math.Cos(rotation);
			matrix.m[1][2] = -(float)Math.Sin(rotation);
			matrix.m[2][1] = (float)Math.Sin(rotation);
			matrix.m[2][2] = (float)Math.Cos(rotation);
			return matrix;
			throw new NotImplementedException();
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
			//[scale.x 0 0 0]
			//[0 scale.y 0 0]
			//[0 0 scale.z 0]
			//[0 0 0 1]
			var matrix = new Matrix4x4 { };
			matrix = Identity;
			matrix.m[0][0] = scale.x;
			matrix.m[1][1] = scale.y;
			matrix.m[2][2] = scale.z;
			return matrix;
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
			//https://softwareengineering.stackexchange.com/questions/305908/which-algorithm-is-performant-for-matrix-multiplication-of-4x4-matrices-of-affin
			var matrix = new Matrix4x4 { };
			matrix.m[0][0] = lhs.m[0][0] * rhs.m[0][0] + lhs.m[0][1] * rhs.m[1][0] + lhs.m[0][2] * rhs.m[2][0] + lhs.m[0][3] * rhs.m[3][0];
			matrix.m[0][1] = lhs.m[0][0] * rhs.m[0][1] + lhs.m[0][1] * rhs.m[1][1] + lhs.m[0][2] * rhs.m[2][1] + lhs.m[0][3] * rhs.m[3][1];
			matrix.m[0][2] = lhs.m[0][0] * rhs.m[0][2] + lhs.m[0][1] * rhs.m[1][2] + lhs.m[0][2] * rhs.m[2][2] + lhs.m[0][3] * rhs.m[3][2];
			matrix.m[0][3] = lhs.m[0][0] * rhs.m[0][3] + lhs.m[0][1] * rhs.m[1][3] + lhs.m[0][2] * rhs.m[2][3] + lhs.m[0][3] * rhs.m[3][3];
			matrix.m[1][0] = lhs.m[1][0] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[3][0];
			matrix.m[1][1] = lhs.m[1][0] * rhs.m[0][1] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[1][3] * rhs.m[3][1];
			matrix.m[1][2] = lhs.m[1][0] * rhs.m[0][2] + lhs.m[1][1] * rhs.m[1][2] + lhs.m[1][2] * rhs.m[2][2] + lhs.m[1][3] * rhs.m[3][2];
			matrix.m[1][3] = lhs.m[1][0] * rhs.m[0][3] + lhs.m[1][1] * rhs.m[1][3] + lhs.m[1][2] * rhs.m[2][3] + lhs.m[1][3] * rhs.m[3][3];
			matrix.m[2][0] = lhs.m[2][0] * rhs.m[0][0] + lhs.m[2][1] * rhs.m[1][0] + lhs.m[2][2] * rhs.m[2][0] + lhs.m[2][3] * rhs.m[3][0];
			matrix.m[2][1] = lhs.m[2][0] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[3][1];
			matrix.m[2][2] = lhs.m[2][0] * rhs.m[0][2] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[2][3] * rhs.m[3][2];
			matrix.m[2][3] = lhs.m[2][0] * rhs.m[0][3] + lhs.m[2][1] * rhs.m[1][3] + lhs.m[2][2] * rhs.m[2][3] + lhs.m[2][3] * rhs.m[3][3];
			matrix.m[3][0] = lhs.m[3][0] * rhs.m[0][0] + lhs.m[3][1] * rhs.m[1][0] + lhs.m[3][2] * rhs.m[2][0] + lhs.m[3][3] * rhs.m[3][0];
			matrix.m[3][1] = lhs.m[3][0] * rhs.m[0][1] + lhs.m[3][1] * rhs.m[1][1] + lhs.m[3][2] * rhs.m[2][1] + lhs.m[3][3] * rhs.m[3][1];
			matrix.m[3][2] = lhs.m[3][0] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[3][2];
			matrix.m[3][3] = lhs.m[3][0] * rhs.m[0][3] + lhs.m[3][1] * rhs.m[1][3] + lhs.m[3][2] * rhs.m[2][3] + lhs.m[3][3] * rhs.m[3][3];
			return matrix;
		}

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
			//https://opentk.net/learn/chapter1/6-transformations.html
			var vector = new Vector4{ };
			vector.x = lhs.m[0][0] * vector.x + lhs.m[1][0] * vector.y + lhs.m[2][0] * vector.z + lhs.m[3][0] * vector.w;
			vector.y = lhs.m[0][1] * vector.x + lhs.m[1][1] * vector.y + lhs.m[2][1] * vector.z + lhs.m[3][1] * vector.w;
			vector.z = lhs.m[0][2] * vector.x + lhs.m[1][2] * vector.y + lhs.m[2][2] * vector.z + lhs.m[3][2] * vector.w;
			vector.w = lhs.m[0][3] * vector.x + lhs.m[1][3] * vector.y + lhs.m[2][3] * vector.z + lhs.m[3][3] * vector.w;
			return vector;
		}
    }
}
