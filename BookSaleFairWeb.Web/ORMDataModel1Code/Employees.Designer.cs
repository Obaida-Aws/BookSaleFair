﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace BookSaleFairWeb.Web.BookSaleFair
{

    public partial class Employees : XPLiteObject
    {
        int fid;
        [Key(true)]
        public int id
        {
            get { return fid; }
            set { SetPropertyValue<int>(nameof(id), ref fid, value); }
        }
        Users fuserId;
        [Association(@"EmployeesReferencesUsers")]
        public Users userId
        {
            get { return fuserId; }
            set { SetPropertyValue<Users>(nameof(userId), ref fuserId, value); }
        }
        decimal fsalary;
        public decimal salary
        {
            get { return fsalary; }
            set { SetPropertyValue<decimal>(nameof(salary), ref fsalary, value); }
        }
        [Association(@"OrdersReferencesEmployees")]
        public XPCollection<Orders> OrdersCollection { get { return GetCollection<Orders>(nameof(OrdersCollection)); } }
    }

}