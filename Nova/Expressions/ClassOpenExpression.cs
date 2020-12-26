﻿// -----------------------------------------------------------------------
// <copyright file="ClassOpenExpression.cs" Company="Michael Tindal">
// Copyright 2011-2014 Michael Tindal
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nova.Runtime;

namespace Nova.Expressions
{
    using CS = CompilerServices;

    public class ClassOpenExpression : NovaExpression
    {
        internal ClassOpenExpression(Expression name,
            List<Expression> contents)
        {
            Name = name;
            Contents = contents;
        }

        public Expression Name { get; private set; }

        public List<Expression> Contents { get; private set; }

        public override Type Type
        {
            get { return typeof(NovaClass); }
        }

        public override string ToString()
        {
            return "";
        }

        public override Expression Reduce()
        {
            return Operation.DefineClassOpen(typeof(NovaClass), Constant(Name), Constant(Contents),
                Constant(Scope));
        }

        public override void SetChildrenScopes(NovaScope scope)
        {
            Name.SetScope(scope);
            Contents.ForEach(content => content.SetScope(scope));
        }
    }
}
