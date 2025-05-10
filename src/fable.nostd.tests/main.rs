#![allow(unused, dead_code, non_snake_case, non_upper_case_globals,)]
fn test(a: Vec<u8>) {
    let mut iterator: &mut _ = &mut a.iter();
    let mut this__1: _ = iterator;
    let mut i: Option<_> = this__1.next();
    while i.is_some() { println!("iterating! 1",); i = this__1.next() }
}
fn test2(a: Vec<u8>) {
    let mut num_of_lines: i32 = 0_i32;
    let mut lines: _ = std::io::BufRead::lines(a.as_slice());
    let mut f =
        move |_arg: Result<String, _>|
            {
                println!("iterating lines",);
                num_of_lines = (num_of_lines) + 1_i32
            };
    let mut this_ = lines;
    let mut i = this_.next();
    while i.is_some() { f(i.unwrap()); i = this_.next() }
}
fn main() -> Result<(), String> {
    let mut s: &str = "main.fs";
    let mut file_result: Vec<u8> =
        {
            let mut source: Result<Vec<u8>, _> = std::fs::read(s);
            source.unwrap()
        };
    let mut num_bytes: usize = file_result.len();
    println!("read {} bytes!", num_bytes);
    Ok::<(), String>(())
}
