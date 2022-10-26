using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
            if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();

        [Route("[controller]")]
        [ApiController]
        public class WeatherForecastController : ControllerBase
        {
            private readonly IRepositoryManager _repository;
            public WeatherForecastController(IRepositoryManager repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                _repository.Company.AnyMethodFromCompanyRepository();
                _repository.Employee.AnyMethodFromEmployeeRepository();
                return new string[] { "value1", "value2" };
            }
        }
    }
}
