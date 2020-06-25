using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EjerciciosCurso.Util {
    public static class ValidacionesExtender {
        public static bool IsEmpty(this String value) {
            return String.IsNullOrWhiteSpace(value);
        }
        public static bool IsFilled(this String value) {
            return String.IsNullOrWhiteSpace(value);
        }
        public static bool IsNumeric(this String value) {
            return decimal.TryParse(value, out decimal numero);
            // return value.All(char.IsNumber);
        }
        public static bool NotIsNumeric(this String value) {
            return !IsNumeric(value);
        }
        /// <summary>
        /// Valida la longitud máxima de la cadena
        /// </summary>
        /// <param name="value">Valor a validar</param>
        /// <param name="len">longitud maxima</param>
        /// <returns>Cumple la regla</returns>
        public static bool IsLenMax(this String value, int len) {
            return (value ?? "").Length <= len;
        }
        public static bool NotIsLenMax(this String value, int len) {
            return !IsLenMax(value, len);
        }
        public static bool IsLenMin(this String value, int len) {
            return (value ?? "").Length >= len;
        }
        public static bool NotIsLenMin(this String value, int len) {
            return !IsLenMin(value, len);
        }
        public static bool IsPositive(this String value) {
            if(double.TryParse(value, out double numero)) 
                throw new ArgumentException("No es un número");
            return IsPositive(numero);
        }
        public static bool NotIsPositive(this String value) {
            return !IsPositive(value);
        }
        public static bool IsPositive(this double value) {
            return value > 0;
        }
        public static bool NotIsPositive(this double value) {
            return !IsPositive(value);
        }

        public static bool IsEmail(this string email) {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public static bool NotIsEmail(this string email) {
            return !IsEmail(email);
        }

        public static bool IsURL(string url) {
            return Regex.IsMatch(url,
                @"^((http\://|https\://)|(www.))+(([a-zA-Z0-9\.-]+\.[a-zA-Z]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9%:/-_\?\.'~]*)?");
        }
        public static bool NotIsURL(this string url) {
            return !IsURL(url);
        }

    }
}
