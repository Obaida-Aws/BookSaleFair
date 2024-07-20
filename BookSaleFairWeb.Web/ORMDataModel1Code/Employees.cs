using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace BookSaleFairWeb.Web.BookSaleFair
{

    public partial class Employees
    {
        public Employees(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
