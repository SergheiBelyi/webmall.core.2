using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ValmiStore.Model.Entities.User;

namespace Webmall.UI.Models
{
    public class ComparisionActModel
    {

        // �������

        public string StartDate { get; set; }
        public DateTime StartDateAsDate { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateAsDate { get; set; }

        /// <summary>
        /// ������� ���� ������
        /// </summary>
        public List<ComparisionAct> List { get; set; }
        // public GridViewModel<ComparisionAct> List { get; set; }

        public List<SelectListItem> DocTypes { get; set; }
        public List<SelectListItem> PaymentForms { get; set; }
        public List<SelectListItem> PaymentStatuses { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// ����������� �� ����������� ����
        /// </summary>
        public DateTime MinDate { get; set; }

        /// <summary>
        /// ������������ ������
        /// </summary>
        public string ValuteName { get; set; }
    }
}