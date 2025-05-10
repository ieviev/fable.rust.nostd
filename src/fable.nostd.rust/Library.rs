pub mod fable {
    use super::*;
    pub mod nostd {
        use super::*;
        pub mod rust {
            use super::*;
            pub fn str__str_to_string(_: str) -> String {
                panic!("{}",
                       "A function supposed to be replaced by native code has been called, please check.".to_string(),)
            }
            pub fn str__str_as_bytes(_: str) -> &[u8] {
                panic!("{}",
                       "A function supposed to be replaced by native code has been called, please check.".to_string(),)
            }
            pub fn str__str_bytes_Static() -> _ {
                panic!("{}",
                       "A function supposed to be replaced by native code has been called, please check.".to_string(),)
            }
        }
    }
}
