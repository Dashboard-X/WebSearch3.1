using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WebSearch.Maths.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class Equation
    {
        /// <summary>
        /// equation �г�����ı�־
        /// </summary>
        public static readonly char C = 'C';

        protected bool isValid = true;

        /// <summary>
        /// 
        /// </summary>
        public bool IsValid
        {
            get { return this.isValid; }
            set { this.isValid = value; }
        }
    }
}
