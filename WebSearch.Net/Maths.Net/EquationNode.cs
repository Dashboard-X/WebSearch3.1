using System;
using System.Collections.Generic;
using System.Text;

namespace WebSearch.Maths.Net
{
    public class EquationNode
    {
        private float coefficient = 1;      // ϵ��
        private int power = 0;              // Ȩֵ
        private char metaVariable;          // Ԫ������

        private bool isValid = true;

        public float C
        {
            get { return this.coefficient; }
            set { this.coefficient = value; }
        }
        public int P
        {
            get { return this.power; }
            set { this.power = value; }
        }
        public char Name
        {
            get { return this.metaVariable; }
            set { this.metaVariable = value; }
        }
        public bool IsValid
        {
            get { return this.isValid; }
            set { this.isValid = value; }
        }
        public bool IsConstant
        {
            get { return this.power == 0 || this.IsZero; }
        }
        public bool IsZero
        {
            get { return this.coefficient == 0; }
        }

        /// <summary>
        /// ��ʼ��Ϊϵ��Ϊ1��һ�α�Ԫ (�� x)
        /// </summary>
        /// <param name="name"></param>
        public EquationNode(char name)
        {
            //this.coefficient = 1;
            this.metaVariable = name;
            this.power = 1;
        }

        /// <summary>
        /// ��ʼ��Ϊһ���� (�� 2)
        /// </summary>
        /// <param name="c"></param>
        public EquationNode(float c)
        {
            this.metaVariable = Equation.C;
            this.coefficient = c;
            //this.power = 0;
        }

        /// <summary>
        /// ��ʼ��Ϊ����ϵ����һ�α�Ԫ (�� 2x)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        public EquationNode(float c, char name)
        {
            if (name == Equation.C)
                throw new ArgumentException("Invalid constant equation node");
            this.coefficient = c;
            this.metaVariable = name;
            this.power = 1;
        }

        /// <summary>
        /// ��ʼ��Ϊϵ��Ϊ1��node (�� x^2)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="p"></param>
        public EquationNode(char name, int p) 
        {
            if (name == Equation.C && p != 0)
                throw new ArgumentException("Invalid constant equation node");
            this.metaVariable = name;
            this.power = p;
        }

        /// <summary>
        /// ��ʼ��Ϊ����ϵ����p�α�Ԫ (�� 2x^2)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="p"></param>
        public EquationNode(float c, char name, int p)
        {
            if (name == Equation.C && p != 0)
                throw new ArgumentException("Invalid constant equation node");
            this.coefficient = c;
            this.metaVariable = name;
            this.power = p;
        }

        /// <summary>
        /// ���ݸ����ı���ֵ�����node��ֵ
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public float Value(float param)
        {
            return coefficient * (float)Math.Pow(param, power);
        }
    }
}
