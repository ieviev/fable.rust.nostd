namespace global

open Fable.Core
open fable.nostd.core

[<Erase; Emit("_")>]
type Iter<'t> =
    interface
        abstract next: unit -> voption<'t>

        static member inline Iterate
            (this: Iter<'t>, [<InlineIfLambda>] fn: 't -> unit)
            : unit =
            let mutable i = this.next ()

            while is_some i do
                let v = unwrap (i)
                fn v
                i <- this.next ()

        static member inline IterateWhile
            (this: Iter<'t>, cond: byref<bool>, [<InlineIfLambda>] fn: 't -> unit)
            : unit =
            let mutable i = this.next ()

            while deref cond && is_some i do
                let v = unwrap (i)
                fn v
                i <- this.next ()

    end

[<Erase; Emit("Vec<$0>")>]
type Vec<'t> =
    interface
        abstract push: 't -> unit
        abstract ``new``: unit -> Vec<'t>
        abstract as_slice: unit -> r<slice<'t>>

        [<Emit("&mut $0.iter()")>]
        abstract iter: unit -> rmut<Iter<r<'t>>>

        [<Emit("&mut $0.into_iter()")>]
        abstract into_iter: unit -> rmut<Iter<'t>>

        abstract len: unit -> unativeint
    end

    static member inline Iterate
        (this: Vec<'t>, [<InlineIfLambda>] fn: 't -> unit)
        : unit =
        let mutable iterator = this.into_iter ()
        iter fn iterator.v

    static member inline IterateWhile
        (this: Vec<'t>, cond: byref<bool>, [<InlineIfLambda>] fn: 't -> unit)
        : unit =
        let iterator = this.into_iter().v
        let mutable i = iterator.next ()

        while deref cond && is_some i do
            let v = unwrap (i)
            fn v
            i <- iterator.next ()


[<Erase>]
type fs =

    [<Emit("std::fs::read($0)")>]
    static member read(path: r<str>) : Result<Vec<u8>, _> = nativeOnly

    [<Emit("std::fs::read($0.as_str()).unwrap()")>]
    static member read_unsafe(path: string) : Vec<u8> = nativeOnly

    // [<Emit("std::fs::read($0).unwrap()")>]
    // static member read_unsafe(path: _str) : Vec<byte> = nativeOnly

    [<Emit("std::fs::read_to_string($0)")>]
    static member read_to_string(path: str) : Result<string, obj> = nativeOnly

    [<Emit("std::fs::read_to_string($0.as_str())")>]
    static member read_to_string(path: string) : Result<string, obj> = nativeOnly

    [<Emit("std::fs::read_to_string($0.as_str()).map_err(|e| e.to_string())")>]
    static member read_to_string_err(path: string) : Result<string, string> = nativeOnly


module std =
    module io =
        module BufRead =
            [<Emit("std::io::BufRead::lines($0)")>]
            let lines(arg: r<slice<u8>>) : Iter<Result<string, _>> = nativeOnly
