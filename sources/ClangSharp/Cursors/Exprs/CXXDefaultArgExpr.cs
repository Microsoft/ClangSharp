// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using ClangSharp.Interop;

namespace ClangSharp
{
    public sealed class CXXDefaultArgExpr : Expr
    {
        private readonly Lazy<Expr> _expr;
        private readonly Lazy<ParmVarDecl> _param;
        private readonly Lazy<IDeclContext> _usedContext;

        internal CXXDefaultArgExpr(CXCursor handle) : base(handle, CXCursorKind.CXCursor_UnexposedExpr, CX_StmtClass.CX_StmtClass_CXXDefaultArgExpr)
        {
            _expr = new Lazy<Expr>(() => TranslationUnit.GetOrCreate<Expr>(Handle.SubExpr));
            _param = new Lazy<ParmVarDecl>(() => TranslationUnit.GetOrCreate<ParmVarDecl>(Handle.Referenced));
            _usedContext = new Lazy<IDeclContext>(() => TranslationUnit.GetOrCreate<Decl>(Handle.UsedContext) as IDeclContext);
        }

        public Expr Expr => _expr.Value;

        public ParmVarDecl Param => _param.Value;

        public IDeclContext UsedContext => _usedContext.Value;
    }
}
