namespace global

open Fable.Core

type u8 = byte
type usize = unativeint
type isize = nativeint
type u32 = uint32
type i32 = int32
type u64 = uint64

/// rust reference (&)
[<Erase; Emit("&$0"); AbstractClass>]
type r<'t> =
    [<Emit("$0")>]
    member self.v: 't = nativeOnly

    [<Emit("&$0")>]
    static member inline from(arg: 't) : r<'t> = nativeOnly

    [<Emit("*$0")>]
    member self.deref: 't = nativeOnly

/// mutable reference (&mut)
[<Erase; Emit("&mut $0")>]
type rmut<'t> =
    class
    end

    [<Emit("$0")>]
    member self.v: 't = nativeOnly

    [<Emit("&mut $0")>]
    static member inline from(_: 't) : rmut<'t> = nativeOnly


/// mutable pointer (*mut)
[<Erase; Struct; Emit("*mut $0")>]
type pmut<'t> =
    struct
    end

    [<Emit("Box::into_raw(Box::new($0))")>]
    static member inline from(arg: 't) : pmut<'t> = nativeOnly

    [<Emit("Box::into_raw(Box::new($0))")>]
    static member inline from_boxed(arg: 't) : pmut<'t> = nativeOnly

    [<Emit("($0 as u32)")>]
    static member as_u32(arg: pmut<'t>) : uint32 = nativeOnly

    [<Emit("unsafe {drop(Box::from_raw($0))}")>]
    static member drop(arg: pmut<'t>) : unit = nativeOnly

    [<Emit("$0.as_ref()")>]
    member self.as_ref() : Option<r<'t>> = nativeOnly

    [<Emit("$0.as_mut()")>]
    member self.as_mut() : Option<rmut<'t>> = nativeOnly

    [<Emit("($0 as u32)")>]
    member this.as_u32(_: pmut<'t>) : uint32 = nativeOnly

    [<Emit("$0.as_mut()")>]
    member self.as_mut_cast<'u>() : Option<'u> = nativeOnly

    [<Emit("unsafe{$0.as_mut().unwrap()}")>]
    member self.deref_unsafe_cast<'u>() : 'u = nativeOnly

    [<Emit("unsafe{$0.as_mut().unwrap()}")>]
    member self.deref_unsafe() : rmut<'t> = nativeOnly


// System.Text.SpanRuneEnumerator

[<Erase; Emit("[$0]")>]
type slice<'t> = class end

type str =
    class
    end
