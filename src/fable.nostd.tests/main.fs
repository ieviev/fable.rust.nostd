open fable.nostd.rust
open fable.nostd.core

let test(a: Vec<u8>) =
    a |> iter (fun _ -> printfn ("just iterating"))

let testsum(a: Vec<u8>) = a |> fold 0uy (fun acc v -> acc + v)

let exists1(a: Vec<u8>) = a |> exists (fun v -> v = 1uy)

let test2(a: Vec<u8>) =
    let mutable num_of_lines = 0
    let mutable lines = std.io.BufRead.lines (a.as_slice ())

    iter
        (fun v ->
            printfn ($"iterating lines")
            num_of_lines <- num_of_lines + 1)
        lines


let main() : Result<unit, string> =
    let s = str "main.fs"
    let file_result = fs.read (s) |> unwrap
    let byte_slice = file_result

    let num_bytes = byte_slice.len ()

    printfn $"read {num_bytes} bytes!"
    Ok()

// main ()
