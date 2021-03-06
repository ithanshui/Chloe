﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Chloe.DbExpressions
{
    public class DbFunctionExpression : DbExpression
    {
        MethodInfo _method;
        ReadOnlyCollection<DbExpression> _parameters;
        public DbFunctionExpression(Type type, MethodInfo method, IList<DbExpression> parameters)
            : base(DbExpressionType.Function, type)
        {
            this._method = method;
            this._parameters = new ReadOnlyCollection<DbExpression>(parameters);
        }

        public MethodInfo Method { get { return this._method; } }
        public ReadOnlyCollection<DbExpression> Parameters { get { return this._parameters; } }

        public override T Accept<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
