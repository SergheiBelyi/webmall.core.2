using System;
using System.Collections.Generic;

namespace Webmall.Model.Entities.User 
{
    public class VINRequest
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Дата ответа
        /// </summary>
        public DateTime? AnswerDate { get; set; }

        /// <summary>
        /// VIN-код автомобиля
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Код марки ато
        /// </summary>
        public int? MarkaId { get; set; }

        /// <summary>
        /// Наименование марки авто
        /// </summary>
        public string MarkaName { get; set; }

        /// <summary>
        /// Код модели авто
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Код модели авто
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Код модификации авто
        /// </summary>
        public int? ModifId { get; set; }

        /// <summary>
        /// Наименование модификации авто
        /// </summary>
        public string ModifName { get; set; }

        /// <summary>
        /// Год выпуска авто
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Признак ответа от менеджера
        /// </summary>
        public bool IsRepsonded { get; set; }

        //public VINRequest ParentRequest { get; set; }

        //private List <VINRequest> ChildRequests { get; set; }

        /// <summary>
        /// Информация о запрашиваемых частях
        /// </summary>
        public List<PartInfo> Parts { get; set; }

        /// <summary>
        /// Код ответившего менеджера
        /// </summary>
        public int? ManagerId { get; set; }

        /// <summary>
        /// Код отправившего запрос пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Номер двигателя
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// Тип трансмиссии
        /// </summary>
        public string TransmissionType { get; set; }

        public VINRequest()
        {
            //ChildRequests = new List<VINRequest>();
            Parts = new List<PartInfo>();
        }

        //public VINRequest(DbVINRequest dbRequest)
        //{
        //    //ChildRequests = new List<VINRequest>();
        //    Parts = new List<PartInfo>();
        //    Id = dbRequest.Id;
        //    VIN = dbRequest.VINCode;
        //    MarkaId = dbRequest.MarkaId;
        //    MarkaName = dbRequest.MarkaName;
        //    ModelId = dbRequest.ModelId;
        //    ModelName = dbRequest.ModelName;
        //    ModifId = dbRequest.ModifId;
        //    ModifName = dbRequest.ModifName;
        //    Year = dbRequest.Year;
        //    Comment = dbRequest.Comment;
        //    IsRepsonded = dbRequest.IsRepsonded;
        //    ManagerId = dbRequest.ManagerId;
        //    UserId = dbRequest.UserId;
        //    SendDate = dbRequest.SendDate;
        //    AnswerDate = dbRequest.AnswerDate;
        //    EngineNumber = dbRequest.EngineNumber;
        //    TransmissionType = dbRequest.TransmissionType;

        //    foreach (var item in dbRequest.VINDetails)
        //        Parts.Add(new PartInfo(item));
        //}

        //public DbVINRequest SetDBItem (DbVINRequest dbRequest)            
        //{
        //    dbRequest.ManagerId = ManagerId;
        //    dbRequest.MarkaId = MarkaId;
        //    dbRequest.ModelId = ModelId;
        //    dbRequest.ModifId = ModifId;
        //    dbRequest.MarkaName = MarkaName;
        //    dbRequest.ModelName = ModelName;
        //    dbRequest.ModifName = ModifName;
        //    dbRequest.UserId = UserId;
        //    dbRequest.VINCode = VIN;
        //    dbRequest.Year = Year;
        //    dbRequest.SendDate = SendDate;
        //    dbRequest.Comment = Comment;

        //    dbRequest.TransmissionType = 
        //        (!string.IsNullOrEmpty(TransmissionType) && TransmissionType.Length > 50) ? 
        //            TransmissionType.Substring(0, 50) : TransmissionType;
        //    dbRequest.EngineNumber =
        //        (!string.IsNullOrEmpty(EngineNumber) && EngineNumber.Length > 50) ?
        //            EngineNumber.Substring(0, 50) : EngineNumber;

        //    if (!dbRequest.IsRepsonded && IsRepsonded)
        //        dbRequest.AnswerDate = DateTime.Now;
        //    dbRequest.IsRepsonded = IsRepsonded;
        //    if (!dbRequest.IsRepsonded)
        //        dbRequest.AnswerDate = null;
        //    return dbRequest;
        //}
    }

    public class PartInfo
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public int? Quantity { get; set; }
        public string WareNums { get; set; }
        public string ResponseComment { get; set; }

        //public PartInfo(DbVINRequestDetail item)
        //{
        //    Id = item.Id;
        //    WareNums = item.Nums;
        //    Description = item.Description;
        //    Quantity = item.Quantity;
        //    ResponseComment = item.ResponseComment;
        //}
    }
}
