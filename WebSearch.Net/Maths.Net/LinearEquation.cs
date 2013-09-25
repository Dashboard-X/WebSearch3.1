using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WebSearch.Maths.Net
{
    /// <summary>
    /// һ�η��� (Simple Equation/Linear Equation)
    /// </summary>
    public class LinearEquation : PolynomialEquation
    {
        #region Indexer
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public float this[char name]
        {
            get { return ((EquationNode)equationNodes[name]).C; }
            set { ((EquationNode)equationNodes[name]).C = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// ���캯��1��Ĭ�Ϲ��캯��
        /// </summary>
        public LinearEquation() : base()
        {
        }

        /// <summary>
        /// ���캯��2
        /// </summary>
        /// <param name="nodes"></param>
        public LinearEquation(Hashtable nodes) : base(nodes)
        {
            foreach (EquationNode node in nodes)
                // ֻ����ʹ����(p = 0)��һ����(p = 1)
                if (node.P > 1) this.isValid = false;
        }

        /// <summary>
        /// ���캯��3��ax + by + c = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public LinearEquation(float a, float b, float c) : base()
        {
            this.equationNodes.Add('x', new EquationNode(a, 'x'));
            this.equationNodes.Add('y', new EquationNode(b, 'y'));
            this.equationNodes.Add(Equation.C, new EquationNode(c));
        }

        /// <summary>
        /// ���캯��4��ax + by + cz + d = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public LinearEquation(float a, float b, float c, float d) : base()
        {
            this.equationNodes.Add('x', new EquationNode(a, 'x'));
            this.equationNodes.Add('y', new EquationNode(b, 'y'));
            this.equationNodes.Add('z', new EquationNode(c, 'z'));
            this.equationNodes.Add(Equation.C, new EquationNode(d));
        }

        /// <summary>
        /// ��ǰ Equation ����ĸ���
        /// </summary>
        /// <returns></returns>
        public LinearEquation Copy()
        {
            return new LinearEquation(equationNodes);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// ��ǰ Equation ����һ�������� Equation Node
        /// </summary>
        /// <param name="node"></param>
        public override void Add(EquationNode node)
        {
            node.P = (node.P <= 1) ? node.P : 1;
            // if already has such a node with the same name
            if (this.equationNodes.ContainsKey(node.Name))
                ((EquationNode)this.Nodes[node.Name]).C += node.C;
            else
                this.equationNodes.Add(node.Name, node);
        }

        /// <summary>
        /// �Ƴ�ָ����Ԫ���� Equation Node
        /// </summary>
        /// <param name="name"></param>
        public void Remove(char name)
        {
            this.equationNodes.Remove(name);
        }

        /// <summary>
        /// ���ݸ����ı���ֵ����÷��̵Ľ��
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public float Value(Hashtable param)
        {
            float result = 0;
            foreach (EquationNode node in this.equationNodes)
                // �ۼ�ÿ�� Equation Node ��ֵ
                if (param.ContainsKey(node.Name))
                    result += node.Value((float)param[node.Name]);
                // ����δ��������ֵ��node����Ϊ0����
            return result;
        }

        /// <summary>
        /// �����+�����أ���һ�η������
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static LinearEquation operator +(LinearEquation e1, LinearEquation e2)
        {
            LinearEquation result = e1.Copy();
            foreach (EquationNode node in e2.equationNodes)
                result.Add(node);
            return result;
        }
        #endregion
    }
}
