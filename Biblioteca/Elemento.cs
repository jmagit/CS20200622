using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca {
    public class Elemento<T> {
        public T Key { get; set; }
        public string Value { get; set; }

        public Elemento(T key, string value) {
            Key = key;
            Value = value;
        }
    }
    //public class ElementoString {
    //    public string Key { get; set; }
    //    public string Value { get; set; }
    //}
    //public class Elemento {
    //    public object Key { get; set; }
    //    public string Value { get; set; }
    //}
    public class ElementoInt {
        public int Key { get; set; }
        public string Value { get; set; }
        public ElementoInt(int key, string value) {
            Key = key;
            Value = value;
        }
    }
}
