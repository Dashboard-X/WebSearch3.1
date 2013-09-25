using System;
using System.Collections.Generic;
using System.Text;
using WebSearch.Common.Net;

namespace WebSearch.Maths.Net
{
    /// <summary>
    /// ����
    /// </summary>
    public class Vector
    {
        private int size;
        private float[] elements;

        /// <summary>
        /// The size of the vector
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// The elment array of the vector
        /// </summary>
        public float[] Elements
        {
            get { return elements; }
        }

        /// <summary>
        /// Whether all the elements in this vector is 0
        /// </summary>
        public bool IsZero
        {
            get
            {
                for (int i = 0; i < this.size; i++)
                {
                    if (elements[i] != 0)
                        return false;
                }
                return true;
            }
        }

        public Vector()
        {
            this.size = 2;
            this.elements = new float[size];
        }

        public Vector(int size)
        {
            this.size = size;
            this.elements = new float[size];
        }

        public Vector(float x, float y)
        {
            this.size = 2;
            this.elements = new float[size];
            this.elements[0] = x;
            this.elements[1] = y;
        }

        public Vector(float x, float y, float z)
        {
            this.size = 3;
            this.elements = new float[size];
            this.elements[0] = x;
            this.elements[1] = y;
            this.elements[2] = z;
        }

        public Vector Copy()
        {
            Vector result = new Vector(this.size);
            for (int i = 0; i < this.size; i++)
                result.elements[i] = this.elements[i];
            return result;
        }

        /// <summary>
        /// ����ָ���Ķ����Ƿ��� Vector �����Լ��Ƿ��ͬ�ڴ� Vector ����
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool Equals(Vector vector)
        {
            if (this.size != vector.size)
                return false;
            // otherwise, check the elements
            for (int i = 0; i < this.size; i++)
            {
                if (this.elements[i] != vector.elements[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ���� Vector ������ vector ������ָ�����������
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool Add(Vector vector)
        {
            // �������ṹ��ͬ, ���ɽ�һ�����
            if (this.size != vector.size)
                return false;
            for (int i = 0; i < this.size; i++)
                elements[i] += vector.elements[i];
            return true;
        }

        /// <summary>
        /// �����+�����أ����������
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector result = v1.Copy();
            if (result.Add(v2))
                return result;
            return null;
        }

        /// <summary>
        /// ���� Vector ������ vector ������ָ�����������
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool Minus(Vector vector)
        {
            // �������ṹ��ͬ, ���ɽ�һ�����
            if (this.size != vector.size)
                return false;
            for (int i = 0; i < this.size; i++)
                elements[i] -= vector.elements[i];
            return true;
        }

        /// <summary>
        /// �����-�����أ����������
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector result = v1.Copy();
            if (result.Minus(v2))
                return result;
            return null;
        }

        /// <summary>
        /// �����ֳ�������
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public void Multiply(float multiplier)
        {
            for (int i = 0; i < this.size; i++)
                elements[i] *= multiplier;
        }

        /// <summary>
        /// �����*�����أ������ֳ�������
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, float multiplier)
        {
            Vector result = v1.Copy();
            result.Multiply(multiplier);
            return result;
        }

        /// <summary>
        /// �����*�����أ������ֳ�������
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector operator *(float multiplier, Vector v1)
        {
            Vector result = v1.Copy();
            result.Multiply(multiplier);
            return result;
        }

        /// <summary>
        /// ���� Vector ������ vector ������ָ������������
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float DotProduct(Vector vector)
        {
            if (this.size != vector.size)
                return Const.MaximumValue;
            float result = 0;
            for (int i = 0; i < this.size; i++)
                result += (elements[i] * vector.elements[i]);
            return result;
        }

        /// <summary>
        /// ���� Vector ������ vector ������ָ������������
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool CrossProduct(Vector vector)
        {
            Vector v1 = this.ToStandard();
            if (v1 == null) return false;
            Vector v2 = vector.ToStandard();
            if (v2 == null) return false;

            Matrix x = new Matrix(v1.elements[1], v1.elements[2], v2.elements[1], v2.elements[2]);
            Matrix y = new Matrix(v1.elements[0], v1.elements[2], v2.elements[0], v2.elements[2]);
            Matrix z = new Matrix(v1.elements[0], v1.elements[1], v2.elements[0], v2.elements[1]);

            this.elements = new float[3]{x.Modulus, -y.Modulus, z.Modulus};
            this.size = 3;
            return true;
        }

        /// <summary>
        /// �����*�����أ������������Ĳ��
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, Vector v2)
        {
            Vector result = v1.Copy();
            if (result.CrossProduct(v2))
                return result;
            return null;
        }

        /// <summary>
        /// �е�ǰ��������һ����׼����������(xi, yj, zk)
        /// </summary>
        /// <returns></returns>
        public Vector ToStandard()
        {
            if (this.size > 3)
                return null;
            Vector result = new Vector(3);
            switch (this.size)
            {
                case 1:
                    result.elements[0] = elements[0];
                    result.elements[1] = 0;
                    result.elements[2] = 0;
                    return result;
                case 2:
                    result.elements[0] = elements[0];
                    result.elements[1] = elements[1];
                    result.elements[2] = 0;
                    return result;
                case 3:
                    result.elements[0] = elements[0];
                    result.elements[1] = elements[1];
                    result.elements[2] = elements[2];
                    return result;
                default:
                    return null;
            }
        }
    }
}
