using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WebSearch.Maths.Net
{
    /// <summary>
    /// ����ʽ����
    /// </summary>
    public class PolynomialEquation : Equation
    {
        // equation nodes ���б�keyΪnode��Ȩֵ��valueΪnode
        protected Hashtable equationNodes = new Hashtable();

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Hashtable Nodes
        {
            get { return this.equationNodes; }
            set { this.equationNodes = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int Length
        {
            get { return this.equationNodes.Count; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// ���캯��1��Ĭ�Ϲ��캯��
        /// </summary>
        public PolynomialEquation()
        {
        }

        /// <summary>
        /// ���캯��2
        /// </summary>
        /// <param name="nodes"></param>
        public PolynomialEquation(Hashtable nodes)
        {
            this.equationNodes = (Hashtable)nodes.Clone();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// ��ǰ����ʽ���̼���һ�������� Equation Node
        /// </summary>
        /// <param name="node"></param>
        public virtual void Add(EquationNode node)
        {
            this.equationNodes.Add(node.Name, node);
        }

        /// <summary>
        /// �����ǰ����ʽ�����е�����
        /// </summary>
        public virtual void Clear()
        {
            this.equationNodes.Clear();
        }
        #endregion
    }
}
