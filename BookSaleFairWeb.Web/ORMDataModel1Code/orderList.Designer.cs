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

    public partial class orderList : XPLiteObject
    {
        int fid;
        [Key(true)]
        public int id
        {
            get { return fid; }
            set { SetPropertyValue<int>(nameof(id), ref fid, value); }
        }
        Books fbookId;
        [Association(@"orderListReferencesBooks")]
        public Books bookId
        {
            get { return fbookId; }
            set { SetPropertyValue<Books>(nameof(bookId), ref fbookId, value); }
        }
        Orders forderId;
        [Association(@"orderListReferencesOrders")]
        public Orders orderId
        {
            get { return forderId; }
            set { SetPropertyValue<Orders>(nameof(orderId), ref forderId, value); }
        }
        int fquantity;
        public int quantity
        {
            get { return fquantity; }
            set { SetPropertyValue<int>(nameof(quantity), ref fquantity, value); }
        }
    }

}
