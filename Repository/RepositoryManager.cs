﻿using Contracts;
using Entities;
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
        private IPizzeriaRepository _pizzeriaRepository;
        private IMenuRepository _menuRepository;
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
        public IPizzeriaRepository Pizzeria
        {
            get
            {
                if (_pizzeriaRepository == null)
                    _pizzeriaRepository = new PizzeriaRepository(_repositoryContext);
                return _pizzeriaRepository;
            }
        }
        public IMenuRepository Menu
        {
            get
            {
                if (_menuRepository == null)
                    _menuRepository = new MenuRepository(_repositoryContext);
                return _menuRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();


    }
}
