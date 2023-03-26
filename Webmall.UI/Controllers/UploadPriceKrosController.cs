using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ValmiStore.Model.Entities;
using ValmiStore.Model.Repositories.Abstract;
using Webmall.UI.Core;
using ExcelDataReader;
using log4net;
using log4net.Config;
using ViewRes;
using ValmiStore.Model;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class UploadPriceKrosController : Controller
    {

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(UploadPriceKrosController));

        static UploadPriceKrosController()
        {
            XmlConfigurator.Configure();
        }

        #endregion


        private readonly ISuppliersRepository _suppliersRepository;


        public UploadPriceKrosController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        // GET: UploadPriceKros
        public ActionResult Index(int? id, GridViewOptions options)
        {
            if (!SessionHelper.IsSupplier)
                return RedirectToAction("Index", "Home");
            var clientId = SessionHelper.CurrentClientId;
            var result = _suppliersRepository.GetSuppliersPrice(clientId);
            var model = new GridViewModel<SupplierPrice>()
            {
                List = result.Skip(((options.CurrentPage ?? 1) - 1) * options.PageSize).Take(options.PageSize).ToList(),
                TotalPages = result.Count / options.PageSize + 1,
                CurrentPage = options.CurrentPage,
                AllowPageSizeSelection = false,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            if (!SessionHelper.IsSupplier)
                return RedirectToAction("Index", "Home");
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var clientId = SessionHelper.CurrentClientId;

                var MyFile = Request.Files[0];
                var path = Path.Combine(Server.MapPath("~/App_Data/temp"), MyFile.FileName);
                
                if (file != null && file.ContentLength > 0)
                {

                    using (MemoryStream ms = new MemoryStream())
                    {

                        Request.Files[0].InputStream.CopyTo(ms);

                        var rowIndex = 0;
                        List<SupplierPrice> sp_array = new List<SupplierPrice>();
                        using (var reader = ExcelReaderFactory.CreateReader(ms))
                        {
                            do
                            {
                                while (reader.Read())
                                {
                                    
                                    rowIndex++;                                    

                                    if(rowIndex>1) // 1 header
                                    {

                                        SupplierPrice sp = new SupplierPrice();
                                        int colNo = 0;
                                        try
                                        {
                                            sp.Producer = GetStrVal(reader.GetValue(colNo));
                                            colNo = 1;
                                            sp.Article = GetStrVal(reader.GetValue(colNo));

                                            colNo = 2;
                                            sp.OEM = GetStrVal(reader.GetValue(colNo));

                                            colNo = 3;
                                            sp.Name = GetStrVal(reader.GetValue(colNo));

                                            colNo = 4;
                                            sp.Available = GetStrVal(reader.GetValue(colNo));

                                            colNo = 6;
                                            sp.Price = GetStrVal(reader.GetValue(colNo));
                                            sp.SaleMultiplier = "1";

                                            if (sp.Producer != "")
                                            {
                                                sp_array.Add(sp);
                                            }
                                        }
                                        catch (System.IndexOutOfRangeException ex )
                                        {
                                            Log.Error("Upload (PriceKros)", ex);
                                            TempData["Title"] = SharedResources.Error;
                                            TempData["Message"] = string.Format(SharedResources.UploadSupplierPriceKrosMissingData, rowIndex, colNo);
                                            TempData["MsgImage"] = Url.Content("~/Content/images/error.jpg");
                                            return RedirectToAction("Show", "Message");
                                        } catch (System.Exception)
                                        {
                                            throw;
                                        }
                                    }
                                }
                            } while (reader.NextResult());
                        }
                        ms.Close();
                        _suppliersRepository.SetSuppliersPrice(clientId, sp_array);                       

                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadKros()
        {
            if (!SessionHelper.IsSupplier)
                return RedirectToAction("Index", "Home");
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var clientId = SessionHelper.CurrentClientId;


                if (file != null && file.ContentLength > 0)
                {

                    //var p = new ExcelPackage(file.InputStream);
                    //ExcelWorksheet ws = p.Workbook.Worksheets[1];

                    List<Kros> sp_array = new List<Kros>();

                    using (var ms = new MemoryStream())
                    {
                        Request.Files[0].InputStream.CopyTo(ms);
                        using (var reader = ExcelReaderFactory.CreateReader(ms))
                        {
                            var rowIndex = 0;
                            //do
                            {
                                while (reader.Read())
                                {

                                    rowIndex++;

                                    if (rowIndex > 1) // 1 header
                                    {

                                        Kros sp = new Kros();
                                        int colNo = 0;
                                        try
                                        {
                                            sp.Producer = GetStrVal(reader.GetValue(colNo));
                                            colNo = 1;
                                            sp.Article = GetStrVal(reader.GetValue(colNo));
                                            colNo = 2;
                                            sp.Name = GetStrVal(reader.GetValue(colNo));
                                            colNo = 3;
                                            sp.ArticleKros = GetStrVal(reader.GetValue(colNo));
                                            colNo = 4;
                                            sp.ProducerKros = GetStrVal(reader.GetValue(colNo));
                                            colNo = 5;
                                            sp.OEMKros = GetStrVal(reader.GetValue(colNo));
                                            
                                            sp.NameKros = "";

                                            if (sp.Producer != "")
                                            {
                                                sp_array.Add(sp);
                                            }
                                        }
                                        catch (System.IndexOutOfRangeException ex)
                                        {
                                            Log.Error("UploadKros", ex);
                                            TempData["Title"] = SharedResources.Error;
                                            TempData["Message"] = string.Format(SharedResources.UploadSupplierPriceKrosMissingData, rowIndex, colNo);
                                            TempData["MsgImage"] = Url.Content("~/Content/images/error.jpg");
                                            return RedirectToAction("Show", "Message");
                                        }
                                    }
                                }
                            } while (reader.NextResult());
                        }
                    }

                    _suppliersRepository.SetKros(clientId, sp_array);


                }
            }

            return RedirectToAction("Index");
        }

        private string GetStrVal(object o)
        {
            return o?.ToString() ?? "";
        }
    }
}