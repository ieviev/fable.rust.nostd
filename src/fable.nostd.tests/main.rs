#![allow(unused, dead_code, non_snake_case, non_upper_case_globals,)]
fn test(a: Vec<u8>) {
    let mut iterator: &mut _ = &mut a.into_iter();
    let mut this__1: _ = iterator;
    let mut i: Option<u8> = this__1.next();
    while i.is_some() { println!("just iterating",); i = this__1.next() }
}
fn testsum(a: Vec<u8>) -> u8 {
    let mut state: u8 = 0_u8;
    {
        let mut action_1 = move |v_2: u8| state = (state) + (v_2);
        let mut iterator: &mut _ = &mut a.into_iter();
        let mut this__1: _ = iterator;
        let mut i: Option<u8> = this__1.next();
        while i.is_some() { action_1(i.unwrap()); i = this__1.next() }
    }
    state
}
fn exists1(a: Vec<u8>) -> bool {
    let mut notfound: bool = true;
    {
        let mut arg2_ = move |v_2: u8| notfound = !((v_2) == 1_u8);
        let mut cond = &notfound;
        let mut iterator: _ = &mut a.into_iter();
        let mut i: Option<u8> = iterator.next();
        let mut local_cond: bool = &cond;
        while if &cond { i.is_some() } else { false } {
            arg2_(i.unwrap());
            i = iterator.next();
            local_cond = &cond
        }
    }
    !notfound
}
fn test2(a: Vec<u8>) {
    let mut num_of_lines: i32 = 0_i32;
    let mut lines: _ = std::io::BufRead::lines(a.as_slice());
    let mut f =
        move |v: Result<String, _>|
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
