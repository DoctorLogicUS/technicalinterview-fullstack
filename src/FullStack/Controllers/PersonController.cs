using FullStack.Data;
using FullStack.Data.Models;
using FullStack.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FullStack.Controllers
{
    public class PersonController : Controller
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<PersonType> _personTypeRepository;

        public PersonController(IRepository<Person> personRepository, IRepository<PersonType> personTypeRepository)
        {
            _personRepository = personRepository;
            _personTypeRepository = personTypeRepository;
        }

        public async Task<ActionResult> Create()
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonViewModel viewModel)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Delete(int id)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Index(int? personType = null)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Update(int id)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PersonViewModel viewModel)
        {
            // TODO: finish stubbed method
            throw new NotImplementedException();
        }
    }
}