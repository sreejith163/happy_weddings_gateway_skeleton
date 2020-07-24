namespace Happy.Weddings.Gateway.Core.Validators
{
    /// <summary>
    /// Interfacce for developing validator for Input data validation
    /// </summary>
    /// <typeparam name="T">Represenst the type to be validated</typeparam>
    public interface IDataValidator<T> where T : class
    {
        /// <summary>
        /// Calidates an instance and returns the error messages as Key Value pairs
        /// </summary>
        /// <typeparam name="T">Represents the Instance</typeparam>
        /// <param name="errorMessages">Represents the dictionary that contains the key values</param>
        /// <returns>True if validation succeeds , else it returs false</returns>
        ValidatorResult ValidateInstance(T instance);
    }
}
