﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CML.Lib
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：BizException.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BizException
    /// 创建标识：cml 2018/2/28 15:35:56
    /// </summary>
    [Serializable]
    public class BizException : Exception
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public BizException()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="msg">异常信息</param>
        public BizException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="msg">异常信息</param>
        /// <param name="innerException">异常</param>
        public BizException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public BizException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}