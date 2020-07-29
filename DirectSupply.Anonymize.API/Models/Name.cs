namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// Contains information about a person's name
    /// </summary>
    public class Name
    {
        /// <summary>
        /// The person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The person's last name
        /// </summary>
        public string LastName { get; set; }
    }
}