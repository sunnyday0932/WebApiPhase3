using System;
using System.Collections.Generic;
using System.Linq;
using Validation;

namespace WebApiPhase3Common
{
    public static class ParameterValidator
    {
        /// <summary>
        /// Checks the not null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="nullExceptionMessage">The null exception message.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void CheckNotNullOrEmpty(
            [ValidatedNotNull] this string value,
            string parameterName,
            string nullExceptionMessage = "",
            string exceptionMessage = "")
        {
            if (string.IsNullOrWhiteSpace(value).Equals(false))
            {
                return;
            }

            if (value is null)
            {
                throw new ArgumentNullException
                (
                    paramName: parameterName,
                    message: string.IsNullOrWhiteSpace(nullExceptionMessage)
                    ? $"{parameterName}不可為Null"
                    : nullExceptionMessage
                );
            }

            throw new ArgumentException
                (
                    paramName: parameterName,
                    message: string.IsNullOrWhiteSpace(exceptionMessage)
                    ? $"{parameterName} 不可為空"
                    : exceptionMessage
                );
        }

        /// <summary>
        /// Checks the not out of range.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void CheckNotOutOfRange(
            this int value,
            bool condition,
            string parameterName,
            string exceptionMessage = "")
        {
            if (condition.Equals(true))
            {
                return;
            }

            exceptionMessage = string.IsNullOrWhiteSpace(exceptionMessage)
                ? $"{parameterName}值已超過範圍"
                : exceptionMessage;

            throw new ArgumentOutOfRangeException(paramName: parameterName, message: exceptionMessage);
        }

        /// <summary>
        /// Checks the not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void CheckNotNull(
            [ValidatedNotNull] this object value,
            string parameterName,
            string exceptionMessage)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException
                (
                    paramName: parameterName,
                    message: string.IsNullOrWhiteSpace(exceptionMessage)
                    ? $"{parameterName}不可為Null"
                    : exceptionMessage
                );
        }

        /// <summary>
        /// Checks the not null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="nullExceptionMessage">The null exception message.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void CheckNotNullOrEmpty<T>(
            [ValidatedNotNull] this IEnumerable<T> value,
            string parameterName,
            string nullExceptionMessage = "",
            string exceptionMessage = "")
            where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException
                    (
                        paramName: parameterName,
                        message: string.IsNullOrWhiteSpace(nullExceptionMessage)
                        ? $"{parameterName}不可為Null"
                        : nullExceptionMessage
                    );
            }

            if (value.Any().Equals(true))
            {
                return;
            }

            throw new ArgumentException
                (
                    paramName: parameterName,
                    message: string.IsNullOrWhiteSpace(nullExceptionMessage)
                        ? $"{parameterName}為空請確認值"
                        : nullExceptionMessage
                );
        }

        /// <summary>
        /// Checks the structure not null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="nullExceptionMessage">The null exception message.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void CheckStructNotNullOrEmpty<T>(
            [ValidatedNotNull] this IEnumerable<T> value,
            string parameterName,
            string nullExceptionMessage = "",
            string exceptionMessage = "")
            where T : struct
        {
            if (value is null)
            {
                throw new ArgumentNullException
                    (
                        paramName: parameterName,
                        message: string.IsNullOrWhiteSpace(nullExceptionMessage)
                        ? $"{parameterName}不可為Null"
                        : nullExceptionMessage
                    );
            }

            if (value.Any().Equals(true))
            {
                return;
            }

            throw new ArgumentException
                (
                    paramName: parameterName,
                    message: string.IsNullOrWhiteSpace(nullExceptionMessage)
                        ? $"{parameterName}為空請確認值"
                        : nullExceptionMessage
                );
        }
    }
}
