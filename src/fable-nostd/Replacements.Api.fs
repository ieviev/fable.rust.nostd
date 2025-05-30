module Fable.Transforms.Replacements.Api

#nowarn "1182"

open Fable
open Fable.AST
open Fable.AST.Fable
open Fable.Transforms

type ICompiler = FSharp2Fable.IFableCompiler

let curryExprAtRuntime (com: Compiler) arity (expr: Expr) =
    match com.Options.Language with
    // | Rust -> Rust.Replacements.curryExprAtRuntime com arity expr
    // // | Python -> Helper.LibCall(com, "Util", "curry", expr.Type, [makeIntConst arity; expr])
    | _ -> Util.curryExprAtRuntime com arity expr

let uncurryExprAtRuntime (com: Compiler) arity (expr: Expr) =
    match com.Options.Language with
    // | Rust -> Rust.Replacements.uncurryExprAtRuntime com expr.Type arity expr
    // // | Python -> Helper.LibCall(com, "Util", "uncurry", expr.Type, [makeIntConst arity; expr])
    | _ -> Util.uncurryExprAtRuntime com arity expr

let partialApplyAtRuntime (com: Compiler) t arity (fn: Expr) (args: Expr list) =
    match com.Options.Language with
    // | Rust -> Rust.Replacements.partialApplyAtRuntime com t arity fn args
    // // | Python ->
    //     let args = NewArray(ArrayValues args, Any, MutableArray) |> makeValue None
    //     Helper.LibCall(com, "Util", "partialApply", t, [makeIntConst arity; fn; args])
    | _ -> Util.partialApplyAtRuntime com t arity fn args

let tryField (com: ICompiler) returnTyp ownerTyp fieldName =
    // stdout.WriteLine $"field: {ownerTyp} : {fieldName}"
    match com.Options.Language with
    | Rust -> Rust.Replacements.tryField com returnTyp ownerTyp fieldName
    // | Python -> Py.Replacements.tryField com returnTyp ownerTyp fieldName
    | _ -> JS.Replacements.tryField com returnTyp ownerTyp fieldName

let tryBaseConstructor
    (com: ICompiler)
    ctx
    (ent: EntityRef)
    (argTypes: Lazy<Type list>)
    genArgs
    args
    =
    match com.Options.Language with
    // | Python -> Py.Replacements.tryBaseConstructor com ctx ent argTypes genArgs args
    | Rust -> Rust.Replacements.tryBaseConstructor com ctx ent argTypes genArgs args
    | _ -> JS.Replacements.tryBaseConstructor com ctx ent argTypes genArgs args

let makeMethodInfo
    (com: ICompiler)
    r
    (name: string)
    (parameters: (string * Type) list)
    (returnType: Type)
    =
    match com.Options.Language with
    | _ -> JS.Replacements.makeMethodInfo com r name parameters returnType

let tryType (com: ICompiler) (t: Type) =
    match com.Options.Language with
    | Rust -> Rust.Replacements.tryType t
    // | Python -> Py.Replacements.tryType t
    | _ -> JS.Replacements.tryType t

let tryCall (com: ICompiler) ctx r t info thisArg args =
    match com.Options.Language with
    | Rust -> Rust.Replacements.tryCall com ctx r t info thisArg args
    // | Python -> Py.Replacements.tryCall com ctx r t info thisArg args
    | _ -> JS.Replacements.tryCall com ctx r t info thisArg args

let error (com: ICompiler) msg =
    match com.Options.Language with
    // | Python -> Py.Replacements.error msg
    | Rust -> Rust.Replacements.error msg
    | _ -> JS.Replacements.error msg

let defaultof (com: ICompiler) ctx r typ =
    match com.Options.Language with
    | Rust -> Rust.Replacements.getZero com ctx typ
    // | Python -> Py.Replacements.defaultof com ctx r typ
    | _ -> JS.Replacements.defaultof com ctx r typ

let createMutablePublicValue (com: ICompiler) value =
    // match com.Options.Language with
    // // | Python -> Py.Replacements.createAtom com value
    // | JavaScript
    // | TypeScript -> JS.Replacements.createAtom com value
    // | Rust
    // | Php
    // | Dart -> 
    value

let getRefCell (com: ICompiler) r typ (expr: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.getRefCell com r typ expr
    | Rust -> Rust.Replacements.getRefCell com r typ expr
    | _ -> JS.Replacements.getRefCell com r typ expr

let setRefCell (com: ICompiler) r (expr: Expr) (value: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.setRefCell com r expr value
    | Rust -> Rust.Replacements.setRefCell com r expr value
    | _ -> JS.Replacements.setRefCell com r expr value

let makeRefCellFromValue (com: ICompiler) r (value: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.makeRefCellFromValue com r value
    | Rust -> Rust.Replacements.makeRefCellFromValue com r value
    | _ -> JS.Replacements.makeRefCellFromValue com r value

let makeRefFromMutableFunc (com: ICompiler) ctx r t (value: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.makeRefFromMutableFunc com ctx r t value
    | Rust -> Rust.Replacements.makeRefFromMutableFunc com ctx r t value
    | _ -> JS.Replacements.makeRefFromMutableFunc com ctx r t value

let makeRefFromMutableValue (com: ICompiler) ctx r t (value: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.makeRefFromMutableValue com ctx r t value
    | Rust -> Rust.Replacements.makeRefFromMutableValue com ctx r t value
    | _ -> JS.Replacements.makeRefFromMutableValue com ctx r t value

let makeRefFromMutableField (com: ICompiler) ctx r t (value: Expr) =
    match com.Options.Language with
    // | Python -> Py.Replacements.makeRefFromMutableField com ctx r t value
    | Rust -> Rust.Replacements.makeRefFromMutableField com ctx r t value
    | _ -> JS.Replacements.makeRefFromMutableField com ctx r t value
