﻿using ApiLibreria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Constants
{
    public class EmployeeConstants
    {
        
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {FirstName = "Tomas", LastName = "Aliaga", Email = "taliaga@gmail.com" },
            new EmployeeModel() {FirstName = "Marcos", LastName = "Gonzalez", Email = "mgonzalez@gmail.com" },
        };
    }
}
