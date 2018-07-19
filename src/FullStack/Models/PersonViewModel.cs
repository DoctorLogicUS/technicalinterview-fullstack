using FullStack.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    [MetadataType(typeof(PersonViewModelMetadata))]
    public class PersonViewModel : Person
    {
        public PersonViewModel()
        {
        }

        public PersonViewModel(Person person)
        {
            FirstName = person?.FirstName;
            LastName = person?.LastName;
            PersonId = person?.PersonId ?? 0;
            PersonTypeId = person?.PersonTypeId ?? 0;
        }
    }

    public class PersonViewModelMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName;

        [Display(Name = "Person ID")]
        public int PersonId;

        [Required]
        [Display(Name = "Person Type")]
        public int PersonTypeId;
    }
}