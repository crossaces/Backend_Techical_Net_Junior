using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace Backend.Models;
public class Player
{
        public long Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? BirthPlace { get; set; }
}

