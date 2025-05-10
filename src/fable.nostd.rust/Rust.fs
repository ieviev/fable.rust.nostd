namespace global

open Fable.Core
open fable.nostd.core

[<Erase; Emit("_")>]
type iter<'t> =
    interface
        abstract next: unit -> voption<'t>

        static member inline Iterate(this: iter<'t>, fn: 't -> unit) : unit =
            let mutable i = this.next ()

            while is_some i do
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
        abstract iter: unit -> rmut<iter<'t>>
        
        abstract len: unit -> unativeint
    end

    static member inline Iterate(this: Vec<'T>, fn: 'T -> unit) : unit =
        let mutable iterator = this.iter()
        iter fn iterator.v
        
// let mutable i = this.next ()
// while is_some i do
//     fn (value i)
//     i <- this.next ()


//     // [<Emit("Vec::new()")>]
//     // static member new_() : Vec<'t> = nativeOnly

//     // [<Emit("$0.push($1)")>]


//     // [<Emit("$0.len()")>]
//     // member inline _.len() : unativeint = nativeOnly

//     // [<Emit("$0[$1 as usize].clone()")>]
//     // member inline _.Item(_: unativeint) : 't = nativeOnly

//     // [<Emit("$0.contains(&$1)")>]
//     // member inline _.contains(_: 't) : bool = nativeOnly

//     // static member inline Iterate(arg: Vec<'t>, [<InlineIfLambda>] fn: 't -> unit) : unit =
//     //     let mutable i: unativeint = 0un
//     //     let endlen = arg.len ()

//     //     while i < endlen do
//     //         fn (arg[i])
//     //         i <- i + 1un

// // end


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
            let lines(arg: r<slice<u8>>) : iter<Result<string,_>> = nativeOnly
            
