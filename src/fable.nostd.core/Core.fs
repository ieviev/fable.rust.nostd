[<AutoOpen>]
module fable.nostd.core

open Fable.Core

let (!!) x : 'T = nativeOnly

// & would override byref<>
let inline (~&&) x = r.from x
let inline (!&) x = rmut.from x
let inline (!*) x = pmut.from x

/// Implicit cast for erased unions (U2, U3...)
let inline (!^)(x: ^t1) : ^t2 =
    ((^t1 or ^t2): (static member op_ErasedCast: ^t1 -> ^t2) x)

/// Dynamically access a property of an arbitrary object.
/// `myObj?propA` in JS becomes `myObj.propA`
/// `myObj?(propA)` in JS becomes `myObj[propA]`
let (?) (o: obj) (prop: obj) : 'a = nativeOnly

/// Dynamically assign a value to a property of an arbitrary object.
/// `myObj?propA <- 5` in JS becomes `myObj.propA = 5`
/// `myObj?(propA) <- 5` in JS becomes `myObj[propA] = 5`
let (?<-) (o: obj) (prop: obj) (v: obj) : unit = nativeOnly

/// &str slice from (const) string
let str(_: string) : r<str> = nativeOnly

[<AbstractClass; Sealed; AutoOpen; Erase>]
type Open =
    [<Emit("$0.unwrap()")>]
    static member inline unwrap(source: Result<'t, _>) : 't = nativeOnly

    [<Emit("$0.unwrap()")>]
    static member inline unwrap(source: option<'t>) : 't = nativeOnly
    [<Emit("$0.unwrap()")>]
    static member inline unwrap(source: voption<'t>) : 't = nativeOnly

    [<Emit("$1.expect($0)")>]
    static member inline expect (msg: r<str>) (source: Result<'t, _>) : 't = nativeOnly

    /// requires const string
    static member inline emit(s: string) = RustInterop.emitRustExpr "" s

    [<Emit("*$0")>]
    static member inline ``*``(_: _) : 't = nativeOnly
    [<Emit("*$0")>]
    static member inline deref(_: _) : 't = nativeOnly

