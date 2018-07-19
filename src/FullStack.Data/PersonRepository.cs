using Dapper;
using FullStack.Data.Models;

namespace FullStack.Data
{
    public class PersonRepository : SqlRepository<Person>
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {
        }

        protected override DynamicParameters ValuesToParameters(Person values)
        {
            var parameters = new DynamicParameters();

            if (values != null)
            {
                parameters.AddDynamicParams(new { values.FirstName, values.LastName, values.PersonTypeId });
            }

            return parameters;
        }
    }
}