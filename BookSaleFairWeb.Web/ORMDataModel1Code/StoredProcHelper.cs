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
    public static class SprocHelper
    {
        public static DevExpress.Xpo.DB.SelectedData Execsp_alterdiagram(Session session, string diagramname, int owner_id, int version, byte[] definition)
        {
            return session.ExecuteSproc("sp_alterdiagram", new OperandValue(diagramname), new OperandValue(owner_id), new OperandValue(version), new OperandValue(definition));
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_creatediagram(Session session, string diagramname, int owner_id, int version, byte[] definition)
        {
            return session.ExecuteSproc("sp_creatediagram", new OperandValue(diagramname), new OperandValue(owner_id), new OperandValue(version), new OperandValue(definition));
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_dropdiagram(Session session, string diagramname, int owner_id)
        {
            return session.ExecuteSproc("sp_dropdiagram", new OperandValue(diagramname), new OperandValue(owner_id));
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_helpdiagramdefinition(Session session, string diagramname, int owner_id)
        {
            return session.ExecuteSproc("sp_helpdiagramdefinition", new OperandValue(diagramname), new OperandValue(owner_id));
        }
        public static System.Collections.Generic.ICollection<sp_helpdiagramdefinitionResult> Execsp_helpdiagramdefinitionIntoObjects(Session session, string diagramname, int owner_id)
        {
            return session.GetObjectsFromSproc<sp_helpdiagramdefinitionResult>("sp_helpdiagramdefinition", new OperandValue(diagramname), new OperandValue(owner_id));
        }
        public static XPDataView Execsp_helpdiagramdefinitionIntoDataView(Session session, string diagramname, int owner_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_helpdiagramdefinition", new OperandValue(diagramname), new OperandValue(owner_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_helpdiagramdefinitionResult)), sprocData);
        }
        public static void Execsp_helpdiagramdefinitionIntoDataView(XPDataView dataView, Session session, string diagramname, int owner_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_helpdiagramdefinition", new OperandValue(diagramname), new OperandValue(owner_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_helpdiagramdefinitionResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_helpdiagrams(Session session, string diagramname, int owner_id)
        {
            return session.ExecuteSproc("sp_helpdiagrams", new OperandValue(diagramname), new OperandValue(owner_id));
        }
        public static System.Collections.Generic.ICollection<sp_helpdiagramsResult> Execsp_helpdiagramsIntoObjects(Session session, string diagramname, int owner_id)
        {
            return session.GetObjectsFromSproc<sp_helpdiagramsResult>("sp_helpdiagrams", new OperandValue(diagramname), new OperandValue(owner_id));
        }
        public static XPDataView Execsp_helpdiagramsIntoDataView(Session session, string diagramname, int owner_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_helpdiagrams", new OperandValue(diagramname), new OperandValue(owner_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_helpdiagramsResult)), sprocData);
        }
        public static void Execsp_helpdiagramsIntoDataView(XPDataView dataView, Session session, string diagramname, int owner_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_helpdiagrams", new OperandValue(diagramname), new OperandValue(owner_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_helpdiagramsResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_renamediagram(Session session, string diagramname, int owner_id, string new_diagramname)
        {
            return session.ExecuteSproc("sp_renamediagram", new OperandValue(diagramname), new OperandValue(owner_id), new OperandValue(new_diagramname));
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_upgraddiagrams(Session session)
        {
            return session.ExecuteSproc("sp_upgraddiagrams");
        }
    }
}