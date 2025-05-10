pub mod std {
    use super::*;
    pub mod io {
        use super::*;
        pub mod BufRead {
            use super::*;
            use std::rc::Rc;
            pub trait Impl: core::fmt::Debug + core::fmt::Display {
                fn lines<a: Clone + 'static>(arg: &[u8])
                -> _;
            }
            impl <V: Impl + core::fmt::Debug + core::fmt::Display> Impl for
             Rc<V> {
                #[inline]
                fn lines<a: Clone + 'static>(arg: &[u8]) -> _ {
                    V::lines(arg)
                }
            }
            pub fn lines<a: Clone + 'static>(arg: &[u8]) -> _ {
                panic!("{}",
                       "A function supposed to be replaced by native code has been called, please check.".to_string(),)
            }
        }
    }
}
