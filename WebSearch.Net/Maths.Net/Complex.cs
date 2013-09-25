using System;
using System.Collections.Generic;
using System.Text;

namespace WebSearch.Maths.Net
{
    /// <summary>
    /// ����
    /// </summary>
    public class Complex
    {
        // Get zero value
        public static Complex Zero
        {
            get { return new Complex(0, 0); }
        }

        private float real;
        private float image;

        public float Real
        {
            get { return this.real; }
            set { this.real = value; }
        }
        public float Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        /// <summary>
        /// �жϻ����õ�ǰ�����Ƿ�Ϊ0
        /// </summary>
        public bool IsZero
        {
            get { return (real == 0 && image == 0); }
            set
            {
                if (value == true)
                    real = image = 0;
                else
                {
                    if (real == 0 && image == 0)
                        real = 1;
                }
            }
        }

        /// <summary>
        /// �жϵ�ǰ�����Ƿ�Ϊһʵ��
        /// </summary>
        public bool IsReal
        {
            get { return this.image == 0; }
        }

        /// <summary>
        /// ��ǰ������ģ
        /// </summary>
        public float Abs
        {
            get
            {
                if (this.IsZero) return 0;
                float x = Math.Abs(this.real);
                float y = Math.Abs(this.image);
                return (float)((x > y) ? x * Math.Sqrt(1 + (y / x) * (y / x))
                    : y * Math.Sqrt(1 + (x / y) * (x / y)));
            }
        }

        /// <summary>
        /// ��ǰ�����ĽǶ�
        /// </summary>
        public double Sita
        {
            get
            {
                double sita;
                if (this.IsReal)            // �����ʵ��
                    sita = (this.real >= 0) ? 0 : Math.PI;
                else if (this.real == 0)    // �������ʵ��Ϊ0
                    sita = (image > 0) ? Math.PI / 2 : -Math.PI / 2;
                else                        // ����(�������)
                    sita = (real > 0) ? Math.Atan(image / real)
                        : Math.Atan(image / real) + Math.PI;
                return sita;
            }
        }

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Complex()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="real"></param>
        /// <param name="image"></param>
        public Complex(float real, float image)
        {
            this.real = real;
            this.image = image;
        }
        #endregion

        /// <summary>
        /// ���Ƶ�ǰ����
        /// </summary>
        /// <returns></returns>
        public Complex Copy()
        {
            return new Complex(real, image);
        }

        /// <summary>
        /// ��ǰ��������ָ���ĸ���
        /// </summary>
        /// <param name="complex"></param>
        public void Add(Complex complex)
        {
            this.real += complex.real;
            this.image += complex.image;
        }

        /// <summary>
        /// �����ӷ����ŵ�����
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real + c2.real;
            result.image = c1.image + c2.image;
            return result;
        }

        /// <summary>
        /// ��ǰ������ȥָ���ĸ���
        /// </summary>
        /// <param name="complex"></param>
        public void Minus(Complex complex)
        {
            this.real -= complex.real;
            this.image -= complex.image;
        }

        /// <summary>
        /// �����������ŵ�����
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real - c2.real;
            result.image = c1.image - c2.image;
            return result;
        }

        /// <summary>
        /// ��ǰ��������ָ���ĸ���
        /// </summary>
        /// <param name="complex"></param>
        public void Multiply(Complex complex)
        {
            float r = this.real * complex.real - this.image * complex.image;
            float i = this.real * complex.image + this.image * complex.real;
            this.real = r;
            this.image = i;
        }

        /// <summary>
        /// �����˷����ŵ�����
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real * c2.real - c1.image * c2.image;
            result.image = c1.real * c2.image + c1.image * c2.real;
            return result;
        }

        /// <summary>
        /// ��ǰ��������ָ���ĸ���
        /// </summary>
        /// <param name="complex"></param>
        public void Divide(Complex complex)
        {
            float divider = complex.real * complex.real +
                complex.image * complex.image;

            if (divider == 0)
                throw new DivideByZeroException();

            float tempReal = (real * complex.real + image * complex.image) / divider;
            float tempImg = (image * complex.real - real * complex.image) / divider;
            this.real = tempReal;
            this.image = tempImg;
        }

        /// <summary>
        /// �����������ŵ�����
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator /(Complex c1, Complex c2)
        {
            float divider = c2.real * c2.real + c2.image * c2.image;

            if (divider == 0)
                throw new DivideByZeroException();

            return new Complex(
                (c1.real * c2.real + c1.image * c2.image) / divider,
                (c1.image * c2.real - c1.real * c2.image) / divider);
        }

        /// <summary>
        /// ���㵱ǰ�����ĸ�
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Complex�����飬���ڷ������еĸ�</returns>
        public Complex[] Root(int n)
        {
            Complex[] result = new Complex[n];
            double sita, csita, ssita, w = Math.PI * 2 / n, r, cw, sw;
            if (this.IsReal)            // �����ʵ��
                sita = (this.real >= 0) ? 0 : Math.PI / n;
            else if (this.real == 0)    // �������ʵ��Ϊ0
                sita = (this.image > 0) ? Math.PI / 2 / n
                    : (float)-Math.PI / 2 / n;
            else                        // ����(�������)
                sita = (real > 0) ? Math.Atan(image / real) / n
                    : (Math.Atan(image / real) + Math.PI) / n;

            csita = Math.Cos(sita);
            ssita = Math.Sin(sita);
            cw = Math.Cos(w);
            sw = Math.Sin(w);
            r = Math.Pow(this.Abs, (double)1 / n);
            double c = 1, s = 0, temp;
            for (int i = 0; i < n; i++)
            {
                result[i].real = (float)(r * (csita * c - ssita * s));
                result[i].image = (float)(r * (ssita * c + csita * s));
                temp = c;
                c = c * cw - s * sw;
                s = s * cw + temp * sw;
            }
            return result;
        }

        /// <summary>
        /// ��ǰ������ʵ��ָ��
        /// </summary>
        /// <param name="w"></param>
        public void Pow(float w)
        {
            double sita, r = Math.Pow(this.Abs, w);
            sita = Angle.ToStandard(this.Sita * w);
            this.real = (float)(r * Math.Cos(sita));
            this.image = (float)(r * Math.Sin(sita));
        }

        /// <summary>
        /// ��ǰ�����ĸ���ָ��
        /// </summary>
        /// <param name="w"></param>
        public void Pow(Complex w)
        {
            this.Ln();
            Complex temp = this * w;
            this.real = (float)(Math.Exp(temp.real) * Math.Cos(temp.image));
            this.image = (float)(Math.Exp(temp.real) * Math.Sin(temp.image));
        }

        /// <summary>
        /// �������������Ȼ����
        /// </summary>
        /// <param name="complex"></param>
        /// <returns></returns>
        public static Complex Ln(Complex complex)
        {
            return new Complex((float)Math.Log(complex.Abs), 
                (float)complex.Sita);
        }

        /// <summary>
        /// ��ǰ��������Ȼ����
        /// </summary>
        public void Ln()
        {
            double tmpreal = Math.Log(this.Abs);
            double tmpimg = this.Sita;
            this.real = (float)tmpreal;
            this.image = (float)tmpimg;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Complex Sin(Complex a)
        {
            double x = a.real;
            double y = Math.Exp(a.image);
            return new Complex((float)(Math.Sin(x) * (y + 1.0 / y) / 2),
                (float)(Math.Cos(x) * (y - 1.0 / y) / 2));
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Complex Cos(Complex a)
        {
            double x = a.real;
            double y = Math.Exp(a.image);
            return new Complex((float)(Math.Cos(x) * (y + 1.0 / y) / 2), 
                (float)(Math.Sin(x) * (1.0 / y - y) / 2));
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Complex Tan(Complex a)
        {
            return (Complex.Sin(a) / Complex.Cos(a));
        }
    }
}
