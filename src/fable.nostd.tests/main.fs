open fable.nostd.rust
open fable.nostd.core

let iterate(a: Vec<u8>) =
    a |> iter (fun _ -> printfn ("just iterating"))

let foldsum(a: Vec<u8>) = a |> fold 0uy (fun acc v -> acc + v)

let exists123(a: Vec<u8>) = a |> exists (fun v -> v = 123uy)

let iteratelines(a: Vec<u8>) =
    let mutable num_of_lines = 0
    let mutable lines = std.io.BufRead.lines (a.as_slice ())

    lines
    |> iter (fun v ->
        printfn ($"iterating lines: {unwrap v}")
        num_of_lines <- num_of_lines + 1)


let main() : Result<unit, string> =
    let s = str "main.fs"
    let file_result = fs.read (s) |> unwrap

    let num_bytes = file_result.len ()

    printfn $"read {num_bytes} bytes!"
    Ok()

// main ()
