﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.Entities;

[Index("CompanyName", Name = "CompanyName")]
[Index("AddressID", Name = "UX_Customers_AddressID", IsUnique = true)]
public partial class Customer
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(5,ErrorMessage ="CustomerID is limited to 5 characters.")]
    public string CustomerID { get; set; }

    [Required]
    [StringLength(40, ErrorMessage = "Company Name is limited to 40 characters.")]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Contact Name is limited to 30 characters.")]
    public string ContactName { get; set; }

    [StringLength(30, ErrorMessage = "Contact Title is limited to 30 characters.")]
    public string ContactTitle { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Contact Email is limited to 50 characters.")]
    public string ContactEmail { get; set; }

    public int AddressID { get; set; }

    [Required]
    [StringLength(24)]
    public string Phone { get; set; }

    [StringLength(24, ErrorMessage = "Fax is limited to 24 digits.")]
    public string Fax { get; set; }

    [ForeignKey("AddressID")]
    [InverseProperty("Customer")]
    public virtual Address Address { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}