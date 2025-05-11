
experimental fork of [Fable](https://github.com/fable-compiler/Fable) that generates rust without F# standard library using [inlined definitions](https://github.com/ieviev/fsil) instead.

see [source F\#](./src/fable.nostd.tests/main.fs) and [generated Rust](./src/fable.nostd.tests/main.rs)

the bindings can be generalized from the definitions in the [rust library itself](src/fable.nostd.rust/Rust.fs)
