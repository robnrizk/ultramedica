using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class FisikController : Controller
    {
        //
        // GET: /Fisik/
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Index(int? year)
        {
            InitializeSession();

            if (Session["user"] != null)
            {
                ViewData["ErrorMessage"] = "";
                if (year == null)
                {
                    year = DateTime.Now.Year;
                }

                List<FISIK_INDEX> listfisik = new List<FISIK_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetFisikIndex()
                             select new FISIK_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID, FISIK_ID = fo.FISIK_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listfisik.AddRange(q);
                }

                return View(listfisik);
            }
            return RedirectToAction("LogOut");
        }

        //
        // GET: /Fisik/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Fisik/Create
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var objreturn = new FISIK();
                objreturn.YEAR_CHECKUP = DateTime.Now.Year.ToString();

                
                objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                objreturn.EMPLOYEE_ID = EMPLOYEE_ID;
                
                return View(objreturn);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Fisik/Create

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";
            var user = (USER)Session["user"];
            FISIK fisik = new FISIK();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        fisik = new FISIK();
                        fisik.EMPLOYEE_ID = form["EMPLOYEE_ID"];
                        fisik.YEAR_CHECKUP = form["YEAR_CHECKUP"];
                        fisik.TEMPAT_KERJA = form["TEMPAT_KERJA"];
                        fisik.POSISI_KERJA = form["POSISI_KERJA"];
                        fisik.PAPARAN = form["PAPARAN"];
                        fisik.METODE_KERJA = form["METODE_KERJA"];
                        fisik.RIWAYAT_ASMA = form["RIWAYAT_ASMA"] == "true";
                        fisik.RIWAYAT_EPILEPSI = form["RIWAYAT_EPILEPSI"] == "true";
                        fisik.RIWAYAT_LEPRA = form["RIWAYAT_LEPRA"] == "true";
                        fisik.RIWAYAT_ANSIETAS = form["RIWAYAT_ANSIETAS"] == "true";
                        fisik.RIWAYAT_DEPRESI = form["RIWAYAT_DEPRESI"] == "true";
                        fisik.RIWAYAT_DM = form["RIWAYAT_DM"] == "true";
                        fisik.RIWAYAT_PROSTAT = form["RIWAYAT_PROSTAT"] == "true";
                        fisik.RIWAYAT_HEMOROID = form["RIWAYAT_HEMOROID"] == "true";
                        fisik.RIWAYAT_KELAMIN = form["RIWAYAT_KELAMIN"] == "true";
                        fisik.VAKSIN_HEPATITIS = form["VAKSIN_HEPATITIS"] == "true";
                        fisik.RIWAYAT_OPERASI = form["RIWAYAT_OPERASI"] == "true";
                        fisik.RIWAYAT_KECELAKAAN_KERJA = form["RIWAYAT_KECELAKAAN_KERJA"] == "true";
                        fisik.SUMMARY_RIWAYAT_PENYAKIT = form["SUMMARY_RIWAYAT_PENYAKIT"];
                        fisik.KEBIASAAN_ALKOHOL = form["KEBIASAAN_ALKOHOL"];
                        fisik.KEBIASAAN_OLAHRAGA = form["KEBIASAAN_OLAHRAGA"];
                        fisik.KEBIASAAN_MEROKOK = form["KEBIASAAN_MEROKOK"];
                        fisik.KEBIASAAN_NARKOBA = form["KEBIASAAN_NARKOBA"];
                        fisik.TINGGI_BADAN = string.IsNullOrEmpty(form["TINGGI_BADAN"]) ? 0 : Convert.ToInt32(form["TINGGI_BADAN"]);
                        fisik.BERAT_BADAN = string.IsNullOrEmpty(form["BERAT_BADAN"]) ? 0 : Convert.ToInt32(form["BERAT_BADAN"]);
                        fisik.BMI = string.IsNullOrEmpty(form["BMI"]) ? 0 : Convert.ToDecimal(form["BMI"] ?? "0");
                        fisik.LKR_DD = string.IsNullOrEmpty(form["LKR_DD"]) ? 0 : Convert.ToInt32(form["LKR_DD"] ?? "0");
                        fisik.LKR_PRT = string.IsNullOrEmpty(form["LKR_PRT"]) ? 0 : Convert.ToInt32(form["LKR_PRT"] ?? "0");
                        fisik.T_SISTOL = string.IsNullOrEmpty(form["T_SISTOL"]) ? 0 : Convert.ToInt32(form["T_SISTOL"] ?? "0");
                        fisik.T_DIASTOL = string.IsNullOrEmpty(form["T_DIASTOL"]) ? 0 : Convert.ToInt32(form["T_DIASTOL"] ?? "0");
                        fisik.NADI = string.IsNullOrEmpty(form["NADI"]) ? 0 : Convert.ToInt32(form["NADI"] ?? "0");
                        fisik.RESPIRASI = string.IsNullOrEmpty(form["RESPIRASI"]) ? 0 : Convert.ToInt32(form["RESPIRASI"] ?? "0");
                        fisik.VISUS_JAUH_TANPA_KACMATA = form["VISUS_JAUH_TANPA_KACMATA"];
                        fisik.VISUS_JAUH_DENGAN = form["VISUS_JAUH_DENGAN"];
                        fisik.VISUS_DEKAT_TANPA_KACAMATA = form["VISUS_DEKAT_TANPA_KACAMATA"];
                        fisik.VISUS_DEKAT_DENGAN_KACAMATA = form["VISUS_DEKAT_DENGAN_KACAMATA"];
                        fisik.BUTA_WARNA = form["BUTA_WARNA"] == "true";
                        fisik.ANAMNESA_KELUHAN_UTAMA = form["ANAMNESA_KELUHAN_UTAMA"];
                        fisik.ANAMNESA_KELUHAN_TAMBAHAN = form["ANAMNESA_KELUHAN_TAMBAHAN"];
                        fisik.MATA = form["MATA"];
                        fisik.TELINGA = form["TELINGA"];
                        fisik.HIDUNG = form["HIDUNG"];
                        fisik.MULUT = form["MULUT"];
                        fisik.FARING = form["FARING"];
                        fisik.TONSIL = form["TONSIL"];
                        fisik.THYROID = form["THYROID"];
                        fisik.LYMP_NODE = form["LYMP_NODE"];
                        fisik.DADA = form["DADA"];
                        fisik.PERUT = form["PERUT"];
                        fisik.HERNIA = form["HERNIA"];
                        fisik.ANUS = form["ANUS"];
                        fisik.PAYUDARA = form["PAYUDARA"];
                        fisik.VARICHES_HEMOROID = form["VARICHES_HEMOROID"];
                        fisik.KULIT_KUKU = form["KULIT_KUKU"];
                        fisik.PULMO_SIST_RESPIRASI = form["PULMO_SIST_RESPIRASI"];
                        fisik.COR_SIST_CV = form["COR_SIST_CV"];
                        fisik.HATI_LIEN_GIT = form["HATI_LIEN_GIT"];
                        fisik.SUG = form["SUG"];
                        fisik.SIST_REPROD = form["SIST_REPROD"];
                        fisik.EXTRIMITAS_ATAS = form["EXTRIMITAS_ATAS"];
                        fisik.EXTRIMITAS_BAWAH = form["EXTRIMITAS_BAWAH"];
                        fisik.OTOT_TULANG_LAIN = form["OTOT_TULANG_LAIN"];
                        fisik.BAU_MULUT = form["BAU_MULUT"] == "true";
                        fisik.KARIES = string.IsNullOrEmpty(form["KARIES"]) ? 0 : Convert.ToInt32(form["KARIES"] ?? "0");
                        fisik.TANGGAL = string.IsNullOrEmpty(form["TANGGAL"]) ? 0 : Convert.ToInt32(form["TANGGAL"] ?? "0");
                        fisik.SISA_AKAR = string.IsNullOrEmpty(form["SISA_AKAR"]) ? 0 : Convert.ToInt32(form["SISA_AKAR"] ?? "0");
                        fisik.REFLEX_PATOLOGIS = form["REFLEX_PATOLOGIS"] == "true";
                        fisik.PARESTESI = form["PARESTESI"] == "true";
                        fisik.PARESE = form["PARESE"] == "true";
                        fisik.LASSAGUESIGN = form["LASSAGUESIGN"] == "true";
                        fisik.PATRICK_SIGN = form["PATRICK_SIGN"] == "true";
                        fisik.CONTRA_PATRICK_SIGN = form["CONTRA_PATRICK_SIGN"] == "true";
                        fisik.SUMMARY_KESIMPULAN = form["SUMMARY_KESIMPULAN"];
                        fisik.CHECKED_BY = user.NIK;

                        dc.FISIKs.InsertOnSubmit(fisik);
                        dc.SubmitChanges();
                    }
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(fisik);
            }
        }

        //
        // GET: /Fisik/Edit/5
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Edit(string employee_id, string year_checkup)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";
                ViewData["ErrorMessage"] = "";
                FISIK fisik = new FISIK();
                try
                {
                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        fisik =
                            dc.FISIKs.SingleOrDefault(
                                o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));
                    }
                    return View(fisik);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(fisik);
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Fisik/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var employeeId = form["EMPLOYEE_ID"];
            var yearCheckup = form["YEAR_CHECKUP"];
            var user = (USER)Session["user"];

            FISIK fisik = new FISIK();

            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                fisik = dc.FISIKs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(employeeId) && o.YEAR_CHECKUP.Equals(yearCheckup));
                try
                {
                    if (fisik != null)
                    {
                        if (ModelState.IsValid)
                        {
                            fisik.TEMPAT_KERJA = form["TEMPAT_KERJA"];
                            fisik.POSISI_KERJA = form["POSISI_KERJA"];
                            fisik.PAPARAN = form["PAPARAN"];
                            fisik.METODE_KERJA = form["METODE_KERJA"];
                            fisik.RIWAYAT_ASMA = form["RIWAYAT_ASMA"] == "true";
                            fisik.RIWAYAT_EPILEPSI = form["RIWAYAT_EPILEPSI"] == "true";
                            fisik.RIWAYAT_LEPRA = form["RIWAYAT_LEPRA"] == "true";
                            fisik.RIWAYAT_ANSIETAS = form["RIWAYAT_ANSIETAS"] == "true";
                            fisik.RIWAYAT_DEPRESI = form["RIWAYAT_DEPRESI"] == "true";
                            fisik.RIWAYAT_DM = form["RIWAYAT_DM"] == "true";
                            fisik.RIWAYAT_PROSTAT = form["RIWAYAT_PROSTAT"] == "true";
                            fisik.RIWAYAT_HEMOROID = form["RIWAYAT_HEMOROID"] == "true";
                            fisik.RIWAYAT_KELAMIN = form["RIWAYAT_KELAMIN"] == "true";
                            fisik.VAKSIN_HEPATITIS = form["VAKSIN_HEPATITIS"] == "true";
                            fisik.RIWAYAT_OPERASI = form["RIWAYAT_OPERASI"] == "true";
                            fisik.RIWAYAT_KECELAKAAN_KERJA = form["RIWAYAT_KECELAKAAN_KERJA"] == "true";
                            fisik.SUMMARY_RIWAYAT_PENYAKIT = form["SUMMARY_RIWAYAT_PENYAKIT"];
                            fisik.KEBIASAAN_ALKOHOL = form["KEBIASAAN_ALKOHOL"];
                            fisik.KEBIASAAN_OLAHRAGA = form["KEBIASAAN_OLAHRAGA"];
                            fisik.KEBIASAAN_MEROKOK = form["KEBIASAAN_MEROKOK"];
                            fisik.KEBIASAAN_NARKOBA = form["KEBIASAAN_NARKOBA"];
                            fisik.TINGGI_BADAN = string.IsNullOrEmpty(form["TINGGI_BADAN"]) ? 0 : Convert.ToInt32(form["TINGGI_BADAN"]);
                            fisik.BERAT_BADAN = string.IsNullOrEmpty(form["BERAT_BADAN"]) ? 0 : Convert.ToInt32(form["BERAT_BADAN"]);
                            fisik.BMI = string.IsNullOrEmpty(form["BMI"]) ? 0 : Convert.ToDecimal(form["BMI"] ?? "0");
                            fisik.LKR_DD = string.IsNullOrEmpty(form["LKR_DD"]) ? 0 : Convert.ToInt32(form["LKR_DD"] ?? "0");
                            fisik.LKR_PRT = string.IsNullOrEmpty(form["LKR_PRT"]) ? 0 : Convert.ToInt32(form["LKR_PRT"] ?? "0");
                            fisik.T_SISTOL = string.IsNullOrEmpty(form["T_SISTOL"]) ? 0 : Convert.ToInt32(form["T_SISTOL"] ?? "0");
                            fisik.T_DIASTOL = string.IsNullOrEmpty(form["T_DIASTOL"]) ? 0 : Convert.ToInt32(form["T_DIASTOL"] ?? "0");
                            fisik.NADI = string.IsNullOrEmpty(form["NADI"]) ? 0 : Convert.ToInt32(form["NADI"] ?? "0");
                            fisik.RESPIRASI = string.IsNullOrEmpty(form["RESPIRASI"]) ? 0 : Convert.ToInt32(form["RESPIRASI"] ?? "0");
                            fisik.VISUS_JAUH_TANPA_KACMATA = form["VISUS_JAUH_TANPA_KACMATA"];
                            fisik.VISUS_JAUH_DENGAN = form["VISUS_JAUH_DENGAN"];
                            fisik.VISUS_DEKAT_TANPA_KACAMATA = form["VISUS_DEKAT_TANPA_KACAMATA"];
                            fisik.VISUS_DEKAT_DENGAN_KACAMATA = form["VISUS_DEKAT_DENGAN_KACAMATA"];
                            fisik.BUTA_WARNA = form["BUTA_WARNA"] == "true" ? true : false;
                            fisik.ANAMNESA_KELUHAN_UTAMA = form["ANAMNESA_KELUHAN_UTAMA"];
                            fisik.ANAMNESA_KELUHAN_TAMBAHAN = form["ANAMNESA_KELUHAN_TAMBAHAN"];
                            fisik.MATA = form["MATA"];
                            fisik.TELINGA = form["TELINGA"];
                            fisik.HIDUNG = form["HIDUNG"];
                            fisik.MULUT = form["MULUT"];
                            fisik.FARING = form["FARING"];
                            fisik.TONSIL = form["TONSIL"];
                            fisik.THYROID = form["THYROID"];
                            fisik.LYMP_NODE = form["LYMP_NODE"];
                            fisik.DADA = form["DADA"];
                            fisik.PERUT = form["PERUT"];
                            fisik.HERNIA = form["HERNIA"];
                            fisik.ANUS = form["ANUS"];
                            fisik.PAYUDARA = form["PAYUDARA"];
                            fisik.VARICHES_HEMOROID = form["VARICHES_HEMOROID"];
                            fisik.KULIT_KUKU = form["KULIT_KUKU"];
                            fisik.PULMO_SIST_RESPIRASI = form["PULMO_SIST_RESPIRASI"];
                            fisik.COR_SIST_CV = form["COR_SIST_CV"];
                            fisik.HATI_LIEN_GIT = form["HATI_LIEN_GIT"];
                            fisik.SUG = form["SUG"];
                            fisik.SIST_REPROD = form["SIST_REPROD"];
                            fisik.EXTRIMITAS_ATAS = form["EXTRIMITAS_ATAS"];
                            fisik.EXTRIMITAS_BAWAH = form["EXTRIMITAS_BAWAH"];
                            fisik.OTOT_TULANG_LAIN = form["OTOT_TULANG_LAIN"];
                            fisik.BAU_MULUT = form["BAU_MULUT"] == "true";
                            fisik.KARIES = string.IsNullOrEmpty(form["KARIES"]) ? 0 : Convert.ToInt32(form["KARIES"] ?? "0");
                            fisik.TANGGAL = string.IsNullOrEmpty(form["TANGGAL"]) ? 0 : Convert.ToInt32(form["TANGGAL"] ?? "0");
                            fisik.SISA_AKAR = string.IsNullOrEmpty(form["SISA_AKAR"]) ? 0 : Convert.ToInt32(form["SISA_AKAR"] ?? "0");
                            fisik.REFLEX_PATOLOGIS = form["REFLEX_PATOLOGIS"] == "true";
                            fisik.PARESTESI = form["PARESTESI"] == "true";
                            fisik.PARESE = form["PARESE"] == "true";
                            fisik.LASSAGUESIGN = form["LASSAGUESIGN"] == "true";
                            fisik.PATRICK_SIGN = form["PATRICK_SIGN"] == "true";
                            fisik.CONTRA_PATRICK_SIGN = form["CONTRA_PATRICK_SIGN"] == "true";
                            fisik.SUMMARY_KESIMPULAN = form["SUMMARY_KESIMPULAN"];
                            fisik.CHECKED_BY = user.NIK;

                            dc.SubmitChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(fisik);
                }
            }
        }

        //
        // GET: /Fisik/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Fisik/Delete/5

        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                FISIK fisik;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    fisik =
                        dc.FISIKs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (fisik != null)
                    {
                        dc.FISIKs.DeleteOnSubmit(fisik);
                        dc.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        private void InitializeSession()
        {
            if (Session["user"] != null)
            {
                var user = Helper.SetSession(Request.Cookies[FormsAuthentication.FormsCookieName]);
                Session["user"] = user;
                Session["roles"] = user.ROLES;
            }
        }
    }
}
